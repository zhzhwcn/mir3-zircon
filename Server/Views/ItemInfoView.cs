using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CsvHelper;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Library;
using Library.SystemModels;
using Server.Envir;

namespace Server.Views
{
    public partial class ItemInfoView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ItemInfoView()
        {
            InitializeComponent();

            ItemInfoGridControl.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            SetLookUpEdit.DataSource = SMain.Session.GetCollection<SetInfo>().Binding;

            ItemTypeImageComboBox.Items.AddEnum<ItemType>();
            RequiredClassImageComboBox.Items.AddEnum<RequiredClass>();
            RequiredGenderImageComboBox.Items.AddEnum<RequiredGender>();
            StatImageComboBox.Items.AddEnum<Stat>();
            RequiredTypeImageComboBox.Items.AddEnum<RequiredType>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(ItemInfoGridView);
            SMain.SetUpView(ItemStatsGridView);
            SMain.SetUpView(DropsGridView);
        }

        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<string> itemData = new List<string>();

            itemData.Add(GetLine(null));
            foreach (ItemInfo item in SMain.Session.GetCollection<ItemInfo>().Binding)
                itemData.Add(GetLine(item));

            string path = @"C:\Zircon Server\Data Works\Exports\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            File.WriteAllLines(path + "Items.csv", itemData);
        }

        public string GetLine(ItemInfo info)
        {
            StringBuilder builder = new StringBuilder();

            
            builder.Append((info?.ItemName ?? "Name") + ", ");
            builder.Append((info?.ItemType.ToString() ?? "Type") + ", ");

            if (info == null)
            {
                builder.Append("Required Class");
            }
            else
            {
                Type type = info.RequiredClass.GetType();

                MemberInfo[] infos = type.GetMember(info.RequiredClass.ToString());

                DescriptionAttribute description = infos[0].GetCustomAttribute<DescriptionAttribute>();

                builder.Append(description?.Description.Replace(",", "") ?? info.RequiredClass.ToString());
            }

            builder.Append(", ");

            builder.Append((info?.RequiredType.ToString() ?? "Required Type") + ", ");
            builder.Append((info?.RequiredAmount.ToString() ?? "Required Amount") + ", ");
            builder.Append((info?.Image.ToString("00000") ?? "Image") + ", ");
            builder.Append((info?.Weight.ToString() ?? "Weight") + ", ");
            builder.Append((info?.Durability.ToString() ?? "Durability") + ", ");
            builder.Append((info?.Rarity.ToString() ?? "Rarity") + ", ");

            builder.Append((info == null ? "AC" : string.Format("{0}-{1}", info.Stats[Stat.MinAC], info.Stats[Stat.MaxAC])) + ", ");
            builder.Append((info == null ? "MR" : string.Format("{0}-{1}", info.Stats[Stat.MinMR], info.Stats[Stat.MaxMR])) + ", ");
            builder.Append((info == null ? "DC" : string.Format("{0}-{1}", info.Stats[Stat.MinDC], info.Stats[Stat.MaxDC])) + ", ");
            builder.Append((info == null ? "MC" : string.Format("{0}-{1}", info.Stats[Stat.MinMC], info.Stats[Stat.MaxMC])) + ", ");
            builder.Append((info == null ? "SC" : string.Format("{0}-{1}", info.Stats[Stat.MinSC], info.Stats[Stat.MaxSC])) + ", ");
            builder.Append((info == null ? "Accuracy" : string.Format("+{0}", info.Stats[Stat.Accuracy])) + ", ");
            builder.Append((info == null ? "Agility" : string.Format("+{0}", info.Stats[Stat.Agility])) + ", ");
            builder.Append((info == null ? "Attack Speed" : string.Format("+{0}", info.Stats[Stat.AttackSpeed])) + ", ");
            builder.Append((info == null ? "Health" : string.Format("+{0}", info.Stats[Stat.Health])) + ", ");
            builder.Append((info == null ? "Mana" : string.Format("+{0}", info.Stats[Stat.Mana])) + ", ");
            builder.Append((info == null ? "Luck" : string.Format("+{0}", info.Stats[Stat.Luck])) + ", ");
            builder.Append((info == null ? "Experienc eRate" : string.Format("+{0}", info.Stats[Stat.ExperienceRate])) + ", ");
            builder.Append((info == null ? "Drop Rate" : string.Format("+{0}", info.Stats[Stat.DropRate])) + ", ");
            builder.Append((info == null ? "Gold Rate" : string.Format("+{0}", info.Stats[Stat.GoldRate])) + ", ");
            builder.Append((info == null ? "Skill Rate" : string.Format("+{0}", info.Stats[Stat.SkillRate])) + ", ");
            builder.Append((info == null ? "Duration" : string.Format("+{0}", info.Stats[Stat.Duration])) + ", ");
            builder.Append((info == null ? "Inventory Weight" : string.Format("+{0}", info.Stats[Stat.BagWeight])) + ", ");
            builder.Append((info == null ? "Wear Weight" : string.Format("+{0}", info.Stats[Stat.WearWeight])) + ", ");
            builder.Append((info == null ? "Hand Weight" : string.Format("+{0}", info.Stats[Stat.HandWeight])) + ", ");
            builder.Append((info == null ? "Life Steal" : string.Format("+{0}", info.Stats[Stat.LifeSteal])) + ", ");
            builder.Append((info == null ? "Fire Attack" : string.Format("+{0}", info.Stats[Stat.FireAttack])) + ", ");
            builder.Append((info == null ? "Ice Attack" : string.Format("+{0}", info.Stats[Stat.IceAttack])) + ", ");
            builder.Append((info == null ? "Lightning Attack" : string.Format("+{0}", info.Stats[Stat.LightningAttack])) + ", ");
            builder.Append((info == null ? "Wind Attack" : string.Format("+{0}", info.Stats[Stat.WindAttack])) + ", ");
            builder.Append((info == null ? "Holy Attack" : string.Format("+{0}", info.Stats[Stat.HolyAttack])) + ", ");
            builder.Append((info == null ? "Dark Attack" : string.Format("+{0}", info.Stats[Stat.DarkAttack])) + ", ");
            builder.Append((info == null ? "Phantom Attack" : string.Format("+{0}", info.Stats[Stat.PhantomAttack])) + ", ");


            return builder.ToString();
        }

        private void Import_ItemClick(object sender, ItemClickEventArgs e)
        {
            var collection = SMain.Session.GetCollection<ItemInfo>();
            //var items = SMain.Session.GetCollection<ItemInfo>().Binding;
            using (var reader = new StreamReader("AmzData/StdItems.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var name = csv.GetField("Name");
                    if (collection.Binding.Any(i => i.ItemName == name))
                    {
                        continue;
                    }

                    if (name.StartsWith("╔") || name.StartsWith("║") || name.StartsWith("╚"))
                    {
                        continue;
                    }

                    var mode = csv.GetField<int>("StdMode");
                    var need = csv.GetField<int>("Need");
                    var newItem = collection.CreateNewObject();
                    
                    newItem.ItemName = name;
                    newItem.ItemType = GetItemType(mode);
                    switch (need)
                    {
                        case 1:
                            newItem.RequiredClass = RequiredClass.Warrior;
                            break;
                        case 2:
                            newItem.RequiredClass = RequiredClass.Wizard;
                            break;
                        case 3:
                            newItem.RequiredClass = RequiredClass.Taoist;
                            break;
                        default:
                            newItem.RequiredClass = RequiredClass.All;
                            break;
                    }

                    switch (mode)
                    {
                        case 10:
                            newItem.RequiredGender = RequiredGender.Male;
                            break;
                        case 11:
                            newItem.RequiredGender = RequiredGender.Female;
                            break;
                        default:
                            newItem.RequiredGender = RequiredGender.None;
                            break;
                    }

                    newItem.RequiredType = RequiredType.Level;
                    newItem.RequiredAmount = csv.GetField<int>("NeedLevel");
                    newItem.Shape = csv.GetField<int>("Shape");
                    newItem.Effect = ItemEffect.None;
                    newItem.Image = 1042;
                    newItem.Durability = csv.GetField<int>("DuraMax");
                    newItem.Price = csv.GetField<int>("Price");
                    newItem.Weight = csv.GetField<int>("Weight");
                    var overlap = csv.GetField<int>("OverLap");
                    if (overlap > 0)
                    {
                        newItem.StackSize = csv.GetField<int>("Weight");
                    }

                    newItem.StartItem = false;
                    newItem.SellRate = 0.5M;
                    if (
                        newItem.ItemType == ItemType.Weapon ||
                        newItem.ItemType == ItemType.Armour ||
                        newItem.ItemType == ItemType.Necklace ||
                        newItem.ItemType == ItemType.Ring ||
                        newItem.ItemType == ItemType.Bracelet ||
                        newItem.ItemType == ItemType.Shoes
                    )
                    {
                        newItem.CanRepair = true;
                    }

                    newItem.CanSell = true;
                    newItem.CanStore = true;
                    newItem.CanTrade = true;
                    newItem.CanDrop = true;
                    newItem.CanDeathDrop = true;
                    newItem.Description = "";
                    newItem.Rarity = Rarity.Common;
                    newItem.CanAutoPot = false;
                    newItem.BuffIcon = 0;
                    newItem.PartCount = 0;
                }
            }
        }

        private ItemType GetItemType(int type)
        {
            switch (type)
            {
                case 0:
                case 2:
                    return ItemType.Consumable;
                case 3:
                    return ItemType.Scroll;
                case 4:
                    return ItemType.Book;
                case 5:
                case 6:
                    return ItemType.Weapon;
                case 7:
                    return ItemType.Nothing;
                case 10:
                case 11:
                    return ItemType.Armour;
                case 19:
                case 20:
                case 21:
                    return ItemType.Necklace;
                case 22:
                case 23:
                    return ItemType.Ring;
                case 24:
                case 26:
                    return ItemType.Bracelet;
                case 25:
                    return ItemType.Poison;
                case 31:
                    return ItemType.Consumable;
                case 30:
                case 40:
                case 41:
                case 42:
                case 44:
                case 46:
                case 57:
                case 59:
                case 62:
                    return ItemType.Nothing;
                case 43:
                    return ItemType.Ore;
                case 63:
                    return ItemType.Shoes;
                case 64:
                    return ItemType.Amulet;

            }
            throw new ArgumentException();
        }
    }
}