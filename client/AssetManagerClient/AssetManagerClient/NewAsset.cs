using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using AssetManagerClient.WebService;
using DevExpress.XtraPrinting.Native;

namespace AssetManagerClient
{
    public partial class NewAsset : DevExpress.XtraEditors.XtraForm
    {
        public AssetManagerService WebServices = new AssetManagerService();
        private List<string> _imagePathList=new List<string>();
        private string assetNumber = string.Empty;
        public NewAsset()
        {
            var random = new Random();
            assetNumber = random.Next(1000000, 9999999).ToString();
            InitializeComponent();
            var threadOnLoadPage = new Thread(InitContent);
            threadOnLoadPage.Start();
        }
        void InitContent()
        {
            txtAssetNumber.Text = assetNumber;
            //init Group
            var assetGroups = WebServices.GetAllAssetGroup();
            cbxItem cbxItem;
            foreach (var assetGroup in assetGroups)
            {
                cbxItem = new cbxItem {Text = assetGroup.Name, Id = assetGroup.Id};
                Invoke(new Action(() => cbAssetGroup.Items.Add(cbxItem)));
            }
            //init Department
            var assetDeparments = WebServices.GetDepartmentUsed();
            foreach (var assetDeparment in assetDeparments)
            {
                cbxItem = new cbxItem {Text = assetDeparment.Name, Id = assetDeparment.Id};
                Invoke(new Action(() => cbDepartmentUsed.Items.Add(cbxItem)));
                
            }

            //init Department
            var units = WebServices.GetAllUnit();
            foreach (var unit in units)
            {
                cbxItem = new cbxItem { Text = unit.Name, Id = unit.Id };
                Invoke(new Action(() => cbUnit.Items.Add(cbxItem)));
            }

            //init Status
            cbxItem = new cbxItem { Text = "Đang sữ dụng", Id = ((int)AssetManagerCommon.CommonEnums.STATUS.IN_USE).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbStatus.Items.Add(cbxItem)));
            cbxItem = new cbxItem { Text = "Đang lưu trong kho", Id = ((int)AssetManagerCommon.CommonEnums.STATUS.IN_STORAGE).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbStatus.Items.Add(cbxItem)));
            cbxItem = new cbxItem { Text = "Đang cho mượn", Id = ((int)AssetManagerCommon.CommonEnums.STATUS.LOANED_OUT).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbStatus.Items.Add(cbxItem)));
            cbxItem = new cbxItem { Text = "Đang sửa chữa", Id = ((int)AssetManagerCommon.CommonEnums.STATUS.OUT_FOR_REPAIR).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbStatus.Items.Add(cbxItem)));

            //init Status
            cbxItem = new cbxItem { Text = "Tốt", Id = ((int)AssetManagerCommon.CommonEnums.CONDITION.GOOD).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbCondition.Items.Add(cbxItem)));
            cbxItem = new cbxItem { Text = "Mới", Id = ((int)AssetManagerCommon.CommonEnums.CONDITION.NEW).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbCondition.Items.Add(cbxItem)));
            cbxItem = new cbxItem { Text = "Lỗi", Id = ((int)AssetManagerCommon.CommonEnums.CONDITION.FAIL).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbCondition.Items.Add(cbxItem)));
            cbxItem = new cbxItem { Text = "Kém", Id = ((int)AssetManagerCommon.CommonEnums.CONDITION.POOR).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbCondition.Items.Add(cbxItem)));

         

            Invoke(new Action(() =>
            {
                gpLoading.Hide();
                Enabled = true;
                cbStatus.SelectedIndex = 0;
                cbCondition.SelectedIndex = 0;
            }));
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            odImage.Multiselect = true;
            odImage.Filter = "JPEG Images|*.jpg|GIF Images|*.gif|BITMAPS|*.bmp";
            
            if (odImage.ShowDialog() == DialogResult.Cancel)
            {
                
            }
            else
            {
                var fileNames = odImage.FileNames;
                //isImage.Images = fileNames;
                foreach (var fileName in fileNames)
                {
                    isImage.Images.Add(Image.FromFile(@fileName));
                    if (!_imagePathList.Contains(fileName))
                    {
                        _imagePathList.Add(fileName);
                    }
                }
                isImage.AnimationTime = 400;
            }
            

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cbxCondition = cbCondition.Items[cbCondition.SelectedIndex] as cbxItem;
            var cbxDepartmentUsed = cbDepartmentUsed.Items[cbDepartmentUsed.SelectedIndex] as cbxItem;
            var cbxAssetGroup = cbAssetGroup.Items[cbAssetGroup.SelectedIndex] as cbxItem;
            var cbxStatus = cbStatus.Items[cbStatus.SelectedIndex] as cbxItem;
            var cbxUnit = cbUnit.Items[cbUnit.SelectedIndex] as cbxItem;

            if (txtName.Text == "" || txtSeries.Text == "" || cbxAssetGroup == null ||
                cbxDepartmentUsed == null || cbxUnit == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (txtAssetNumber.Text.Length == 7)
            {
                MessageBox.Show("Mã tài sản bao gồm 7 chữ số");
                return;
            }
            gpLoading.Description = "Đang tạo tài sản mới";
            gpLoading.Show();
            try
            {
                var result = WebServices.NewAsset("AS_" + txtAssetNumber.Text, txtName.Text, cbxAssetGroup.Id,
                                                  cbxUnit.Id, 1, "japan", 2013, cbxDepartmentUsed.Id,
                                                  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "U");
                if (result == (int) AssetManagerCommon.CommonEnums.RetCode.SUCCESS)
                {
                    //if success,upload image
                    gpLoading.Description = "Đang tải hình ảnh lên";
                    var ftp1 = AssetManagerCommon.ftp();
                    var ftp=AssetManagerCommon.ftp(Properties.Settings.Default.hostIP, Properties.Settings.Default.UsernameFtp,
                                           Properties.Settings.Default.PasswordFtp);

                    gpLoading.Hide();
                }
                else if (result == (int) AssetManagerCommon.CommonEnums.RetCode.SYSTEM_ERROR)
                {
                    MessageBox.Show("Lỗi hệ thống");
                    gpLoading.Hide();
                }
                else if (result == (int) AssetManagerCommon.CommonEnums.RetCode.OTHER)
                {
                    MessageBox.Show("Lỗi chưa xác định,vui lòng liên hệ quản trị viên");
                    gpLoading.Hide();
                }
                else if (result == (int) AssetManagerCommon.CommonEnums.RetCode.DATA_ALREADY_EXIST)
                {
                    MessageBox.Show("Mã tài sản đã tồn tại");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối tới server,vui lòng kiểm tra cài đặt mạng");
                gpLoading.Hide();
            }
        }

        private void rbManual_CheckedChanged(object sender, EventArgs e)
        {
            txtAssetNumber.Enabled = true;
        }

        private void rbAuto_CheckedChanged(object sender, EventArgs e)
        {
            txtAssetNumber.Enabled = false;
            txtAssetNumber.Text = assetNumber;
        }
    }
}