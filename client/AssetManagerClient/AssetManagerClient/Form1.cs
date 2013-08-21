using System;
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
        readonly Action<int> DelegateContent = delegate { };
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
            try
            {
                //init assets tab
                var assetGroupTypes = WebServices.GetAllAssetGroupType();
                foreach (var assetGroupType in assetGroupTypes)
                {
                    var item = new NavBarItem { Caption = assetGroupType.Name, CanDrag = true, Name = assetGroupType.Id };
                    nbAssetsType.ItemLinks.Add(item);
                    nbAssetsType.AddItem();


                }
                //init department

                var departmentUseds = WebServices.GetDepartmentUsed();
                foreach (var departmentUsed in departmentUseds)
                {
                    var item = new NavBarItem { Caption = departmentUsed.Name, CanDrag = true, Name = departmentUsed.Id };
                    nbDepartmentUsed.ItemLinks.Add(item);
                    nbDepartmentUsed.AddItem();
                }

                //init all asset

                var assets = WebServices.GetAllAsset();
                if (assets.RetCode == (int)AssetManagerCommon.CommonEnums.RetCode.SUCCESS)
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
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối tới server,vui lòng kiểm tra cài đặt mạng");
                throw;
            }
            
            
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void navBarControl1_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void nbAssets_LinkClicked(object sender, NavBarLinkEventArgs e)
        {

            //if click on nbAssetType
            if (e.Link.Group.Name == nbAssetsType.Name)
            {
                var assets = WebServices.GetAssetByAssetGroupTypeId(e.Link.NavBar.Name);
                BindData(assets.RetObject);
            }
            else
            {
                //if click on nbDepartmentUsed
                if (e.Link.Group.Name == nbDepartmentUsed.Name)
                {
                    var assets = WebServices.GetAssetByDepartmentUsedId(e.Link.Item.Name);
                    BindData(assets.RetObject);
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

        private void nbAssets_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                NavBarHitInfo hi = nbAssets.CalcHitInfo(e.Location);
                if (hi.InLink)
                {
                    if (hi.Link.Group.Name == nbAssetsType.Name)
                    {
                        var contextMenu = new ContextMenu();
                        contextMenu.MenuItems.Add("Thêm loại mới").Click += ContextMenuAddButton; ;
                        contextMenu.MenuItems.Add("Chỉnh sửa").Click += ContextMenuEditButton; ;
                        contextMenu.MenuItems.Add("Xóa").Click += ContextMenuDeleteButton;
                        //int currentMouseOverRow = nbAssets. dataGridView1.HitTest(e.X, e.Y).RowIndex;
                        nbAssets.ContextMenu = contextMenu;
                        ContextMenu = contextMenu;
                    }
                    else
                    {
                        var contextMenu = new ContextMenu();
                        contextMenu.MenuItems.Add("Thêm bộ phận mới").Click += ContextMenuAddButton;
                        contextMenu.MenuItems.Add("Chỉnh sửa").Click += ContextMenuEditButton;
                        contextMenu.MenuItems.Add("Xóa").Click += ContextMenuDeleteButton;
                        //int currentMouseOverRow = nbAssets. dataGridView1.HitTest(e.X, e.Y).RowIndex;
                        nbAssets.ContextMenu = contextMenu;
                        ContextMenu = contextMenu;
                    }
                }
            }
        }
        
        void ContextMenuAddButton(object sender, EventArgs e)
        {
            
            if (nbAssets.SelectedLink.Group.Name == nbAssetsType.Name)
            {
                var createForm = new GroupTypeInfo();
                createForm.DelegateContent((int)AssetManagerCommon.CommonEnums.FILTER.GROUP_TYPE,"");
                createForm.Show();
            }
            if (nbAssets.SelectedLink.Group.Name == nbDepartmentUsed.Name)
            {
                var createForm = new DepartmentInfo();
                createForm.DelegateContent((int)AssetManagerCommon.CommonEnums.ACTION.ADD,"");
                createForm.Show();
            }
        }
        void ContextMenuEditButton(object sender, EventArgs e)
        {

            if (nbAssets.SelectedLink.Group.Name == nbAssetsType.Name)
            {
                var createForm = new GroupTypeInfo();
                createForm.DelegateContent((int)AssetManagerCommon.CommonEnums.FILTER.GROUP_TYPE, nbAssets.SelectedLink.Item.Name);
                createForm.Show();
            }
            if (nbAssets.SelectedLink.Group.Name == nbDepartmentUsed.Name)
            {
                var createForm = new DepartmentInfo();
                createForm.DelegateContent((int)AssetManagerCommon.CommonEnums.ACTION.EDIT, nbAssets.SelectedLink.Item.Name);
                createForm.Show();
            }
        }
        void ContextMenuDeleteButton(object sender, EventArgs e)
        {
            if (nbAssets.SelectedLink.Group.Name == nbAssetsType.Name)
            {
                if (MessageBox.Show("Bạn muốn xóa loại tài sản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    WebServices.DelAssetGroupTypeById(nbAssets.SelectedLink.Item.Name);
                }
            }
            if (nbAssets.SelectedLink.Group.Name == nbDepartmentUsed.Name)
            {
                if (MessageBox.Show("Bạn muốn xóa bộ phận này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    WebServices.DelDepartmentUsedById(nbAssets.SelectedLink.Item.Name);
                }
            }
        }
    }
}