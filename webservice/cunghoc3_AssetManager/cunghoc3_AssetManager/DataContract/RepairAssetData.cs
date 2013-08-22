using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cunghoc3_AssetManager.DataContract
{
    public class RepairAssetData
    {
        public string Id { get; set; }
        public string AssetName { get; set; }
        public string DepartmentUsedName { get; set; }
        public string PartnerName { get; set; }
        public string Address { get; set; }
        public DateTime RepairDate { get; set; }
        public long Fee { get; set; }
    }
}