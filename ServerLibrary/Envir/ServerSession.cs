using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FreeSql;
using Library;
using Library.MirDB;
using Library.SystemModels;
using MirDB;

namespace Server.Envir
{
    public sealed class ServerSession : Session
    {
        public ServerSession(string connectionString) : base(connectionString)
        {
        }

        public ServerSession(SessionMode mode, string root = ".\\Database\\", string backup = ".\\Backup\\") : base(mode, root, backup)
        {
        }

        public void LoadDataFromSqlite()
        {
            if (Collections == null || Collections.Count == 0)
            {
                throw new InvalidOperationException("Call init collection first");
            }

            var itemInfoList = SEnvir.FreeSql.Select<ItemInfo>().ToList();

            var collection1 = GetCollection<ItemInfo>();
            itemInfoList.ForEach(x =>
            {
                x.Collection = collection1;
                collection1.Binding.Add(x);
            });

            var itemStatList = SEnvir.FreeSql.Select<ItemInfoStat>().ToList();

            var collection2 = GetCollection<ItemInfoStat>();
            itemStatList.ForEach(x =>
            {
                x.Collection = collection2;
                collection2.Binding.Add(x);
            });

            var magicList = SEnvir.FreeSql.Select<MagicInfo>().ToList();
            var collection3 = GetCollection<MagicInfo>();
            magicList.ForEach(x =>
            {
                x.Collection = collection3;
                collection3.Binding.Add(x);
            });

            var monsterList = SEnvir.FreeSql.Select<MonsterInfo>().ToList();
            var collection4 = GetCollection<MonsterInfo>();
            monsterList.ForEach(x =>
            {
                x.Collection = collection4;
                collection4.Binding.Add(x);
            });

            var monsterStatList = SEnvir.FreeSql.Select<MonsterInfoStat>().ToList();
            var collection5 = GetCollection<MonsterInfoStat>();
            monsterStatList.ForEach(x =>
            {
                x.Collection = collection5;
                collection5.Binding.Add(x);
            });
        }

        public void LoadDataFromOldVersion(string path = "Mir200")
        {
            if (Collections == null || Collections.Count == 0)
            {
                throw new InvalidOperationException("Call init collection first");
            }

            path = Path.Combine(path, "Envir");
            if (!Directory.Exists(path))
            {
                 throw new ArgumentException("Server Data Not Found");
            }

            LoadMaps(path);
            LoadSafeZone(path);

            ProcessRelations();

            if ((Mode & SessionMode.Users) == SessionMode.Users)
                InitializeUsers();

            Parallel.ForEach(Relationships, x => x.Value.ConsumeKeys(this));

            Relationships = null;

            foreach (KeyValuePair<Type, ADBCollection> pair in Collections)
                pair.Value.OnLoaded();

            //SaveSystem();
        }

        private void LoadMaps(string path)
        {
            var data = File.ReadAllLines(Path.Combine(path, "MapInfo.txt"), Encoding.GetEncoding("GB2312"));
            var collection = GetCollection<MapInfo>();
            foreach (var s in data)
            {
                if (!s.StartsWith("[")) continue;
                var info = s.Substring(1, s.IndexOf("]") - 1)
                    .Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);

                var map = collection.CreateNewObject();
                map.FileName = info[0];
                map.Description = info[1];
                map.MiniMap = 0;
                map.Light = LightSetting.Default;
                map.Fight = FightSetting.None;
                map.CanHorse = true;
                map.AllowTT = true;
                map.CanMine = false;
                map.CanMarriageRecall = true;
                map.AllowRecall = true;
                map.MinimumLevel = 0;
                map.MaximumLevel = 0;
                map.Music = SoundIndex.None;
            }

            var reconnectRegex = new Regex(@"NORECONNECT\((.*?)\)");

            foreach (var s in data)
            {
                if (!s.StartsWith("[")) continue;
                var info = s.Substring(1, s.IndexOf("]") - 1)
                    .Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);

                var map = collection.Binding.FirstOrDefault(m => m.FileName == info[0]);
                if(map == null) continue;
                if (s.Contains("NORANDOMMOVE"))
                {
                    map.AllowRT = false;
                    map.AllowTT = false;
                }

                if (s.Contains("NORECALL"))
                {
                    map.AllowRecall = false;
                }

                if (s.Contains("MINE"))
                {
                    map.CanMine = true;
                }

