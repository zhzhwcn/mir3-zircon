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
    public partial class NPCInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public NPCInfoView()
        {
            InitializeComponent();

            NPCInfoGridControl.DataSource = SMain.Session.GetCollection<NPCInfo>().Binding;
            RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            PageLookUpEdit.DataSource = SMain.Session.GetCollection<NPCPage>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(NPCInfoGridView);
        }
        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void Import_ItemClick(object sender, ItemClickEventArgs e)
        {
            var data = File.ReadAllLines("AmzData/MerChant.txt", Encoding.GetEncoding("GB2312"));
            var collection = SMain.Session.GetCollection<NPCInfo>();
            var mapCollection = SMain.Session.GetCollection<MapInfo>();
            var regionCollection = SMain.Session.GetCollection<MapRegion>();
            var defaultPage = SMain.Session.GetCollection<NPCPage>().CreateNewObject();
            defaultPage.Description = "Default";
            defaultPage.DialogType = NPCDialogType.None;
            defaultPage.Say = "你好啊";
            foreach (var s in data)
            {
                if(s.StartsWith(";") || string.IsNullOrWhiteSpace(s)) continue;
                var info = s.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                var map = mapCollection.Binding.FirstOrDefault(m =>
                    m.FileName == info[1] || m.FileName.StartsWith(info[1] + "|"));
                if (map == null)
                {
                    throw new Exception();
                }

                var npc = collection.CreateNewObject();
                npc.EntryPage = defaultPage;
                npc.Image = 0;
                npc.NPCName = info[4];
                var region = regionCollection.CreateNewObject();
                region.Map = map;
                region.PointRegion = new[] { new Point(int.Parse(info[2]), int.Parse(info[3])) };
                region.Description = $"NPC:{npc.NPCName}";
                npc.Region = region;
                map.Regions.Add(region);
            }
        }
    }
}