using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AssetManagerClient.WebService;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraNavBar;


namespace AssetManagerClient
{
    public partial class Form1 : RibbonForm
    {
        public AssetManagerService ws=new AssetManagerService();
        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
            InitContent ();
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        void InitContent()
        {
            //init assets tab
            var assetGroupTypes = ws.GetAllAssetGroupType();
            foreach (var assetGroupType in assetGroupTypes)
            {
                var item=new NavBarItem {Caption = assetGroupType.Name};
                nbAssetsType.ItemLinks.Add(item);
                nbAssetsType.AddItem(); 
                
                
            }
            //init department
            /*
            var assetGroupTypes = ws.getall();
            foreach (var assetGroupType in assetGroupTypes)
            {
                var item = new NavBarItem();
                item.Caption = assetGroupType.Name;
                nbAssetsType.ItemLinks.Add(item);
                nbAssetsType.AddItem();
            }*/
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void navBarControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var contextMenu = new ContextMenu();
                contextMenu.MenuItems.Add("Thêm loại mới");
                contextMenu.MenuItems.Add("Chỉnh sửa");
                contextMenu.MenuItems.Add("Xóa");
                int currentMouseOverRow = nbAssets. dataGridView1.HitTest(e.X, e.Y).RowIndex;
            }
        }

    }
}