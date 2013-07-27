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
        public List<AssetGroupType> GetAllAssetGroupType()
        {
            cunghoc3_AssetManager.Services.AssetGroupTypeService db = new Services.AssetGroupTypeService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public AssetGroupType GetAssetGroupTypeById(string id)
        {
            cunghoc3_AssetManager.Services.AssetGroupTypeService db = new Services.AssetGroupTypeService();
            return db.GetById(id);
        }

        [WebMethod]
        public string DelAssetGroupTypeById(string id)
        {
            cunghoc3_AssetManager.Services.AssetGroupTypeService db = new Services.AssetGroupTypeService();
            AssetGroupType item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

        [WebMethod]
        public string UpdateAssetGroupType(string id, string name)
        {
            cunghoc3_AssetManager.Services.AssetGroupTypeService db = new Services.AssetGroupTypeService();
            AssetGroupType item = db.GetById(id);
            item.Name = name;
            db.Update(item);
            return "Update new successful";
        }

        [WebMethod]
        public string NewAssetGroup(string Name, string AssetGroupTypeId)
        {
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            AssetGroup item = new AssetGroup();
            do
            {
                int numbID = randomId.Next(111111, 9999999);
                item.Id = "AG_" + numbID;
                item.Name = Name;
                item.AssetGroupTypeId = AssetGroupTypeId;
            } while (!db.Insert(item));
            return "Add new AssetGroup successful";
        }

        [WebMethod]
        public List<AssetGroup> GetAllAssetGroup()
        {
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public AssetGroup GetAssetGroupById(string id)
        {
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            return db.GetById(id);
        }

        [WebMethod]
        public string DelAssetGroupById(string id)
        {
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            AssetGroup item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

        [WebMethod]
        public string UpdateAssetGroupType(string id, string Name, string AssetGroupTypeId)
        {
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            AssetGroup item = db.GetById(id);
            item.Name = Name;
            item.AssetGroupTypeId = AssetGroupTypeId;
            db.Update(item);
            return "Update new successful";
        }

        [WebMethod]
        public string NewCapital(string Name, string Note)
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            Capital item = new Capital();
            do
            {
                int numbID = randomId.Next(111111, 9999999);
                item.Id = "CP_" + numbID;
                item.Name = Name;
                item.Note = Note;
            } while (!db.Insert(item));
            return "Add new Capital successful";
        }

        [WebMethod]
        public List<Capital> GetAllCapitalGroup()
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public Capital GetCapitalById(string id)
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            return db.GetById(id);
        }

        [WebMethod]
        public string DelCapitalById(string id)
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            Capital item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

        [WebMethod]
        public string UpdateCapitalType(string id, string Name, string Note)
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            Capital item = db.GetById(id);
            item.Name = Name;
            item.Note = Note;
            db.Update(item);
            return "Update new successful";
        }

        [WebMethod]
        public string NewDepartmentUsed(string Name, string Phone, string Representative, string Address)
        {
            cunghoc3_AssetManager.Services.DepartmentUsedService db = new Services.DepartmentUsedService();
            DepartmentUsed item = new DepartmentUsed();
            do
            {
                int numbID = randomId.Next(111111, 9999999);
                item.Id = "DU_" + numbID;
                item.Name = Name;
                item.Phone = Phone;
                item.Representative = Representative;
                item.Address = Address;
            } while (db.Insert(item));
            return "Add new DepartmentUsed successful";
        }

        [WebMethod]
        public string NewUnit(string Name, string Note)
        {
            cunghoc3_AssetManager.Services.UnitService db = new Services.UnitService();
            Unit item = new Unit();
            do
            {
                int numbID = randomId.Next(111111, 9999999);
                item.Id = "UN_" + numbID;
                item.Name = Name;
                item.Note = Note;
            } while (!db.Insert(item));
            return "Add new Unit successful";
        }

        [WebMethod]
        public string NewAsset(string Name, string AssetGroupId, string UnitId, string Amount, string CounPro, string YearPro, string DepartmentUsedId, string TotalPrice, string BugetPrice, string OwnPrice, string VenturePrice, string AnotherPrice, string TotalDepreciation, string BugetDepreciation, string OwnDepreciation, string VentureDepreciation, string AnotherDepreciation, string BugeRemain, string OwnRemain, string VentureRemain, string AnotherRemain, string TotalRemain, string UpDownCode, string InputDateTime)
        {
            cunghoc3_AssetManager.Services.AssetService db = new Services.AssetService();
            Asset item = new Asset();
            do
            {
                int numbID = randomId.Next(111111, 9999999);
                item.Id = "AS_" + numbID;
                item.Name = Name;
                item.AssetGroupId = AssetGroupId;
                item.UnitId = UnitId;
                item.Amount = Convert.ToInt32(Amount);
                item.CounPro = CounPro;
                item.YearPro = Convert.ToInt32(YearPro);
                item.DepartmentUsedId = DepartmentUsedId;
                item.TotalPrice = Convert.ToInt64(TotalPrice);
                item.BudgetPrice = Convert.ToInt64(BugetPrice);
                item.OwnPrice = Convert.ToInt64(OwnPrice);
                item.VenturePrice = Convert.ToInt64(VenturePrice);
                item.AnotherPrice = Convert.ToInt64(AnotherPrice);
                item.TotalDepreciation = Convert.ToInt64(TotalDepreciation);
                item.BudgetDepreciation = Convert.ToInt64(BugetDepreciation);
                item.OwnDepreciation = Convert.ToInt64(OwnDepreciation);
                item.VentureDepreciation = Convert.ToInt64(VentureDepreciation);
                item.AnotherDepreciation = Convert.ToInt64(AnotherDepreciation);
                item.BudgetRemain = Convert.ToInt64(BugeRemain);
                item.OwnRemain = Convert.ToInt64(OwnRemain);
                item.VentureRemain = Convert.ToInt64(VentureRemain);
                item.AnotherRemain = Convert.ToInt64(AnotherRemain);
                item.TotalReamain = Convert.ToInt64(TotalRemain);
            } while (!db.Insert(item));
            return "Add new Asset successful";
        }

        [WebMethod]
        public string NewPartner(string Name, string Phone, string TaxCode, string Address)
        {
            cunghoc3_AssetManager.Services.PartnerService db = new Services.PartnerService();
            Partner item = new Partner();
            do
            {
                int numbID = randomId.Next(111111, 9999999);
                item.Id = "PN_" + numbID;
                item.Name = Name;
                item.Phone = Phone;
                item.Address = Address;
                item.TaxCode = TaxCode;
            } while (db.Insert(item));
            return "Add new Partner successful";
        }

        [WebMethod]
        public string NewUpDownReason(string Name, string Type)
        {
            cunghoc3_AssetManager.Services.UpDownReasonService db = new Services.UpDownReasonService();
            UpDownReason item = new UpDownReason();
            do
            {
                int numbID = randomId.Next(111111, 9999999);
                item.Id = "UDR_" + numbID;
                item.Name = Name;
                item.Type = Type;
            } while (!db.Insert(item));
            return "Add new UpDownReason successful";
        }

        [WebMethod]
        public string NewAssetLiquidation(string AssetId, string DepartmentUsedId, string LiDateTime, string LiPrice)
        {
            cunghoc3_AssetManager.Services.AssetLiquidationService db = new Services.AssetLiquidationService();
            AssetLiquidation item = new AssetLiquidation();
            do
            {
                int numbID = randomId.Next(111111, 9999999);
                item.Id = "ALQ_" + numbID;
                item.AssetId = AssetId;
                item.DepartmentUsedId = DepartmentUsedId;
                item.LiDateTime = DateTime.Parse(LiDateTime);
                item.LiPrice = Convert.ToInt64(LiPrice);
            } while (!db.Insert(item));
            return "Add new AssetLiquidation successful";
        }

        [WebMethod]
        public string NewRepairAsset(string AssetId, string DepartmentUsedId, string PartnerId, string Address, string RepairDate, string Fee)
        {
            cunghoc3_AssetManager.Services.RepairAssetService db = new Services.RepairAssetService();
            RepairAsset item = new RepairAsset();
            do
            {
                int numbID = randomId.Next(111111, 9999999);
                item.Id = "RPA_" + numbID;
                item.AssetId = AssetId;
                item.DepartmentUsedId = DepartmentUsedId;
                item.PartnerId = PartnerId;
                item.Address = Address;
                item.RepairDate = DateTime.Parse(RepairDate);
                item.Fee = Convert.ToInt64(Fee);
            } while (!db.Insert(item));
            return "Add new RepairAsset successful";
        }

        [WebMethod]
        public string NewWarrantyAsset(string AssetId, string DepartmentUsedId, string PartnerId, string WarDateTime, string DeadlineWar, string Address, string PersonWar)
        {
            cunghoc3_AssetManager.Services.WarrantyAssetService db = new Services.WarrantyAssetService();
            WarrantyAsset item = new WarrantyAsset();
            do
            {
                int numbID = randomId.Next(111111, 9999999);
                item.Id = "WRA_" + numbID;
                item.AsssetId= AssetId;
                item.DepartmentUsedId = DepartmentUsedId;
                item.PartnerId = PartnerId;
                item.WarDateTime = DateTime.Parse(WarDateTime); ;
                item.DeadlineWar = DateTime.Parse(DeadlineWar);
                item.Address = Address;
                item.PersonWar = PersonWar;
            } while (!db.Insert(item));
            return "Add new WarrantyAsset successful";
        }
    }
}