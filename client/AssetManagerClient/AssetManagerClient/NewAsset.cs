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
        public NewAsset()
        {
            
            InitializeComponent();
            var threadOnLoadPage = new Thread(InitContent);
            threadOnLoadPage.Start();
        }
        void InitContent()
        {
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
    }
}