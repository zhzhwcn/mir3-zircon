﻿namespace Server.Views
{
    partial class MonsterInfoView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonsterInfoView));
            this.MonsterInfoStatsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StatComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MonsterInfoGridControl = new DevExpress.XtraGrid.GridControl();
            this.RespawnsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MapLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDelay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpread = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DropsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colChance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MonsterInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonsterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MonsterImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExperience = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colViewRange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoolEye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttackDelay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoveDelay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBoss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUndead = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.SaveButton = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ImportBtn = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterInfoStatsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterInfoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RespawnsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DropsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // MonsterInfoStatsGridView
            // 
            this.MonsterInfoStatsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStat,
            this.colAmount});
            this.MonsterInfoStatsGridView.DetailHeight = 377;
            this.MonsterInfoStatsGridView.GridControl = this.MonsterInfoGridControl;
            this.MonsterInfoStatsGridView.Name = "MonsterInfoStatsGridView";
            this.MonsterInfoStatsGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.MonsterInfoStatsGridView.OptionsView.EnableAppearanceOddRow = true;
            this.MonsterInfoStatsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.MonsterInfoStatsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.MonsterInfoStatsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colStat
            // 
            this.colStat.ColumnEdit = this.StatComboBox;
            this.colStat.FieldName = "Stat";
            this.colStat.MinWidth = 23;
            this.colStat.Name = "colStat";
            this.colStat.Visible = true;
            this.colStat.VisibleIndex = 0;
            this.colStat.Width = 87;
            // 
            // StatComboBox
            // 
            this.StatComboBox.AutoHeight = false;
            this.StatComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatComboBox.Name = "StatComboBox";
            // 
            // colAmount
            // 
            this.colAmount.FieldName = "Amount";
            this.colAmount.MinWidth = 23;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 1;
            this.colAmount.Width = 87;
            // 
            // MonsterInfoGridControl
            // 
            this.MonsterInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.MonsterInfoStatsGridView;
            gridLevelNode1.RelationName = "MonsterInfoStats";
            gridLevelNode2.LevelTemplate = this.RespawnsGridView;
            gridLevelNode2.RelationName = "Respawns";
            gridLevelNode3.LevelTemplate = this.DropsGridView;
            gridLevelNode3.RelationName = "Drops";
            this.MonsterInfoGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3});
            this.MonsterInfoGridControl.Location = new System.Drawing.Point(0, 147);
            this.MonsterInfoGridControl.MainView = this.MonsterInfoGridView;
            this.MonsterInfoGridControl.MenuManager = this.ribbon;
            this.MonsterInfoGridControl.Name = "MonsterInfoGridControl";
            this.MonsterInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.MonsterImageComboBox,
            this.StatComboBox,
            this.ItemLookUpEdit,
            this.MapLookUpEdit});
            this.MonsterInfoGridControl.ShowOnlyPredefinedDetails = true;
            this.MonsterInfoGridControl.Size = new System.Drawing.Size(904, 410);
            this.MonsterInfoGridControl.TabIndex = 2;
            this.MonsterInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.RespawnsGridView,
            this.DropsGridView,
            this.MonsterInfoGridView,
            this.MonsterInfoStatsGridView});
            // 
            // RespawnsGridView
            // 
            this.RespawnsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMap,
            this.colX,
            this.colY,
            this.colDelay,
            this.colSpread,
            this.colCount,
            this.gridColumn2});
            this.RespawnsGridView.DetailHeight = 377;
            this.RespawnsGridView.GridControl = this.MonsterInfoGridControl;
            this.RespawnsGridView.Name = "RespawnsGridView";
            this.RespawnsGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.RespawnsGridView.OptionsView.EnableAppearanceOddRow = true;
            this.RespawnsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.RespawnsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.RespawnsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colMap
            // 
            this.colMap.ColumnEdit = this.MapLookUpEdit;
            this.colMap.FieldName = "Map";
            this.colMap.MinWidth = 23;
            this.colMap.Name = "colMap";
            this.colMap.Visible = true;
            this.colMap.VisibleIndex = 0;
            this.colMap.Width = 87;
            // 
            // MapLookUpEdit
            // 
            this.MapLookUpEdit.AutoHeight = false;
            this.MapLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.MapLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.MapLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FileName", "File Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description")});
            this.MapLookUpEdit.DisplayMember = "Description";
            this.MapLookUpEdit.Name = "MapLookUpEdit";
            this.MapLookUpEdit.NullText = "[Map is null]";
            // 
            // colX
            // 
            this.colX.FieldName = "X";
            this.colX.MinWidth = 23;
            this.colX.Name = "colX";
            this.colX.Visible = true;
            this.colX.VisibleIndex = 1;
            this.colX.Width = 87;
            // 
            // colY
            // 
            this.colY.FieldName = "Y";
            this.colY.MinWidth = 23;
            this.colY.Name = "colY";
            this.colY.Visible = true;
            this.colY.VisibleIndex = 2;
            this.colY.Width = 87;
            // 
            // colDelay
            // 
            this.colDelay.FieldName = "Delay";
            this.colDelay.MinWidth = 23;
            this.colDelay.Name = "colDelay";
            this.colDelay.Visible = true;
            this.colDelay.VisibleIndex = 3;
            this.colDelay.Width = 87;
            // 
            // colSpread
            // 
            this.colSpread.FieldName = "Spread";
            this.colSpread.MinWidth = 23;
            this.colSpread.Name = "colSpread";
            this.colSpread.Visible = true;
            this.colSpread.VisibleIndex = 4;
            this.colSpread.Width = 87;
            // 
            // colCount
            // 
            this.colCount.FieldName = "Count";
            this.colCount.MinWidth = 23;
            this.colCount.Name = "colCount";
            this.colCount.Visible = true;
            this.colCount.VisibleIndex = 5;
            this.colCount.Width = 87;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "DropSet";
            this.gridColumn2.MinWidth = 23;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            this.gridColumn2.Width = 87;
            // 
            // DropsGridView
            // 
            this.DropsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColItem,
            this.colChance,
            this.colDAmount,
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn7});
            this.DropsGridView.DetailHeight = 377;
            this.DropsGridView.GridControl = this.MonsterInfoGridControl;
            this.DropsGridView.Name = "DropsGridView";
            this.DropsGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.DropsGridView.OptionsView.EnableAppearanceOddRow = true;
            this.DropsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.DropsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.DropsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // ColItem
            // 
            this.ColItem.ColumnEdit = this.ItemLookUpEdit;
            this.ColItem.FieldName = "Item";
            this.ColItem.MinWidth = 23;
            this.ColItem.Name = "ColItem";
            this.ColItem.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.ColItem.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.ColItem.Visible = true;
            this.ColItem.VisibleIndex = 0;
            this.ColItem.Width = 87;
            // 
            // ItemLookUpEdit
            // 
            this.ItemLookUpEdit.AutoHeight = false;
            this.ItemLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.ItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName", "Item Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemType", "Item Type"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "Price"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StackSize", "Stack Size")});
            this.ItemLookUpEdit.DisplayMember = "ItemName";
            this.ItemLookUpEdit.Name = "ItemLookUpEdit";
            this.ItemLookUpEdit.NullText = "[Item is null]";
            // 
            // colChance
            // 
            this.colChance.FieldName = "Chance";
            this.colChance.MinWidth = 23;
            this.colChance.Name = "colChance";
            this.colChance.Visible = true;
            this.colChance.VisibleIndex = 1;
            this.colChance.Width = 87;
            // 
            // colDAmount
            // 
            this.colDAmount.FieldName = "Amount";
            this.colDAmount.MinWidth = 23;
            this.colDAmount.Name = "colDAmount";
            this.colDAmount.Visible = true;
            this.colDAmount.VisibleIndex = 2;
            this.colDAmount.Width = 87;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "DropSet";
            this.gridColumn1.MinWidth = 23;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 87;
            // 
            // gridColumn6
            // 
            this.gridColumn6.FieldName = "PartOnly";
            this.gridColumn6.MinWidth = 23;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 87;
            // 
            // gridColumn7
            // 
            this.gridColumn7.FieldName = "EasterEvent";
            this.gridColumn7.MinWidth = 23;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 87;
            // 
            // MonsterInfoGridView
            // 
            this.MonsterInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMonsterName,
            this.colImage,
            this.colAI,
            this.colLevel,
            this.colExperience,
            this.colViewRange,
            this.colCoolEye,
            this.colAttackDelay,
            this.colMoveDelay,
            this.colIsBoss,
            this.colUndead,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.MonsterInfoGridView.DetailHeight = 377;
            this.MonsterInfoGridView.GridControl = this.MonsterInfoGridControl;
            this.MonsterInfoGridView.Name = "MonsterInfoGridView";
            this.MonsterInfoGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.MonsterInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.MonsterInfoGridView.OptionsView.EnableAppearanceOddRow = true;
            this.MonsterInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.MonsterInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.MonsterInfoGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colMonsterName
            // 
            this.colMonsterName.FieldName = "MonsterName";
            this.colMonsterName.MinWidth = 23;
            this.colMonsterName.Name = "colMonsterName";
            this.colMonsterName.Visible = true;
            this.colMonsterName.VisibleIndex = 0;
            this.colMonsterName.Width = 87;
            // 
            // colImage
            // 
            this.colImage.ColumnEdit = this.MonsterImageComboBox;
            this.colImage.FieldName = "Image";
            this.colImage.MinWidth = 23;
            this.colImage.Name = "colImage";
            this.colImage.Visible = true;
            this.colImage.VisibleIndex = 1;
            this.colImage.Width = 87;
            // 
            // MonsterImageComboBox
            // 
            this.MonsterImageComboBox.AutoHeight = false;
            this.MonsterImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.MonsterImageComboBox.Name = "MonsterImageComboBox";
            // 
            // colAI
            // 
            this.colAI.FieldName = "AI";
            this.colAI.MinWidth = 23;
            this.colAI.Name = "colAI";
            this.colAI.Visible = true;
            this.colAI.VisibleIndex = 2;
            this.colAI.Width = 87;
            // 
            // colLevel
            // 
            this.colLevel.FieldName = "Level";
            this.colLevel.MinWidth = 23;
            this.colLevel.Name = "colLevel";
            this.colLevel.Visible = true;
            this.colLevel.VisibleIndex = 3;
            this.colLevel.Width = 87;
            // 
            // colExperience
            // 
            this.colExperience.FieldName = "Experience";
            this.colExperience.MinWidth = 23;
            this.colExperience.Name = "colExperience";
            this.colExperience.Visible = true;
            this.colExperience.VisibleIndex = 4;
            this.colExperience.Width = 87;
            // 
            // colViewRange
            // 
            this.colViewRange.FieldName = "ViewRange";
            this.colViewRange.MinWidth = 23;
            this.colViewRange.Name = "colViewRange";
            this.colViewRange.Visible = true;
            this.colViewRange.VisibleIndex = 5;
            this.colViewRange.Width = 87;
            // 
            // colCoolEye
            // 
            this.colCoolEye.FieldName = "CoolEye";
            this.colCoolEye.MinWidth = 23;
            this.colCoolEye.Name = "colCoolEye";
            this.colCoolEye.Visible = true;
            this.colCoolEye.VisibleIndex = 6;
            this.colCoolEye.Width = 87;
            // 
            // colAttackDelay
            // 
            this.colAttackDelay.FieldName = "AttackDelay";
            this.colAttackDelay.MinWidth = 23;
            this.colAttackDelay.Name = "colAttackDelay";
            this.colAttackDelay.Visible = true;
            this.colAttackDelay.VisibleIndex = 7;
            this.colAttackDelay.Width = 87;
            // 
            // colMoveDelay
            // 
            this.colMoveDelay.FieldName = "MoveDelay";
            this.colMoveDelay.MinWidth = 23;
            this.colMoveDelay.Name = "colMoveDelay";
            this.colMoveDelay.Visible = true;
            this.colMoveDelay.VisibleIndex = 8;
            this.colMoveDelay.Width = 87;
            // 
            // colIsBoss
            // 
            this.colIsBoss.FieldName = "IsBoss";
            this.colIsBoss.MinWidth = 23;
            this.colIsBoss.Name = "colIsBoss";
            this.colIsBoss.Visible = true;
            this.colIsBoss.VisibleIndex = 9;
            this.colIsBoss.Width = 87;
            // 
            // colUndead
            // 
            this.colUndead.FieldName = "Undead";
            this.colUndead.MinWidth = 23;
            this.colUndead.Name = "colUndead";
            this.colUndead.Visible = true;
            this.colUndead.VisibleIndex = 10;
            this.colUndead.Width = 87;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "CanPush";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 11;
            this.gridColumn3.Width = 87;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "CanTame";
            this.gridColumn4.MinWidth = 23;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 12;
            this.gridColumn4.Width = 87;
            // 
            // gridColumn5
            // 
            this.gridColumn5.FieldName = "Flag";
            this.gridColumn5.MinWidth = 23;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 13;
            this.gridColumn5.Width = 87;
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.SaveButton,
            this.ImportBtn});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(904, 147);
            // 
            // SaveButton
            // 
            this.SaveButton.Caption = "Save Database";
            this.SaveButton.Id = 1;
            this.SaveButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.ImageOptions.Image")));
            this.SaveButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.ImageOptions.LargeImage")));
            this.SaveButton.LargeWidth = 60;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveButton_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.SaveButton);
            this.ribbonPageGroup1.ItemLinks.Add(this.ImportBtn);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Saving";
            // 
            // ImportBtn
            // 
            this.ImportBtn.Caption = "Import";
            this.ImportBtn.Id = 2;
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ImportBtn_ItemClick);
            // 
            // MonsterInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 557);
            this.Controls.Add(this.MonsterInfoGridControl);
            this.Controls.Add(this.ribbon);
            this.Name = "MonsterInfoView";
            this.Ribbon = this.ribbon;
            this.Text = "Monster Info";
            ((System.ComponentModel.ISupportInitialize)(this.MonsterInfoStatsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterInfoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RespawnsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DropsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonsterImageComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraGrid.GridControl MonsterInfoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView MonsterInfoGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView MonsterInfoStatsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colStat;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox StatComboBox;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colMonsterName;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox MonsterImageComboBox;
        private DevExpress.XtraGrid.Columns.GridColumn colAI;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colExperience;
        private DevExpress.XtraGrid.Columns.GridColumn colViewRange;
        private DevExpress.XtraGrid.Columns.GridColumn colCoolEye;
        private DevExpress.XtraGrid.Columns.GridColumn colAttackDelay;
        private DevExpress.XtraGrid.Columns.GridColumn colMoveDelay;
        private DevExpress.XtraGrid.Views.Grid.GridView RespawnsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colMap;
        private DevExpress.XtraGrid.Columns.GridColumn colX;
        private DevExpress.XtraGrid.Columns.GridColumn colY;
        private DevExpress.XtraGrid.Columns.GridColumn colDelay;
        private DevExpress.XtraGrid.Columns.GridColumn colSpread;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
        private DevExpress.XtraGrid.Views.Grid.GridView DropsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn ColItem;
        private DevExpress.XtraGrid.Columns.GridColumn colChance;
        private DevExpress.XtraGrid.Columns.GridColumn colDAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MapLookUpEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBoss;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colUndead;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraBars.BarButtonItem ImportBtn;
    }
}