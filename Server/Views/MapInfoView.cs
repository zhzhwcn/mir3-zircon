using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Library;
using Library.SystemModels;
using Server.DBModels;
using Server.Envir;

namespace Server.Views
{
    public partial class MapInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MapInfoView()
        {
            InitializeComponent();

            MapInfoGridControl.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            MapInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;

            LightComboBox.Items.AddEnum<LightSetting>();
            DirectionImageComboBox.Items.AddEnum<MirDirection>();
            MapIconImageComboBox.Items.AddEnum<MapIcon>();
            StartClassImageComboBox.Items.AddEnum<RequiredClass>();
            RequiredClassImageComboBox.Items.AddEnum<RequiredClass>();
        }


        private void MapInfoView_Load(object sender, EventArgs e)
        {
            SMain.SetUpView(MapInfoGridView);
            SMain.SetUpView(GuardsGridView);
            SMain.SetUpView(RegionGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void ClearMapsButton_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void RenameMiniMapButton_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void EditButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MapViewer.CurrentViewer == null)
            {
                MapViewer.CurrentViewer = new MapViewer();
                MapViewer.CurrentViewer.Show();
            }

            MapViewer.CurrentViewer.BringToFront();

            GridView view = MapInfoGridControl.FocusedView as GridView;

            if (view == null) return;

            MapViewer.CurrentViewer.Save();

            MapViewer.CurrentViewer.MapRegion = view.GetFocusedRow() as MapRegion;
        }

        private void Import_ItemClick(object sender, ItemClickEventArgs e)
        {
            var data = File.ReadAllLines("AmzData/MapInfo.txt", Encoding.GetEncoding("GB2312"));
            var collection = SMain.Session.GetCollection<MapInfo>();
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
    }
}