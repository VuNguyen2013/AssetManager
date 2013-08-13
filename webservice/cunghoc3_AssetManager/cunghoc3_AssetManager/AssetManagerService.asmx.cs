using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AssetManagerCommon;
using cunghoc3_AssetManager.DataContract;
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
        public Random randomId = new Random();
        [WebMethod]
        public int NewAssetGroupType(string Id, string Name)
        {
            try
            {
                var db = new Services.AssetGroupTypeService();
                if (GetAssetGroupTypeById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new AssetGroupType
                {
                    Id = Id,
                    Name = Name,
                })
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }

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
            return "Update item successful";
        }

        [WebMethod]
        public int NewAssetGroup(string Id, string Name, string AssetGroupTypeId)
        {
            try
            {
                var db = new Services.AssetGroupService();
                if (GetAssetGroupById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new AssetGroup
                {
                    Id = Id,
                    Name = Name,
                    AssetGroupTypeId = AssetGroupTypeId
                })
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }
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
        public string UpdateAssetGroup(string id, string Name, string AssetGroupTypeId)
        {
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            AssetGroup item = db.GetById(id);
            item.Name = Name;
            item.AssetGroupTypeId = AssetGroupTypeId;
            db.Update(item);
            return "Update item successful";
        }

        [WebMethod]
        public int NewCapital(string Id, string Name, string Note)
        {
            try
            {
                var db = new Services.CapitalService();
                if (GetCapitalById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new Capital
                {
                    Id = Id,
                    Name = Name,
                    Note = Note
                })
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }
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
        public string UpdateCapital(string id, string Name, string Note)
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            Capital item = db.GetById(id);
            item.Name = Name;
            item.Note = Note;
            db.Update(item);
            return "Update item successful";
        }

        [WebMethod]
        public int NewDepartmentUsed(string Id, string Name, string Phone, string Representative, string Address)
        {
            try
            {
                var db = new Services.DepartmentUsedService();
                if (GetDepartmentUsedById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new DepartmentUsed
                {
                    Id = Id,
                    Name = Name,
                    Phone = Phone,
                    Representative = Representative,
                    Address = Address
                })
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }
        }

        [WebMethod]
        public string UpdateDepartmentUsed(string id, string Name, string Phone, string Representative, string Address)
        {
            cunghoc3_AssetManager.Services.DepartmentUsedService db = new Services.DepartmentUsedService();
            DepartmentUsed item = db.GetById(id);
            item.Name = Name;
            item.Phone = Phone;
            item.Representative = Representative;
            item.Address = Address;
            db.Update(item);
            return "Update item successful";
        }

        [WebMethod]
        public List<DepartmentUsed> GetDepartmentUsed()
        {
            cunghoc3_AssetManager.Services.DepartmentUsedService db = new Services.DepartmentUsedService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public DepartmentUsed GetDepartmentUsedById(string id)
        {
            cunghoc3_AssetManager.Services.DepartmentUsedService db = new Services.DepartmentUsedService();
            return db.GetById(id);
        }

        [WebMethod]
        public string DelDepartmentUsedById(string id)
        {
            cunghoc3_AssetManager.Services.DepartmentUsedService db = new Services.DepartmentUsedService();
            DepartmentUsed item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

        [WebMethod]
        public int NewUnit(string Id, string Name, string Note)
        {
            try
            {
                var db = new Services.UnitService();
                if (GetUnitById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new Unit
                {
                    Id = Id,
                    Name = Name,
                    Note = Note
                })
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }
        }

        [WebMethod]
        public string UpdateUnit(string id, string Name, string Note)
        {
            cunghoc3_AssetManager.Services.UnitService db = new Services.UnitService();
            Unit item = db.GetById(id);
            item.Name = Name;
            item.Note = Note;
            db.Update(item);
            return "Update item successful";
        }

        [WebMethod]
        public List<Unit> GetAllUnit()
        {
            cunghoc3_AssetManager.Services.UnitService db = new Services.UnitService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public Unit GetUnitById(string id)
        {
            cunghoc3_AssetManager.Services.UnitService db = new Services.UnitService();
            return db.GetById(id);
        }

        [WebMethod]
        public string DelUnitById(string id)
        {
            cunghoc3_AssetManager.Services.UnitService db = new Services.UnitService();
            Unit item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

        [WebMethod]
<<<<<<< HEAD
        public int NewAsset(string assetNumber, string name, string assetGroupId, string unitId, int amount, string counPro, int yearPro, string departmentUsedId, long totalPrice, long bugetPrice, long ownPrice, long venturePrice, long anotherPrice, long totalDepreciation, long bugetDepreciation, long ownDepreciation, long ventureDepreciation, long anotherDepreciation, long bugeRemain, long ownRemain, long ventureRemain, long anotherRemain, long totalRemain, string upDownCode)
=======
        public int NewAsset(string assetNumber,string name, string assetGroupId, string unitId, int amount, string counPro, int yearPro, string departmentUsedId, long totalPrice, long bugetPrice, long ownPrice, long venturePrice, long anotherPrice, long totalDepreciation, long bugetDepreciation, long ownDepreciation, long ventureDepreciation, long anotherDepreciation, long bugeRemain, long ownRemain, long ventureRemain, long anotherRemain, long totalRemain, string upDownCode)
>>>>>>> 7916baf4e085fd206f1f7920a5dce0a7fc03a890
        {
            var inputDateTime = DateTime.Today;
            try
            {
                var db = new Services.AssetService();
                if (GetAssetById(assetNumber) != null)
                {
<<<<<<< HEAD
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new Asset
                {
                    Id = assetNumber,
                    Name = name,
                    AssetGroupId = assetGroupId,
                    UnitId = unitId,
                    Amount = amount,
                    CounPro = counPro,
                    YearPro = yearPro,
                    DepartmentUsedId = departmentUsedId,
                    TotalPrice = totalPrice,
                    BudgetPrice = bugetPrice,
                    OwnPrice = ownPrice,
                    VenturePrice = venturePrice,
                    AnotherPrice = anotherPrice,
                    TotalDepreciation = totalDepreciation,
                    BudgetDepreciation = bugetDepreciation,
                    OwnDepreciation = ownDepreciation,
                    VentureDepreciation = ventureDepreciation,
                    AnotherDepreciation = anotherDepreciation,
                    BudgetRemain = bugeRemain,
                    OwnRemain = ownRemain,
                    VentureRemain = ventureRemain,
                    AnotherRemain = anotherRemain,
                    TotalReamain = totalRemain,
                    UpDownCode = upDownCode,
                    InputDateTime = inputDateTime
                })
=======
                    return (int) CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new Asset
                    {
                        Id = assetNumber,
                        Name = name,
                        AssetGroupId = assetGroupId,
                        UnitId = unitId,
                        Amount = amount,
                        CounPro = counPro,
                        YearPro = yearPro,
                        DepartmentUsedId = departmentUsedId,
                        TotalPrice = totalPrice,
                        BudgetPrice = bugetPrice,
                        OwnPrice = ownPrice,
                        VenturePrice = venturePrice,
                        AnotherPrice = anotherPrice,
                        TotalDepreciation = totalDepreciation,
                        BudgetDepreciation = bugetDepreciation,
                        OwnDepreciation = ownDepreciation,
                        VentureDepreciation = ventureDepreciation,
                        AnotherDepreciation = anotherDepreciation,
                        BudgetRemain = bugeRemain,
                        OwnRemain = ownRemain,
                        VentureRemain = ventureRemain,
                        AnotherRemain = anotherRemain,
                        TotalReamain = totalRemain,
                        UpDownCode = upDownCode,
                        InputDateTime = inputDateTime
                    })
>>>>>>> 7916baf4e085fd206f1f7920a5dce0a7fc03a890
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }

        }

        [WebMethod]
        public string UpdateAsset(string id, string Name, string AssetGroupId, string UnitId, string Amount, string CounPro, string YearPro, string DepartmentUsedId, string TotalPrice, string BugetPrice, string OwnPrice, string VenturePrice, string AnotherPrice, string TotalDepreciation, string BugetDepreciation, string OwnDepreciation, string VentureDepreciation, string AnotherDepreciation, string BugeRemain, string OwnRemain, string VentureRemain, string AnotherRemain, string TotalRemain, string UpDownCode, string InputDateTime)
        {
            cunghoc3_AssetManager.Services.AssetService db = new Services.AssetService();
            Asset item = db.GetById(id);
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
            db.Update(item);
            return "Update item successful";
        }

        [WebMethod]
        public ResultObject<List<AssetData>> GetAllAsset()
        {
            var resultObject = new ResultObject<List<AssetData>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            try
            {
                var db = new Services.AssetService();
                var assets = db.GetAll();
                var assetsList= (from asset in assets
                                 let unit = GetUnitById(asset.UnitId)
                                 let departmentUsed = GetDepartmentUsedById(asset.DepartmentUsedId)
                                 let assetGroup = GetAssetGroupById(asset.AssetGroupId)
                                 select new AssetData
                                     {
                                         Amount = asset.Amount, AnotherDepreciation = asset.AnotherDepreciation, AnotherPrice = asset.AnotherPrice, AnotherRemain = asset.AnotherRemain, BugeRemain = asset.BudgetRemain, BugetDepreciation = asset.BudgetDepreciation, BugetPrice = asset.BudgetPrice, CounPro = asset.CounPro, Id = asset.Id, InputDateTime = asset.InputDateTime, Name = asset.Name, OwnDepreciation = asset.OwnDepreciation, OwnPrice = asset.OwnPrice, OwnRemain = asset.OwnRemain, TotalDepreciation = asset.TotalDepreciation, TotalPrice = asset.TotalPrice, TotalRemain = asset.TotalReamain, UpDownCode = asset.UpDownCode, VentureDepreciation = asset.VentureDepreciation, VenturePrice = asset.VenturePrice, VentureRemain = asset.VentureRemain, YearPro = asset.YearPro,
                                         //refer
                                         Unit = unit.Name, DepartmentUsed = departmentUsed.Name, AssetGroup = assetGroup.Name
                                     }).ToList();
                resultObject.RetObject = assetsList;
                resultObject.Message = "Get asset list success";
                return resultObject;
            }
            catch (Exception ex)
            {
                resultObject.RetCode = (int) CommonEnums.RetCode.SYSTEM_ERROR;
                return resultObject;
            }
            
        }

        [WebMethod]
        public Asset GetAssetById(string id)
        {
            cunghoc3_AssetManager.Services.AssetService db = new Services.AssetService();
            return db.GetById(id);
        }

        [WebMethod]
        public List<Asset> GetAssetByAssetGroupTypeId(string AssetGroupTypeId)
        {
            cunghoc3_AssetManager.Services.AssetService db = new Services.AssetService();
            cunghoc3_AssetManager.Services.AssetGroupService dbAssetGroup = new Services.AssetGroupService();
            List<AssetGroup> assetGroupList = dbAssetGroup.GetByAssetGroupTypeId(AssetGroupTypeId).ToList();
            List<Asset> assetList = new List<Asset>();
            foreach(AssetGroup ag in assetGroupList){
                assetList.AddRange(db.GetByAssetGroupId(ag.Id).ToList());
            }
            return assetList;
        }

        [WebMethod]
        public List<Asset> GetAssetByDepartmentUsedId(string DepartmentUsedId)
        {
            cunghoc3_AssetManager.Services.AssetService db = new Services.AssetService();
            return db.GetByDepartmentUsedId(DepartmentUsedId).ToList();
        }

        [WebMethod]
        public string DelAssetById(string id)
        {
            cunghoc3_AssetManager.Services.AssetService db = new Services.AssetService();
            Asset item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

        [WebMethod]
        public int NewPartner(string Id, string Name, string Phone, string TaxCode, string Address)
        {
            try
            {
                var db = new Services.PartnerService();
                if (GetPartnerById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new Partner
                {
                    Id = Id,
                    Name = Name,
                    Phone = Phone,
                    Address = Address,
                    TaxCode = TaxCode
                })
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }
        }
        
       [WebMethod]
        public string UpdatePartner(string id, string Name, string Phone, string TaxCode, string Address)
        {
            cunghoc3_AssetManager.Services.PartnerService db = new Services.PartnerService();
            Partner item = db.GetById(id);
            item.Name = Name;
            item.Phone = Phone;
            item.Address = Address;
            item.TaxCode = TaxCode;
            db.Update(item);
            return "Update item successful";
        }

        [WebMethod]
        public List<Partner> GetAllPartner()
        {
            cunghoc3_AssetManager.Services.PartnerService db = new Services.PartnerService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public Partner GetPartnerById(string id)
        {
            cunghoc3_AssetManager.Services.PartnerService db = new Services.PartnerService();
            return db.GetById(id);
        }

        [WebMethod]
        public string DelPartnerById(string id)
        {
            cunghoc3_AssetManager.Services.PartnerService db = new Services.PartnerService();
            Partner item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

        [WebMethod]
        public int NewUpDownReason(string Id, string Name, string Type)
        {
            try
            {
                var db = new Services.UpDownReasonService();
                if (GetUpDownReasonById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new UpDownReason
                {
                    Id = Id,
                    Name = Name,
                    Type = Type
                })
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }
        }

        [WebMethod]
        public string UpdateUpDownReason(string id, string Name, string Type)
        {
            cunghoc3_AssetManager.Services.UpDownReasonService db = new Services.UpDownReasonService();
            UpDownReason item = db.GetById(id);
            item.Name = Name;
            item.Type = Type;
            db.Update(item);
            return "Update item successful";
        }

        [WebMethod]
        public List<UpDownReason> GetAllUpDownReason()
        {
            cunghoc3_AssetManager.Services.UpDownReasonService db = new Services.UpDownReasonService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public UpDownReason GetUpDownReasonById(string id)
        {
            cunghoc3_AssetManager.Services.UpDownReasonService db = new Services.UpDownReasonService();
            return db.GetById(id);
        }

        [WebMethod]
        public string DelUpDownReasonById(string id)
        {
            cunghoc3_AssetManager.Services.UpDownReasonService db = new Services.UpDownReasonService();
            UpDownReason item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

        [WebMethod]
        public int NewAssetLiquidation(string Id, string AssetId, string DepartmentUsedId, string LiDateTime, string LiPrice)
        {
            try
            {
                var db = new Services.AssetLiquidationService();
                if (GetAssetLiquidationById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new AssetLiquidation
                {
                    Id = Id,
                    AssetId = AssetId,
                    DepartmentUsedId = DepartmentUsedId,
                    LiDateTime = DateTime.Parse(LiDateTime),
                    LiPrice = Convert.ToInt64(LiPrice)
                })
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }
        }

        [WebMethod]
        public string UpdateAssetLiquidation(string id, string AssetId, string DepartmentUsedId, string LiDateTime, string LiPrice)
        {
            cunghoc3_AssetManager.Services.AssetLiquidationService db = new Services.AssetLiquidationService();
            AssetLiquidation item = db.GetById(id);
            item.AssetId = AssetId;
            item.DepartmentUsedId = DepartmentUsedId;
            item.LiDateTime = DateTime.Parse(LiDateTime);
            item.LiPrice = Convert.ToInt64(LiPrice);
            db.Update(item);
            return "Update item successful";
        }

        [WebMethod]
        public List<AssetLiquidation> GetAllAssetLiquidation()
        {
            cunghoc3_AssetManager.Services.AssetLiquidationService db = new Services.AssetLiquidationService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public AssetLiquidation GetAssetLiquidationById(string id)
        {
            cunghoc3_AssetManager.Services.AssetLiquidationService db = new Services.AssetLiquidationService();
            return db.GetById(id);
        }

        [WebMethod]
        public string DelAssetLiquidationById(string id)
        {
            cunghoc3_AssetManager.Services.AssetLiquidationService db = new Services.AssetLiquidationService();
            AssetLiquidation item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

        [WebMethod]
        public int NewRepairAsset(string Id, string AssetId, string DepartmentUsedId, string PartnerId, string Address, string RepairDate, string Fee)
        {
            try
            {
                var db = new Services.RepairAssetService();
                if (GetRepairAssetById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new RepairAsset
                {
                    Id = Id,
                    AssetId = AssetId,
                    DepartmentUsedId = DepartmentUsedId,
                    PartnerId = PartnerId,
                    Address = Address,
                    RepairDate = DateTime.Parse(RepairDate),
                    Fee = Convert.ToInt64(Fee)
                })
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }

        }

        [WebMethod]
        public string UpdateRepairAsset(string id, string AssetId, string DepartmentUsedId, string PartnerId, string Address, string RepairDate, string Fee)
        {
            cunghoc3_AssetManager.Services.RepairAssetService db = new Services.RepairAssetService();
            RepairAsset item = db.GetById(id);
            item.AssetId = AssetId;
            item.DepartmentUsedId = DepartmentUsedId;
            item.PartnerId = PartnerId;
            item.Address = Address;
            item.RepairDate = DateTime.Parse(RepairDate);
            item.Fee = Convert.ToInt64(Fee);
            db.Update(item);
            return "Update item successful";
        }

        [WebMethod]
        public List<RepairAsset> GetAllRepairAsset()
        {
            cunghoc3_AssetManager.Services.RepairAssetService db = new Services.RepairAssetService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public RepairAsset GetRepairAssetById(string id)
        {
            cunghoc3_AssetManager.Services.RepairAssetService db = new Services.RepairAssetService();
            return db.GetById(id);
        }

        [WebMethod]
        public string DelRepairAssetById(string id)
        {
            cunghoc3_AssetManager.Services.RepairAssetService db = new Services.RepairAssetService();
            RepairAsset item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

        [WebMethod]
        public int NewWarrantyAsset(string Id, string AssetId, string DepartmentUsedId, string PartnerId, string WarDateTime, string DeadlineWar, string Address, string PersonWar)
        {
            try
            {
                var db = new Services.WarrantyAssetService();
                if (GetWarrantyAssetById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new WarrantyAsset
                {
                    Id = Id,
                    AssetId = AssetId,
                    DepartmentUsedId = DepartmentUsedId,
                    PartnerId = PartnerId,
                    WarDateTime = DateTime.Parse(WarDateTime),
                    DeadlineWar = DateTime.Parse(DeadlineWar),
                    Address = Address,
                    PersonWar = PersonWar
                })
                {
                    if (db.Insert(item))
                    {
                        return (int)CommonEnums.RetCode.SUCCESS;
                    }
                }
                return (int)CommonEnums.RetCode.OTHER;
            }
            catch (Exception ex)
            {
                return (int)CommonEnums.RetCode.SYSTEM_ERROR;
            }
        }

        [WebMethod]
        public string UpdateWarrantyAsset(string id, string AssetId, string DepartmentUsedId, string PartnerId, string WarDateTime, string DeadlineWar, string Address, string PersonWar)
        {
            cunghoc3_AssetManager.Services.WarrantyAssetService db = new Services.WarrantyAssetService();
            WarrantyAsset item = db.GetById(id);
            item.AsssetId = AssetId;
            item.DepartmentUsedId = DepartmentUsedId;
            item.PartnerId = PartnerId;
            item.WarDateTime = DateTime.Parse(WarDateTime);
            item.DeadlineWar = DateTime.Parse(DeadlineWar);
            item.Address = Address;
            item.PersonWar = PersonWar;
            return "Update item successful";
        }

        [WebMethod]
        public List<WarrantyAsset> GetAllWarrantyAsset()
        {
            cunghoc3_AssetManager.Services.WarrantyAssetService db = new Services.WarrantyAssetService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public WarrantyAsset GetWarrantyAssetById(string id)
        {
            cunghoc3_AssetManager.Services.WarrantyAssetService db = new Services.WarrantyAssetService();
            return db.GetById(id);
        }

        [WebMethod]
        public string DelWarrantyAssetById(string id)
        {
            cunghoc3_AssetManager.Services.WarrantyAssetService db = new Services.WarrantyAssetService();
            WarrantyAsset item = db.GetById(id);
            db.Delete(item);
            return "Delete item successful";
        }

    }
}