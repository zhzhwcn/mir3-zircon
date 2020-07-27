using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.XtraBars;
using Library;
using Library.SystemModels;

namespace Server.Views
{
    public partial class MovementInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MovementInfoView()
        {
            InitializeComponent();

            MovementGridControl.DataSource = SMain.Session.GetCollection<MovementInfo>().Binding;



            MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            SpawnLookUpEdit.DataSource = SMain.Session.GetCollection<RespawnInfo>().Binding;

            MapIconImageComboBox.Items.AddEnum<MapIcon>();
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(MovementGridView);
        }

        private void Import_ItemClick(object sender, ItemClickEventArgs e)
        {
            var data = File.ReadAllLines("AmzData/MapInfo.txt", Encoding.GetEncoding("GB2312"));
            var collection = SMain.Session.GetCollection<MovementInfo>();
            var mapCollection = SMain.Session.GetCollection<MapInfo>();
            var regionCollection = SMain.Session.GetCollection<MapRegion>();
            foreach (var s in data)
            {
                if (!s.Contains("->") || s.StartsWith(";")) continue;
                var info = s.Split(new[] { " ", "\t" , ","}, StringSplitOptions.RemoveEmptyEntries);

                var mapFrom = mapCollection.Binding.FirstOrDefault(m =>
                    m.FileName == info[0] || m.FileName.StartsWith(info[0] + "|"));
                var mapTo = mapCollection.Binding.FirstOrDefault(m =>
                    m.FileName == info[4] || m.FileName.StartsWith(info[4] + "|"));
                if (mapTo == null || mapFrom == null)
                {
                    throw new Exception();
                }

                var regionFrom = regionCollection.CreateNewObject();
                regionFrom.Map = mapFrom;
                regionFrom.PointRegion = new []{new Point(int.Parse(info[1]), int.Parse(info[2]))};
                regionFrom.Description = $"出口 -> {mapTo.Description}";
                mapFrom.Regions.Add(regionFrom);
                var regionTo = regionCollection.CreateNewObject();
                regionTo.Map = mapFrom;
                regionTo.PointRegion = new[] { new Point(int.Parse(info[5]), int.Parse(info[6])) };
                regionTo.Description = $"入口 -> {mapFrom.Description}";
                mapTo.Regions.Add(regionTo);

                var movement = collection.CreateNewObject();
                movement.RequiredClass = RequiredClass.All;
                movement.Effect = MovementEffect.None;
                movement.Icon = MapIcon.None;
                movement.DestinationRegion = regionTo;
                movement.SourceRegion = regionFrom;
            }
        }
    }
}