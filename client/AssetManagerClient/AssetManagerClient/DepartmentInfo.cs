using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AssetManagerClient.WebService;
using DevExpress.XtraEditors;

namespace AssetManagerClient
{
    public partial class DepartmentInfo : DevExpress.XtraEditors.XtraForm
    {
        public AssetManagerService WebServices = new AssetManagerService();
        private int _action;
        private string _id;
        private Form1 _parentForm;
        public DepartmentInfo(Form1 frm1)
        {
            InitializeComponent();
            _parentForm = frm1;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //validate
                if (txtName.Text.Equals(""))
                {
                    MessageBox.Show("Vui lòng điền tên bộ phận");
                    txtName.Focus();
                    return;
                }
                if (txtSdt.Text.Equals(""))
                {
                    MessageBox.Show("Vui lòng điền số điện thoại");
                    txtSdt.Focus();
                    return;
                }
                if (txtRepresentative.Text.Equals(""))
                {
                    MessageBox.Show("Vui lòng điền người đại diện");
                    txtRepresentative.Focus();
                    return;
                }
                if (txtAddress.Text.Equals(""))
                {
                    MessageBox.Show("Vui lòng điền địa chỉ");
                    txtAddress.Focus();
                    return;
                }
                //action
                if (_action == (int)AssetManagerCommon.CommonEnums.ACTION.ADD)
                {
                    var result=WebServices.NewDepartmentUsed(txtName.Text,txtSdt.Text,txtRepresentative.Text,txtAddress.Text);
                    if (result == (int) AssetManagerCommon.CommonEnums.RetCode.SUCCESS)
                    {
                        //if success
                        MessageBox.Show("Thành công");
                        _parentForm.InitContent();
                        Close();
                    }
                    if (result == (int) AssetManagerCommon.CommonEnums.RetCode.FAIL)
                    {
                        MessageBox.Show("Không thành công,vui lòng thử lại!");
                    }
                    if (result == (int)AssetManagerCommon.CommonEnums.RetCode.SYSTEM_ERROR)
                    {
                        MessageBox.Show("Lỗi hệ thống,vui lòng thử lại sau!");
                    }
                }
                if (_action == (int)AssetManagerCommon.CommonEnums.ACTION.EDIT)
                {
                    var result = WebServices.UpdateDepartmentUsed(_id,txtName.Text, txtSdt.Text, txtRepresentative.Text, txtAddress.Text);
                    if (result == (int)AssetManagerCommon.CommonEnums.RetCode.SUCCESS)
                    {
                        //if success
                        MessageBox.Show("Thành công");
                        _parentForm.InitContent();
                        Close();
                    }
                    if (result == (int)AssetManagerCommon.CommonEnums.RetCode.FAIL)
                    {
                        MessageBox.Show("Không thành công,vui lòng thử lại!");
                    }
                    if (result == (int)AssetManagerCommon.CommonEnums.RetCode.SYSTEM_ERROR)
                    {
                        MessageBox.Show("Lỗi hệ thống,vui lòng thử lại sau!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối tới server,vui lòng kiểm tra cài đặt mạng");
                
            }
        }
        
        public void DelegateContent(int action,string id)
        {
            _action = action;
            _id = id;
            if (action == (int) AssetManagerCommon.CommonEnums.ACTION.EDIT)
            {
                try
                {
                    var result = WebServices.GetDepartmentUsedById(_id).RetObject;
                    txtName.Text = result.Name;
                    txtAddress.Text = result.Address;
                    txtSdt.Text = result.Phone;
                    txtRepresentative.Text = result.Representative;
                }
                catch (Exception)
                {

                    MessageBox.Show("Không thể kết nối tới server,vui lòng kiểm tra cài đặt mạng");
                }
            }
        }

        private void DepartmentInfo_Load(object sender, EventArgs e)
        {

        }
    }
}