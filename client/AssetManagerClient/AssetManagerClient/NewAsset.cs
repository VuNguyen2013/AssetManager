﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
            var threadOnLoadPage = new Thread(InitContent);
            threadOnLoadPage.Start();
        }
        void InitContent()
        {
            Invoke(new Action(() => txtAssetNumber.Text = assetNumber));
            //init Group
            var assetGroups = WebServices.GetAllAssetGroupType().RetObject;
            cbxItem cbxItem;
            foreach (var assetGroup in assetGroups)
            {
                cbxItem = new cbxItem {Text = assetGroup.Name, Id = assetGroup.Id};
                Invoke(new Action(() => cbAssetGroup.Items.Add(cbxItem)));
            }
            //init Department
            var assetDeparments = WebServices.GetAllDepartmentUsed().RetObject;
            foreach (var assetDeparment in assetDeparments)
            {
                cbxItem = new cbxItem {Text = assetDeparment.Name, Id = assetDeparment.Id};
                Invoke(new Action(() => cbDepartmentUsed.Items.Add(cbxItem)));
                
            }

            //init Department
            var units = WebServices.GetAllUnit().RetObject;
            foreach (var unit in units)
            {
                cbxItem = new cbxItem { Text = unit.Name, Id = unit.Id };
                Invoke(new Action(() => cbUnit.Items.Add(cbxItem)));
            }

            //init Department
            var partners = WebServices.GetAllPartner().RetObject;
            foreach (var partner in partners)
            {
                cbxItem = new cbxItem { Text = partner.Name, Id = partner.Id };
                Invoke(new Action(() => cbPartner.Items.Add(cbxItem)));
            }

            //init Status
            cbxItem = new cbxItem { Text = "Đang sữ dụng", Id = ((int)CommonEnums.STATUS.IN_USE).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbStatus.Items.Add(cbxItem)));
            cbxItem = new cbxItem { Text = "Đang lưu trong kho", Id = ((int)CommonEnums.STATUS.IN_STORAGE).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbStatus.Items.Add(cbxItem)));
            cbxItem = new cbxItem { Text = "Đang cho mượn", Id = ((int)CommonEnums.STATUS.LOANED_OUT).ToString(CultureInfo.InvariantCulture) };
            Invoke(new Action(() => cbStatus.Items.Add(cbxItem)));
            cbxItem = new cbxItem { Text = "Đang sửa chữa", Id = ((int)CommonEnums.STATUS.OUT_FOR_REPAIR).ToString(CultureInfo.InvariantCulture) };
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
            gpLoading.Description = "Đang tạo tài sản mới";
            gpLoading.Show();
            try
            {
                var duedate = Convert.ToDateTime(deDueDate.Text);
                var result = WebServices.NewAsset("AS_" + txtAssetNumber.Text, txtName.Text, cbxAssetGroup.Id,
                                                  cbxUnit.Id, Convert.ToInt32(txtAmount.Text),txtCounPro.Text, Convert.ToInt32(txtYear.Text), cbxDepartmentUsed.Id,
                                                  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "U", txtFactory.Text, txtBrand.Text, txtModel.Text, Convert.ToInt16(cbxStatus.Id), Convert.ToInt16(cbxCondition.Id), duedate, meNote.Text, txtSeries.Text);
                if (result == (int) CommonEnums.RetCode.SUCCESS)
                {
                    //if success,upload image
                    gpLoading.Description = "Đang tải dữ liệu lên";
                    foreach (var imagePath in _imagePathList)
                    {
                        var imageUrl = @Properties.Settings.Default.imageUrl + txtAssetNumber.Text;
                        var attachUrl = @Properties.Settings.Default.imageUrl + txtAssetNumber.Text;
                        using (var ftp = new FtpConnection(@Properties.Settings.Default.hostIP, @Properties.Settings.Default.UsernameFtp, @Properties.Settings.Default.PasswordFtp))
                        {
                            try
                            {
                                var fileName = random.Next(10000000, 999999999);
                                ftp.Open();
                                ftp.Login();
                                ftp.CreateDirectory(imageUrl);
                                ftp.SetCurrentDirectory(imageUrl);
                                ftp.PutFile(@imagePath, fileName+".jpg"); /* upload c:\localfile.txt to the current ftp directory as file.txt */
                                WebServices.NewImage("AS_" + txtAssetNumber.Text, fileName.ToString(CultureInfo.InvariantCulture));

                                var count = lvFile.Items.Count;

                                for (int i = 0; i < count; i++)
                                {
                                    ftp.CreateDirectory(imageUrl);
                                    ftp.SetCurrentDirectory(imageUrl);
                                    ftp.PutFile(lvFile.Items[i].SubItems[0].Text, lvFile.Items[i].SubItems[1].Text + "." + lvFile.Items[i].SubItems[2].Text);
                                }
                                    ftp.Close();
                                //insert table image
                            }
                            catch (FtpException ex)
                            {
                                MessageBox.Show("Qúa trình upload ảnh xảy ra lỗi,vui lòng kiểm tra lại.");
                                Console.WriteLine(String.Format("FTP Error: {0} {1}", ex.ErrorCode, ex.Message));
                            }
                        }
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
                    txtAssetNumber.Text = result.Id.Split('_')[2];
                    txtBrand.Text = result.Brand;
                    txtCounPro.Text = result.CounPro;
                    txtFactory.Text = result.Manufacturer;
                    txtModel.Text = result.Model;
                    txtName.Text = result.Name;
                    txtSeries.Text = result.SeriesNumber;
                    txtYear.Text = result.YearPro.ToString();
                   
                    //txtModel.Text=result.
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
    }
}