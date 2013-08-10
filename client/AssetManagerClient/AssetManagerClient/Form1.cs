﻿using System;
using System.Threading;
using System.Windows.Forms;
using AssetManagerClient.WebService;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraNavBar;


namespace AssetManagerClient
{
    public partial class Form1 : RibbonForm
    {
        public AssetManagerService WebServices=new AssetManagerService();
     
        public Form1()
        {
            Enabled = false;
            InitializeComponent();
            InitSkinGallery();
            var threadOnLoadPage = new Thread(InitContent);
            threadOnLoadPage.Start();
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        void InitContent()
        {
            //init assets tab
            var assetGroupTypes = WebServices.GetAllAssetGroupType();
            foreach (var assetGroupType in assetGroupTypes)
            {
                var item=new NavBarItem {Caption = assetGroupType.Name,CanDrag = true,Name = assetGroupType.Id};
                nbAssetsType.ItemLinks.Add(item);
                nbAssetsType.AddItem(); 
                
                
            }
            //init department

            var departmentUseds = WebServices.GetDepartmentUsed();
            foreach (var departmentUsed in departmentUseds)
            {
                var item = new NavBarItem {Caption = departmentUsed.Name, CanDrag = true, Name = departmentUsed.Id};
                nbDepartmentUsed.ItemLinks.Add(item);
                nbDepartmentUsed.AddItem();
            }

            //init all asset

            var assets = WebServices.GetAllAsset();
            if (assets.RetCode == (int) AssetManagerCommon.CommonEnums.RetCode.SUCCESS)
            {
                BindData(assets.RetObject);                
            }
            else
            {
                lblStatusAlert.Text = AssetManagerCommon.CommonFunction.GetMassageReturn(assets.RetCode);
            }
            Invoke(new Action(() =>
            {
                gpLoading.Hide();
                Enabled = true;
            }));
            
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
                ContextMenu = contextMenu;
            }
        }

        private void nbAssets_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            //if click on nbAssetType
            if (e.Link.Group.Name == nbAssetsType.Name)
            {
                var assets = WebServices.GetAssetByAssetGroupTypeId(e.Link.NavBar.Name);
                //BindData(assets);
            }
            else
            {
                //if click on nbDepartmentUsed
                if (e.Link.Group.Name==nbDepartmentUsed.Name)
                {
                    var assets = WebServices.GetAssetByDepartmentUsedId(e.Link.Item.Name);
                    //BindData(assets);
                }
            }
            
        }
        private void BindData(AssetData[] asset)
        {
            gcAsset.DataSource = asset;
    
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var newAssetForm = new NewAsset();
            newAssetForm.Show();
        }
    }
}