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
    public partial class GroupTypeInfo : DevExpress.XtraEditors.XtraForm
    {
        private int _action;
        private string _id;
        private Form form1;
        public AssetManagerService WebServices = new AssetManagerService();
        public GroupTypeInfo(Form frm)
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
            if(txt)
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
            }
        }
    }
}