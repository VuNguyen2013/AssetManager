using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cunghoc3_AssetManager.DataContract
{
    public class AssetLiquidationData
    {
        public string Id { get; set; }
        public string AssetName { get; set; }
        public string DepartmentUsedName { get; set; }
        public DateTime LiDateTime { get; set; }
        public long LiPrice { get; set; }
    }
}