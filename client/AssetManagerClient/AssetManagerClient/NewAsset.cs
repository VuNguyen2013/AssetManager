using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using AssetManagerClient.WebService;
using AssetManagerCommon;
using DevExpress.XtraPrinting.Native;
using FtpLib;
using Image = System.Drawing.Image;

namespace AssetManagerClient
{
    public partial class NewAsset : DevExpress.XtraEditors.XtraForm
    {
        public AssetManagerService WebServices = new AssetManagerService();
        private List<string> _imagePathList=new List<string>();
        private string assetNumber = string.Empty;
        private Random random = new Random();
        private int _action;
        private string _id;
       
        public NewAsset()
        {
            
            assetNumber = random.Next(1000000, 9999999).ToString();
            InitializeComponent();
            InitContent();
        }
        void InitContent()
        {
            txtAssetNumber.Text = assetNumber;
            //init Group
            var assetGroups = WebServices.GetAllAssetGroup().RetObject;
            cbxItem cbxItem;
            foreach (var assetGroup in assetGroups)
            {
                cbxItem = new cbxItem {Text = assetGroup.Name, Id = assetGroup.Id};
                cbAssetGroup.Items.Add(cbxItem);
            }
            //init Department
            var assetDeparments = WebServices.GetAllDepartmentUsed().RetObject;
            foreach (var assetDeparment in assetDeparments)
            {
                cbxItem = new cbxItem {Text = assetDeparment.Name, Id = assetDeparment.Id};
                cbDepartmentUsed.Items.Add(cbxItem);
                
            }

            //init Department
            var units = WebServices.GetAllUnit().RetObject;
            foreach (var unit in units)
            {
                cbxItem = new cbxItem { Text = unit.Name, Id = unit.Id };
                cbUnit.Items.Add(cbxItem);
            }

            //init Department
            var partners = WebServices.GetAllPartner().RetObject;
            foreach (var partner in partners)
            {
                cbxItem = new cbxItem { Text = partner.Name, Id = partner.Id };
                cbPartner.Items.Add(cbxItem);
            }

            //init Status
            cbxItem = new cbxItem { Text = "Đang sữ dụng", Id = ((int)CommonEnums.STATUS.IN_USE).ToString(CultureInfo.InvariantCulture) };
            cbStatus.Items.Add(cbxItem);
            cbxItem = new cbxItem { Text = "Đang lưu trong kho", Id = ((int)CommonEnums.STATUS.IN_STORAGE).ToString(CultureInfo.InvariantCulture) };
            cbStatus.Items.Add(cbxItem);
            cbxItem = new cbxItem { Text = "Đang cho mượn", Id = ((int)CommonEnums.STATUS.LOANED_OUT).ToString(CultureInfo.InvariantCulture) };
            cbStatus.Items.Add(cbxItem);
            cbxItem = new cbxItem { Text = "Đang sửa chữa", Id = ((int)CommonEnums.STATUS.OUT_FOR_REPAIR).ToString(CultureInfo.InvariantCulture) };
            cbStatus.Items.Add(cbxItem);

            //init Status
            cbxItem = new cbxItem { Text = "Tốt", Id = ((int)AssetManagerCommon.CommonEnums.CONDITION.GOOD).ToString(CultureInfo.InvariantCulture) };
            cbCondition.Items.Add(cbxItem);
            cbxItem = new cbxItem { Text = "Mới", Id = ((int)AssetManagerCommon.CommonEnums.CONDITION.NEW).ToString(CultureInfo.InvariantCulture) };
            cbCondition.Items.Add(cbxItem);
            cbxItem = new cbxItem { Text = "Lỗi", Id = ((int)AssetManagerCommon.CommonEnums.CONDITION.FAIL).ToString(CultureInfo.InvariantCulture) };
            cbCondition.Items.Add(cbxItem);
            cbxItem = new cbxItem { Text = "Kém", Id = ((int)AssetManagerCommon.CommonEnums.CONDITION.POOR).ToString(CultureInfo.InvariantCulture) };
            cbCondition.Items.Add(cbxItem);

            

            
                gpLoading.Hide();
                Enabled = true;
                cbStatus.SelectedIndex = 0;
                cbCondition.SelectedIndex = 0;
            
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            odImage.Multiselect = true;
            odImage.Filter = "JPEG Images|*.jpg";
            
            if (odImage.ShowDialog() == DialogResult.Cancel)
            {
                
            }
            else
            {
                var fileNames = odImage.FileNames;
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
            if (txtYear.Text == "")
            {
                MessageBox.Show("Vui lòng nhập năm sản xuất");
                return;
            }
            if (txtAssetNumber.Text.Length != 7)
            {
                MessageBox.Show("Mã tài sản bao gồm 7 chữ số");
                return;
            }
            gpLoading.Description = "Đang tải dữ liệu";
            gpLoading.Show();
            var duedate = Convert.ToDateTime(deDueDate.Text);
            if (_action == (int) CommonEnums.ACTION.EDIT)
            {
                var result = WebServices.UpdateAsset("AS_" + txtAssetNumber.Text, txtName.Text, cbxAssetGroup.Id,
                                                  cbxUnit.Id, Convert.ToInt32(txtAmount.Text),txtCounPro.Text, Convert.ToInt32(txtYear.Text), cbxDepartmentUsed.Id,
                                                  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "U", txtFactory.Text, txtBrand.Text, txtModel.Text, Convert.ToInt16(cbxStatus.Id), Convert.ToInt16(cbxCondition.Id), duedate, meNote.Text, txtSeries.Text);
                if (result == (int) CommonEnums.RetCode.SUCCESS)
                {
                    MessageBox.Show("Thành công");
                    gpLoading.Hide();
                }
                if (result == (int)CommonEnums.RetCode.SYSTEM_ERROR)
                {
                    MessageBox.Show("Lỗi hệ thống,vui lòng thử lại sau");
                }
                return;
            }
            try
            {
                
                var result = WebServices.NewAsset("AS_" + txtAssetNumber.Text, txtName.Text, cbxAssetGroup.Id,
                                                  cbxUnit.Id, Convert.ToInt32(txtAmount.Text),txtCounPro.Text, Convert.ToInt32(txtYear.Text), cbxDepartmentUsed.Id,
                                                  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "U", txtFactory.Text, txtBrand.Text, txtModel.Text, Convert.ToInt16(cbxStatus.Id), Convert.ToInt16(cbxCondition.Id), duedate, meNote.Text, txtSeries.Text);
                if (result == (int) CommonEnums.RetCode.SUCCESS)
                {
                    //if success,upload image
                    gpLoading.Description = "Đang tải dữ liệu lên";
                    using (
                        var ftp = new FtpConnection(@Properties.Settings.Default.hostIP,
                                                    @Properties.Settings.Default.UsernameFtp,
                                                    @Properties.Settings.Default.PasswordFtp))
                    {
                        ftp.Open();
                        ftp.Login();
                        foreach (var imagePath in _imagePathList)
                        {
                            var imageUrl = @Properties.Settings.Default.imageUrl + txtAssetNumber.Text;

                            try
                            {
                                var fileName = random.Next(10000000, 999999999);
                                
                                ftp.CreateDirectory(imageUrl);
                                ftp.SetCurrentDirectory(imageUrl);
                                ftp.PutFile(@imagePath, fileName + ".jpg");
                                    /* upload c:\localfile.txt to the current ftp directory as file.txt */
                                WebServices.NewImage("AS_" + txtAssetNumber.Text,
                                                     fileName.ToString(CultureInfo.InvariantCulture));


                                //insert table image
                            }
                            catch (FtpException ex)
                            {
                                MessageBox.Show("Qúa trình upload ảnh xảy ra lỗi,vui lòng kiểm tra lại.");
                                Console.WriteLine(String.Format("FTP Error: {0} {1}", ex.ErrorCode, ex.Message));
                            }

                        }
                        var attachUrl = @Properties.Settings.Default.attach + txtAssetNumber.Text;
                        var count = lvFile.Items.Count;
                        for (int i = 0; i < count; i++)
                        {
                            ftp.CreateDirectory(attachUrl);
                            ftp.SetCurrentDirectory(attachUrl);
                            ftp.PutFile(lvFile.Items[i].SubItems[0].Text,
                                        lvFile.Items[i].SubItems[1].Text + lvFile.Items[i].SubItems[2].Text);
                        }
                        ftp.Close();
                    }
                    gpLoading.Hide();
                    MessageBox.Show("Thêm tài sản thành công");
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
                    if (rbAuto.Checked)
                    {
                        assetNumber = random.Next(1000000, 9999999).ToString();
                        txtAssetNumber.Text = assetNumber.ToString();
                        btnSave.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Mã tài sản đã tồn tại");
                        gpLoading.Hide();
                    }
                }
            }
            catch (Exception ex)
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
        public void DelegateContent(int action, string id)
        {
            _action = action;
            _id = id;
            if (action == (int) CommonEnums.ACTION.EDIT)
            {
                try
                {
                    var result=WebServices.GetAssetById(_id).RetObject;
                    txtName.Text = result.Name;
                    txtAmount.Text = result.Amount.ToString();
                    txtAssetNumber.Text = result.Id.Split('_')[1];
                    txtBrand.Text = result.Brand;
                    txtCounPro.Text = result.CounPro;
                    txtFactory.Text = result.Manufacturer;
                    txtModel.Text = result.Model;
                    txtName.Text = result.Name;
                    txtSeries.Text = result.SeriesNumber;
                    txtYear.Text = result.YearPro.ToString();
                    int pos = 0;
                    for (int i = 0; i < cbUnit.Items.Count; i++)
                    {
                        var cbx = cbUnit.Items[i] as cbxItem;
                        if (cbx.Id == result.UnitId)
                        {
                            pos = i;
                        }
                    }
                    cbUnit.SelectedIndex = pos;

                    for (int i = 0; i < cbAssetGroup.Items.Count; i++)
                    {
                        var cbx = cbAssetGroup.Items[i] as cbxItem;
                        if (cbx.Id == result.UnitId)
                        {
                            pos = i;
                        }
                    }
                    cbAssetGroup.SelectedIndex = pos;

                    for (int i = 0; i < cbCondition.Items.Count; i++)
                    {
                        var cbx = cbCondition.Items[cbCondition.SelectedIndex] as cbxItem;
                        if (cbx.Id == result.UnitId)
                        {
                            pos = i;
                        }
                    }
                    cbCondition.SelectedIndex = pos;

                    for (int i = 0; i < cbDepartmentUsed.Items.Count; i++)
                    {
                        var cbx = cbDepartmentUsed.Items[i] as cbxItem;
                        if (cbx.Id == result.UnitId)
                        {
                            pos = i;
                        }
                    }
                    cbDepartmentUsed.SelectedIndex = pos;

                    for (int i = 0; i < cbPartner.Items.Count; i++)
                    {
                        var cbx = cbPartner.Items[i] as cbxItem;
                        if (cbx.Id == result.UnitId)
                        {
                            pos = i;
                        }
                    }
                    cbPartner.SelectedIndex = pos;

                    for (int i = 0; i < cbStatus.Items.Count; i++)
                    {
                        var cbx = cbStatus.Items[i] as cbxItem;
                        if (cbx.Id == result.UnitId)
                        {
                            pos = i;
                        }
                    }
                    cbStatus.SelectedIndex = pos;

                    //txtModel.Text=result.
                    //get image
                    var imageList = WebServices.GetImageByAssetId(_id);
                    var linkUrl = Properties.Settings.Default.LinkUrl;
                    linkUrl += "Image" + _id.Split('_')[1]+"/";
                    foreach (var image in imageList)
                    {
                        //isImage.Images.Add(Image.FromFile(@linkUrl+image.ImageUrl+".jpg"));
                        var request = WebRequest.Create(@linkUrl + image.ImageUrl + ".jpg");

                        using (var response = request.GetResponse())
                        using (var stream = response.GetResponseStream())
                        {
                            isImage.Images.Add(Bitmap.FromStream(stream));
                        }
                    }
                    using (
                        var ftp = new FtpConnection(@Properties.Settings.Default.hostIP,
                                                    @Properties.Settings.Default.UsernameFtp,
                                                    @Properties.Settings.Default.PasswordFtp))
                    {
                        ftp.Open();
                        ftp.Login();
                        var lnkAttach = @Properties.Settings.Default.attach + _id.Split('_')[1]+"/";
                        ftp.SetCurrentDirectory(lnkAttach);
                        var files=ftp.GetFiles();
                        foreach (var file in files)
                        {
                            var link=Properties.Settings.Default.LinkUrl + "Attach" + _id.Split('_')[1] + "/" + file.Name;
                            var lvi = new ListViewItem(link);
                            lvi.SubItems.Add(file.Name.Split('.')[0]);
                            lvi.SubItems.Add(file.Name.Split('.')[1]);
                            lvFile.Items.Add(lvi);
                        }
                        ftp.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể kết nối tới server,vui lòng kiểm tra cài đặt mạng");
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }

                    // only allow one decimal point
                    if (e.KeyChar == '.'
                        && (sender as TextBox).Text.IndexOf('.') > -1)
                    {
                        e.Handled = true;
                    }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            odImage.Multiselect = true;
            odImage.Filter = "Tất cả|*.*";
            if (odImage.ShowDialog() == DialogResult.Cancel)
            {

            }
            else
            {
                var fileNames = odImage.FileNames;
                foreach (var fileName in fileNames)
                {
                    var lvi = new ListViewItem(@fileName);
                    lvi.SubItems.Add(fileName.Substring(fileName.LastIndexOf('\\')+1, fileName.LastIndexOf('.') - fileName.LastIndexOf('\\')-1));
                    lvi.SubItems.Add(fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.')));
                    lvFile.Items.Add(lvi);
                }
            }
        }

        private void lvFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(lvFile.SelectedItems[0].Text.ToString());
            Process.Start(lvFile.SelectedItems[0].Text.ToString());
        }
    }
}