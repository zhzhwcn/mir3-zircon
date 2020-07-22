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
using Library;
using Library.SystemModels;

namespace Server.Views
{
    public partial class SafeZoneInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SafeZoneInfoView()
        {
            InitializeComponent();

            SafeZoneGridControl.DataSource = SMain.Session.GetCollection<SafeZoneInfo>().Binding;
            RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(SafeZoneGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void Import_ItemClick(object sender, ItemClickEventArgs e)
        {
            var data = File.ReadAllLines($"AmzData/StartPoint.txt", Encoding.GetEncoding("GB2312"));
            var collection = SMain.Session.GetCollection<SafeZoneInfo>();
            var regionCollection = SMain.Session.GetCollection<MapRegion>();
            var mapCollection = SMain.Session.GetCollection<MapInfo>();
            foreach (var s in data)
            {
                if(s.StartsWith(";")) continue;
                var info = s.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var map = mapCollection.Binding.FirstOrDefault(m => m.FileName == info[0]);
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
                //safezone.StartClass = RequiredClass.All;
            }
        }
    }
}