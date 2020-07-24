using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Library.SystemModels;

namespace Server.Views
{
    public partial class RespawnInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RespawnInfoView()
        {
            InitializeComponent();

            RespawnInfoGridControl.DataSource = SMain.Session.GetCollection<RespawnInfo>().Binding;

            MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(RespawnInfoGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void Import_ItemClick(object sender, ItemClickEventArgs e)
        {
            var data = File.ReadAllLines("AmzData/MonGen.txt", Encoding.GetEncoding("GB2312"));
            var collection = SMain.Session.GetCollection<RespawnInfo>();
            var regionCollection = SMain.Session.GetCollection<MapRegion>();
            var mapCollection = SMain.Session.GetCollection<MapInfo>();
            var monsterCollection = SMain.Session.GetCollection<MonsterInfo>();
            foreach (var s in data)
            {
                if (s.StartsWith(";") || string.IsNullOrWhiteSpace(s)) continue;
                var info = s.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var map = mapCollection.Binding.FirstOrDefault(m => m.FileName == info[0]);
                if (map == null)
                {
                    map = mapCollection.Binding.FirstOrDefault(m => m.FileName.StartsWith(info[0] + "|"));
                }
                var x = int.Parse(info[1]);
                var y = int.Parse(info[2]);
                var monster = monsterCollection.Binding.FirstOrDefault(m => m.MonsterName == info[3]);
                var size = int.Parse(info[4]);
                var count = int.Parse(info[5]);
                var time = int.Parse(info[6]);
                var region = regionCollection.CreateNewObject();
                region.Map = map;
                var pointList = new List<Point>();
                for (int i = x - size; i <= x + size; i++)
                {
                    for (int j = y - size; j <= y + size; j++)
                    {
                        pointList.Add(new Point(i, j));
                    }
                }

                region.PointRegion = pointList.ToArray();
                region.Description = $"刷怪 - {monster.MonsterName}";
                map.Regions.Add(region);
                var respawnInfo = collection.CreateNewObject();
                respawnInfo.Region = region;
                respawnInfo.Monster = monster;
                respawnInfo.EventSpawn = false;
                respawnInfo.Delay = time;
                respawnInfo.Count = count;
                respawnInfo.DropSet = 0;
                respawnInfo.Announce = false;
                respawnInfo.EasterEventChance = 0;
                monster.Respawns.Add(respawnInfo);
                //safezone.StartClass = RequiredClass.All;
            }
        }
    }
}