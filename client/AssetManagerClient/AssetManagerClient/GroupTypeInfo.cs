using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AssetManagerClient
{
    public partial class GroupTypeInfo : DevExpress.XtraEditors.XtraForm
    {
        private int _action;
        private string _id;

        public GroupTypeInfo()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

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