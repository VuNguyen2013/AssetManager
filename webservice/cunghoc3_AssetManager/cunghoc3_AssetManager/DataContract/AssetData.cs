using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace cunghoc3_AssetManager.DataContract
{
    public class AssetData
    {
        public string Id{ get; set; }
        public string Name{ get; set; }
        public string AssetGroup{ get; set; }
        public string Unit{ get; set; }
        public long Amount{ get; set; }
        public string CounPro{ get; set; }
        public long YearPro{ get; set; }
        public string DepartmentUsed{ get; set; }
        public long TotalPrice{ get; set; }
        public long BugetPrice{ get; set; }
        public long OwnPrice{ get; set; }
        public long VenturePrice{ get; set; }
        public long AnotherPrice{ get; set; }
        public long TotalDepreciation{ get; set; }
        public long BugetDepreciation{ get; set; }
        public long OwnDepreciation{ get; set; }
        public long VentureDepreciation{ get; set; }
        public long AnotherDepreciation{ get; set; }
        public long BugeRemain{ get; set; }
        public long OwnRemain{ get; set; }
        public long VentureRemain{ get; set; }
        public long AnotherRemain{ get; set; }
        public long TotalRemain{ get; set; }
        public string UpDownCode{ get; set; }
        public DateTime InputDateTime{ get; set; }

    }
}