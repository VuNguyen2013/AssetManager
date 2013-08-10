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
                var item=new NavBarItem {Caption = assetGroupType.Name,CanDrag = true,Name = assetGroupType.Id};
                nbAssetsType.ItemLinks.Add(item);
                nbAssetsType.AddItem(); 
                
                
            }
            //init department

            var departmentUseds = ws.GetDepartmentUsed();
            foreach (var departmentUsed in departmentUseds)
            {
                var item = new NavBarItem {Caption = departmentUsed.Name, CanDrag = true, Name = departmentUsed.Id};
                nbDepartmentUsed.ItemLinks.Add(item);
                nbDepartmentUsed.AddItem();
            }

            //init all asset
            var assets = ws.GetAllAsset();
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
                //int currentMouseOverRow = nbAssets. dataGridView1.HitTest(e.X, e.Y).RowIndex;
                nbAssets.ContextMenu = contextMenu;
                this.ContextMenu = contextMenu;
            }
        }

        private void nbAssets_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            //if click on nbAssetType
            if (e.Link.Group.Name == nbAssetsType.Name)
            {
                var assets = ws.GetAssetByAssetGroupTypeId(e.Link.NavBar.Name);
                BindData(assets);
            }
            else
            {
                //if click on nbDepartmentUsed
                if (e.Link.Group.Name==nbDepartmentUsed.Name)
                {
                    var assets = ws.GetAssetByDepartmentUsedId(e.Link.Item.Name);
                    BindData(assets);
                }
            }
            
        }
        private void BindData(Asset[] asset)
        {
            var assetList = new List<Asset>(asset);
            var bindingList=new BindingList<Asset>();
            foreach (var assets in assetList)
            {
                bindingList.Add(assets);
            }
            gcAsset.DataSource = bindingList;
        }
    }
}