                var match = reconnectRegex.Match(s);
                if (match.Success)
                {
                    map.ReconnectMap = collection.Binding.FirstOrDefault(m => m.FileName == match.Groups[1].Value);
                }
            }
        }

        private void LoadSafeZone(string path)
        {
            var data = File.ReadAllLines(Path.Combine(path, "StartPoint.txt"), Encoding.GetEncoding("GB2312"));
            var collection = GetCollection<SafeZoneInfo>();
            var regionCollection = GetCollection<MapRegion>();
            var mapCollection = GetCollection<MapInfo>();
            foreach (var s in data)
            {
                if(s.StartsWith(";")) continue;
                var info = s.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var map = mapCollection.Binding.FirstOrDefault(m => m.FileName == info[0]);
                if(map == null) continue;
                var x = int.Parse(info[1]);
                var y = int.Parse(info[2]);
                var size = int.Parse(info[4]);
                var region = regionCollection.CreateNewObject();
                region.Map = map;
                var pointList = new List<Point>();
                for (int i = x - size; i <= x+size; i++)
                {
                    for (int j = y - size; j <= y + size; j++)
                    {
                        pointList.Add(new Point(i, j));
                    }
                }

                region.PointRegion = pointList.ToArray();
                region.Description = "安全区";
                map.Regions.Add(region);
                var safezone = collection.CreateNewObject();
                safezone.Region = region;
                safezone.BindRegion = region;
                if(safezone.Index == 1) safezone.StartClass = RequiredClass.All;
            }
        }
        private void ProcessRelations()
        {
            foreach (var collection in Collections)
            {
                var type = collection.Key;
                var relationPropList = new List<PropertyInfo>();
                var allPropList = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (var propertyInfo in allPropList)
                {
                    var attr = propertyInfo.GetCustomAttribute<Association>();
                    if (attr != null && !attr.Aggregate)
                    {
                        relationPropList.Add(propertyInfo);
                    }
                }

                foreach (DBObject obj in collection.Value.GetCollection())
                {
                    foreach (var propertyInfo in relationPropList)
                    {
                        if (!typeof(DBObject).IsAssignableFrom(propertyInfo.PropertyType))
                        {
                            throw new NotSupportedException($"Association Can not set on {type.FullName}.{propertyInfo.Name}");
                        }
                        var associationInfo = propertyInfo.GetCustomAttribute<Association>();
                        var target = (DBObject)propertyInfo.GetValue(obj);
                        if (target == null)
                        {
                            var indexPropName = propertyInfo.Name + "Index";
                            var indexProp = type.GetProperty(indexPropName);
                            if (indexProp == null)
                            {
                                throw new NotSupportedException($"Type {type.FullName} miss Index property of {propertyInfo.Name}");
                            }

                            if (indexProp.PropertyType != typeof(int))
                            {
                                throw new NotSupportedException($"Type {type.FullName} Index property of {propertyInfo.Name} must be int");
                            }

                            var index = (int)indexProp.GetValue(obj);
                            target = GetObject(propertyInfo.PropertyType, index);
                        }

                        if(target == null) continue;

                        var targetType = target.GetType();
                        var targetPropertyInfo = targetType.GetProperty(associationInfo.Identity);
                        if (targetPropertyInfo == null)
                        {
                            throw new NotSupportedException($"Can not Find target property {associationInfo.Identity} on {targetType.FullName}");
                        }
                        var targetAssociationInfo = targetPropertyInfo.GetCustomAttribute<Association>();
                        if(targetAssociationInfo == null) continue;
                        if (targetPropertyInfo.PropertyType == type)
                        {
                            break;
                        }
                        var genericType = typeof(DBBindingList<>).MakeGenericType(type);

                        if (targetPropertyInfo.PropertyType.IsGenericType &&
                            genericType.IsAssignableFrom(targetPropertyInfo.PropertyType) &&
                            targetPropertyInfo.PropertyType.GenericTypeArguments[0] == type)
                        {
                            var targetValue = (IBindingList)targetPropertyInfo.GetValue(target);
                            if (targetValue == null)
                            {
                                targetValue = (IBindingList)Activator.CreateInstance(genericType);
                            }
                            else
                            {
                                var added = false;
                                foreach (DBObject targetItem in targetValue)
                                {
                                    if (targetItem.Index == obj.Index)
                                    {
                                        added = true;
                                        break;
                                    }
                                }
                                if(added) continue;
                            }

                            targetValue.Add(obj);
                        }
                        else
                        {
                            throw new NotSupportedException($"Target property {associationInfo.Identity} on {targetType.FullName} type error");
                        }
                    }
                }
            }
        }
    }
}
