using System;
using System.Threading;
using System.Windows.Forms;
using AssetManagerClient.WebService;

namespace AssetManagerClient
{
    public partial class NewAsset : DevExpress.XtraEditors.XtraForm
    {
        public AssetManagerService WebServices = new AssetManagerService();
        public NewAsset()
        {
            
            InitializeComponent();
            var threadOnLoadPage = new Thread(InitContent);
            threadOnLoadPage.Start();
            gpLoading.Hide();
        }
        void InitContent()
        {
            //init Group
            var assetGroups = WebServices.GetAllAssetGroup();
            foreach (var assetGroup in assetGroups)
            {
                var cbxItem = new cbxItem {Text = assetGroup.Name, Id = assetGroup.Id};
                Invoke(new Action(() => cbAssetGroup.Items.Add(cbxItem)));
            }
            //init Department
            var assetDeparments = WebServices.GetDepartmentUsed();
            foreach (var assetDeparment in assetDeparments)
            {
                var cbxItem = new cbxItem {Text = assetDeparment.Name, Id = assetDeparment.Id};
                Invoke(new Action(() => cbDepartmentUsed.Items.Add(cbxItem)));
            }
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}