using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using DevExpress.XtraBars;
using Library;
using Library.SystemModels;
using MirDB;
using Server.Envir;

namespace Server.Views
{
    public partial class MonsterInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MonsterInfoView()
        {
            InitializeComponent();

            MonsterInfoGridControl.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;

            MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;

            MonsterImageComboBox.Items.AddEnum<MonsterImage>();
            StatComboBox.Items.AddEnum<Stat>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(MonsterInfoGridView);
            SMain.SetUpView(MonsterInfoStatsGridView);
            SMain.SetUpView(DropsGridView);
            SMain.SetUpView(RespawnsGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void ImportBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            var collection = SMain.Session.GetCollection<MonsterInfo>();
            var dropCollection = SMain.Session.GetCollection<DropInfo>();
            var itemCollection = SMain.Session.GetCollection<ItemInfo>();
            using (var reader = new StreamReader("AmzData/Monster.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var name = csv.GetField("Name");
                    if (name.StartsWith("=") || collection.Binding.Any(m => m.MonsterName == name))
                    {
                        continue;
                    }

                    var monster = collection.CreateNewObject();
                    monster.MonsterName = name;
                    monster.Image = MonsterImage.Scarecrow;
                    monster.AI = 0;
                    monster.Level = csv.GetField<int>("Lvl");
                    monster.ViewRange = 9;
                    monster.CoolEye = csv.GetField<int>("CoolEye");
                    monster.Experience = csv.GetField<int>("Exp");
                    monster.Undead = csv.GetField<bool>("Undead");
                    monster.CanPush = true;
                    monster.CanTame = true;
                    monster.IsBoss = false;
                    monster.Flag = MonsterFlag.None;

                    monster.AttackDelay = csv.GetField<int>("ATTACK_SPD");
                    monster.MoveDelay = csv.GetField<int>("WALK_SPD");
                    if (File.Exists($"AmzData/MonItems/{name}.txt"))
                    {
                        var dropList = File.ReadAllLines($"AmzData/MonItems/{name}.txt", Encoding.GetEncoding("GB2312"));
                        for (var index = 0; index < dropList.Length; index++)
                        {
                            var s = dropList[index];
                            if (string.IsNullOrEmpty(s)) continue;
                            if (s.StartsWith("#")) continue;
                            if (s.StartsWith("("))
                            {
                                while (s != ")")
                                {
                                    s = dropList[index++];
                                }

                                s = dropList[index];
                            }

                            var info = s.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                            if(info.Length < 2) continue;
                            var item = itemCollection.Binding.FirstOrDefault(i => i.ItemName == info[1]);
                            if (item == null)
                            {
                                SEnvir.Log($"item not found: {info[1]}");
                                continue;
                            }
                            var drop = dropCollection.CreateNewObject();
                            drop.Monster = monster;
                            drop.Item = item;
                            if (info.Length == 3)
                            {
                                drop.Amount = int.Parse(info[2]);
                            }
                            else
                            {
                                drop.Amount = 1;
                            }

                            drop.Chance = int.Parse(info[0].Replace("1/", ""));
                            drop.DropSet = 0;
                            drop.PartOnly = false;
                            drop.EasterEvent = false;
                            monster.Drops.Add(drop);
                        }
                    }
                }
            }
        }
    }
}