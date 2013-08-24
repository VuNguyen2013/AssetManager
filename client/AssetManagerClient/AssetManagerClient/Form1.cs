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
        public void InitContent()
        {
            try
            {
                //clear content
                nbAssetsType.ItemLinks.Clear();
                nbDepartmentUsed.ItemLinks.Clear();
                //init assets tab
                var assetGroups = WebServices.GetAllAssetGroup().RetObject;
                foreach (var assetGroup in assetGroups)
                {
                    var item = new NavBarItem { Caption = assetGroup.Name, CanDrag = true, Name = assetGroup.Id };
                    nbAssetsType.ItemLinks.Add(item);
                }
                //init department

                var departmentUseds = WebServices.GetAllDepartmentUsed().RetObject;
                foreach (var departmentUsed in departmentUseds)
                {
                    var item = new NavBarItem { Caption = departmentUsed.Name, CanDrag = true, Name = departmentUsed.Id };
                    nbDepartmentUsed.ItemLinks.Add(item);
                }

                //init all asset

                var assets = WebServices.GetAllAsset();
                if (assets.RetCode == (int)AssetManagerCommon.CommonEnums.RetCode.SUCCESS)
                {
                    Invoke(new Action(() => BindData(assets.RetObject)));
                    
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
                var assets = WebServices.GetAssetByAssetGroupId(e.Link.NavBar.Name);
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
            try
            {
                
                gcAsset.DataSource = asset;
            }
            catch (Exception exception)
            {
                
                
            }
            
    
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
                    nbAssets.SelectedLink = hi.Link;
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
                var createForm = new GroupTypeInfo(this);
                createForm.DelegateContent((int)AssetManagerCommon.CommonEnums.FILTER.GROUP_TYPE,"");
                createForm.ShowDialog();
            }
            if (nbAssets.SelectedLink.Group.Name == nbDepartmentUsed.Name)
            {
                var createForm = new DepartmentInfo(this);
                createForm.DelegateContent((int)AssetManagerCommon.CommonEnums.ACTION.ADD,"");
                createForm.ShowDialog();
            }
        }
        void ContextMenuEditButton(object sender, EventArgs e)
        {
            if (nbAssets.SelectedLink.Group.Name == nbAssetsType.Name)
            {
                var createForm = new GroupTypeInfo(this);
                createForm.DelegateContent((int)AssetManagerCommon.CommonEnums.FILTER.GROUP_TYPE, nbAssets.SelectedLink.Item.Name);
                createForm.ShowDialog();
            }
            if (nbAssets.SelectedLink.Group.Name == nbDepartmentUsed.Name)
            {
                var createForm = new DepartmentInfo(this);
                createForm.DelegateContent((int)AssetManagerCommon.CommonEnums.ACTION.EDIT, nbAssets.SelectedLink.Item.Name);
                createForm.ShowDialog();
            }
        }
        void ContextMenuDeleteButton(object sender, EventArgs e)
        {
            if (nbAssets.SelectedLink.Group.Name == nbAssetsType.Name)
            {
                if (MessageBox.Show("Bạn muốn xóa loại tài sản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    WebServices.DelAssetGroupById(nbAssets.SelectedLink.Item.Name);
                    InitContent();
                }
            }
            if (nbAssets.SelectedLink.Group.Name == nbDepartmentUsed.Name)
            {
                if (MessageBox.Show("Bạn muốn xóa bộ phận này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    WebServices.DelDepartmentUsedById(nbAssets.SelectedLink.Item.Name);
                    InitContent();
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var row=gvAsset.GetSelectedRows();
            var createForm = new NewAsset();
            //createForm.DelegateContent((int)AssetManagerCommon.CommonEnums.ACTION.EDIT, gvAsset.GetRowCellValue((int)row.GetValue(0), gvAsset.Columns[0]).ToString());
            createForm.ShowDialog();
        }

        private void gcAsset_Click(object sender, EventArgs e)
        {
            
        }

        private void gvAsset_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
        }

        private void gvAsset_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            MessageBox.Show(e.RowHandle.ToString());
            

            //label.Text = gvAsset.Rows[e.RowIndex].Cells["Your Coloumn name"].Value.ToString();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            var row = gvAsset.GetSelectedRows();
            string assetId=gvAsset.GetRowCellValue((int) row.GetValue(0), gvAsset.Columns[0]).ToString();
            if (assetId.Equals(""))
            {
                MessageBox.Show("Vui lòng chọn một tài sản");
            }
            else
            {
                if (MessageBox.Show("Bạn muốn xóa tài sản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    WebServices.DelAssetById(assetId);
                }
   
            }
         }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Environment.Exit(0);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form formExport=new Export();
            formExport.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form formAudit=new Audit();
            formAudit.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}