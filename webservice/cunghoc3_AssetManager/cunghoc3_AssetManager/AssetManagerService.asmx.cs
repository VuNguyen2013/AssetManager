using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using cunghoc3_AssetManager.Entities;

namespace cunghoc3_AssetManager
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AssetManagerService : System.Web.Services.WebService
    {
        private Random randomId = new Random();
        [WebMethod]
        public string NewAssetGroupType(string Name)
        {
            cunghoc3_AssetManager.Services.AssetGroupTypeService db = new Services.AssetGroupTypeService();
            AssetGroupType item = new AssetGroupType();
            do
            {
                int numbID = randomId.Next(111111, 999999);
                item.Id = "AGT_"+numbID;
                item.Name = Name;
            } while (!db.Insert(item));
            return "Add new AssetGroupType successful";
        }

        [WebMethod]
        public string NewAssetGroup(string Name, string AssetGroupTypeId)
        {
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            AssetGroup item = new AssetGroup();
            item.Name = Name;
            item.AssetGroupTypeId = AssetGroupTypeId;
            db.Insert(item);
            return "Add new AssetGroup successful";
        }

        [WebMethod]
        public string NewCapital(string Name, string Note)
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            Capital item = new Capital();
            item.Name = Name;
            item.Note = Note;
            db.Insert(item);
            return "Add new Capital successful";
        }

        [WebMethod]
        public string NewDepartmentUsed(string Name, string Phone, string Representative, string Address)
        {
            cunghoc3_AssetManager.Services.DepartmentUsedService db = new Services.DepartmentUsedService();
            DepartmentUsed item = new DepartmentUsed();
            item.Name = Name;
            item.Phone = Phone;
            item.Representative = Representative;
            item.Address = Address;
            db.Insert(item);
            return "Add new DepartmentUsed successful";
        }

        [WebMethod]
        public string NewUnit(string Name, string Note)
        {
            cunghoc3_AssetManager.Services.UnitService db = new Services.UnitService();
            Unit item = new Unit();
            item.Name = Name;
            item.Note = Note;
            db.Insert(item);
            return "Add new Unit successful";
        }
    }
}