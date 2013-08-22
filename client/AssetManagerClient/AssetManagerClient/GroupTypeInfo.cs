﻿using System;
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
    public partial class GroupTypeInfo : DevExpress.XtraEditors.XtraForm
    {
        private int _action;
        private string _id;
        private Form1 form1;
        public AssetManagerService WebServices = new AssetManagerService();
        public GroupTypeInfo(Form1 frm)
        {
            
            InitializeComponent();
            form1 = frm;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Equals(""))
                {
                    MessageBox.Show("Vui lòng nhập tên");
                    return;
                }
                if (_action == (int)AssetManagerCommon.CommonEnums.ACTION.ADD)
                {
                    var result = WebServices.NewAssetGroupType(txtName.Text);
                    if (result == (int)AssetManagerCommon.CommonEnums.RetCode.SUCCESS)
                    {
                        MessageBox.Show("Thành công");
                        form1.InitContent();
                    }
                }
                if (_action == (int)AssetManagerCommon.CommonEnums.ACTION.EDIT)
                {
                    var result = WebServices.UpdateAssetGroupType(_id, txtName.Text);
                    if (result == (int)AssetManagerCommon.CommonEnums.RetCode.SUCCESS)
                    {
                        MessageBox.Show("Thành công");
                        form1.InitContent();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối tới server,vui lòng kiểm tra cài đặt mạng");
            }
            
        }
        public void DelegateContent(int action, string id)
        {
            _action = action;
            _id = id;
            if (_action == (int)AssetManagerCommon.CommonEnums.ACTION.ADD)
            {
                lblCreateName.Text = "TẠO BỘ PHẬN";
            }
            if (_action == (int)AssetManagerCommon.CommonEnums.ACTION.EDIT)
            {
                lblCreateName.Text = "SỬA THÔNG TIN";
                try
                {
                    var result = WebServices.GetAssetGroupTypeById(id);
                    txtName.Text = result.Name;
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể kết nối tới server,vui lòng kiểm tra cài đặt mạng");
                }
                
            }
        }
    }
}