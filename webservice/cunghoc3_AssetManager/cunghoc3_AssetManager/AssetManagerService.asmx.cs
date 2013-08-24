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
        public int NewAssetGroupType(string name)
        {
            try
            {
                var id = "AGT_"+randomId.Next(100000,999999).ToString();
                while ((GetAssetGroupTypeById(id) == null))
                {
                    id = "AGT_" + randomId.Next(100000, 999999).ToString();
                }
                var db = new Services.AssetGroupTypeService();
                if (GetAssetGroupTypeById(id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new AssetGroupType
                {
                    Id = id,
                    Name = name,
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
        public ResultObject<List<AssetGroupType>> GetAllAssetGroupType()
        {
            var resultObject = new ResultObject<List<AssetGroupType>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            cunghoc3_AssetManager.Services.AssetGroupTypeService db = new Services.AssetGroupTypeService();
            resultObject.RetObject = db.GetAll().ToList();
            resultObject.Message = "Get AssetGroupType list success";
            return resultObject;
        }

        [WebMethod]
        public ResultObject<AssetGroupType> GetAssetGroupTypeById(string id)
        {
            var resultObject = new ResultObject<AssetGroupType> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            cunghoc3_AssetManager.Services.AssetGroupTypeService db = new Services.AssetGroupTypeService();
            resultObject.RetObject = db.GetById(id);
            if(resultObject.RetObject!=null)
                resultObject.Message = "Get AssetGroupType by Id success";
            else
                resultObject.Message = "Get AssetGroupTypeId not exist";
            return resultObject;
        }

        [WebMethod]
        public int DelAssetGroupTypeById(string id)
        {
            cunghoc3_AssetManager.Services.AssetGroupTypeService db = new Services.AssetGroupTypeService();
            AssetGroupType item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public int UpdateAssetGroupType(string id, string name)
        {
            cunghoc3_AssetManager.Services.AssetGroupTypeService db = new Services.AssetGroupTypeService();
            AssetGroupType item = db.GetById(id);
            item.Name = name;
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
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
        public ResultObject<List<AssetGroup>> GetAllAssetGroup()
        {
            var resultObject = new ResultObject<List<AssetGroup>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            resultObject.RetObject = db.GetAll().ToList();
            resultObject.Message = "Get AssetGroup list success";
            return resultObject;
        }

        [WebMethod]
        public ResultObject<AssetGroup> GetAssetGroupById(string id)
        {
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            var resultObject = new ResultObject<AssetGroup> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            resultObject.RetObject = db.GetById(id);
            if (resultObject.RetObject != null)
                resultObject.Message = "Get AssetGroup by Id success";
            else
                resultObject.Message = "Get AssetGroup not exist";
            return resultObject;
        }

        [WebMethod]
        public int DelAssetGroupById(string id)
        {
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            AssetGroup item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public int UpdateAssetGroup(string id, string Name, string AssetGroupTypeId)
        {
            cunghoc3_AssetManager.Services.AssetGroupService db = new Services.AssetGroupService();
            AssetGroup item = db.GetById(id);
            item.Name = Name;
            item.AssetGroupTypeId = AssetGroupTypeId;
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
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
        public ResultObject<List<Capital>> GetAllCapitalGroup()
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            var resultObject = new ResultObject<List<Capital>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            resultObject.RetObject = db.GetAll().ToList();
            resultObject.Message = "Get Capital list success";
            return resultObject;
        }

        [WebMethod]
        public ResultObject<Capital> GetCapitalById(string id)
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            var resultObject = new ResultObject<Capital> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            resultObject.RetObject = db.GetById(id);
            if (resultObject.RetObject != null)
                resultObject.Message = "Get Capital by Id success";
            else
                resultObject.Message = "Get Capital not exist";
            return resultObject;
        }

        [WebMethod]
        public int DelCapitalById(string id)
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            Capital item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public int UpdateCapital(string id, string Name, string Note)
        {
            cunghoc3_AssetManager.Services.CapitalService db = new Services.CapitalService();
            Capital item = db.GetById(id);
            item.Name = Name;
            item.Note = Note;
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public int NewDepartmentUsed(string Name, string Phone, string Representative, string Address)
        {
            try
            {
                var id = "DU_"+randomId.Next(100000,999999).ToString();
                while ((GetDepartmentUsedById(id) == null))
                {
                    id = "DU_" + randomId.Next(100000, 999999).ToString();
                }
                var db = new Services.DepartmentUsedService();
                using (var item = new DepartmentUsed
                {
                    Id = id,
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
        public int UpdateDepartmentUsed(string id, string Name, string Phone, string Representative, string Address)
        {
            cunghoc3_AssetManager.Services.DepartmentUsedService db = new Services.DepartmentUsedService();
            DepartmentUsed item = db.GetById(id);
            item.Name = Name;
            item.Phone = Phone;
            item.Representative = Representative;
            item.Address = Address;
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public ResultObject<List<DepartmentUsed>> GetAllDepartmentUsed()
        {
            cunghoc3_AssetManager.Services.DepartmentUsedService db = new Services.DepartmentUsedService();
            var resultObject = new ResultObject<List<DepartmentUsed>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            resultObject.RetObject = db.GetAll().ToList();
            resultObject.Message = "Get DepartmentUsed list success";
            return resultObject;
        }

        [WebMethod]
        public ResultObject<DepartmentUsed> GetDepartmentUsedById(string id)
        {
            cunghoc3_AssetManager.Services.DepartmentUsedService db = new Services.DepartmentUsedService();
            var resultObject = new ResultObject<DepartmentUsed> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
	        resultObject.RetObject = db.GetById(id);
            if(resultObject.RetObject!=null)
                resultObject.Message = "Get DepartmentUsed by Id success";
            else
                resultObject.Message = "Get DepartmentUsed not exist";
            return resultObject;
        }

        [WebMethod]
        public int DelDepartmentUsedById(string id)
        {
            cunghoc3_AssetManager.Services.DepartmentUsedService db = new Services.DepartmentUsedService();
            DepartmentUsed item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
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
        public int UpdateUnit(string id, string Name, string Note)
        {
            cunghoc3_AssetManager.Services.UnitService db = new Services.UnitService();
            Unit item = db.GetById(id);
            item.Name = Name;
            item.Note = Note;
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public ResultObject<List<Unit>> GetAllUnit()
        {
            cunghoc3_AssetManager.Services.UnitService db = new Services.UnitService();
            var resultObject = new ResultObject<List<Unit>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            resultObject.RetObject = db.GetAll().ToList();
            resultObject.Message = "Get Unit list success";
            return resultObject;
        }

        [WebMethod]
        public ResultObject<Unit> GetUnitById(string id)
        {
            cunghoc3_AssetManager.Services.UnitService db = new Services.UnitService();
            var resultObject = new ResultObject<Unit> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
	        resultObject.RetObject = db.GetById(id);
            if(resultObject.RetObject!=null)
                resultObject.Message = "Get Unit by Id success";
            else
                resultObject.Message = "Get Unit not exist";
            return resultObject;
        }

        [WebMethod]
        public int DelUnitById(string id)
        {
            cunghoc3_AssetManager.Services.UnitService db = new Services.UnitService();
            Unit item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]

        public int NewAsset(string assetNumber,string name, string assetGroupId, string unitId, int amount, string counPro, int yearPro, string departmentUsedId, long totalPrice, long bugetPrice, long ownPrice, long venturePrice, long anotherPrice, long totalDepreciation, long bugetDepreciation, long ownDepreciation, long ventureDepreciation, long anotherDepreciation, long bugeRemain, long ownRemain, long ventureRemain, long anotherRemain, long totalRemain, string upDownCode, string manufacturer, string brand, string model, short status, short condition, DateTime dueDate, string note, string seriesNumber)

        {
            var inputDateTime = DateTime.Today;
            try
            {
                var db = new Services.AssetService();
                if (GetAssetById(assetNumber) != null)
                {
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
                    InputDateTime = inputDateTime,
                    Manufacturer = manufacturer,
                    Brand = brand,
                    Model = model,
                    Status = status,
                    Condition = condition,
                    DueDate = dueDate,
                    Note = note,
                    SeriesNumber = seriesNumber
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
        public int UpdateAsset(string id, string Name, string AssetGroupId, string UnitId, string Amount, string CounPro, string YearPro, string DepartmentUsedId, string TotalPrice, string BugetPrice, string OwnPrice, string VenturePrice, string AnotherPrice, string TotalDepreciation, string BugetDepreciation, string OwnDepreciation, string VentureDepreciation, string AnotherDepreciation, string BugeRemain, string OwnRemain, string VentureRemain, string AnotherRemain, string TotalRemain, string UpDownCode, string InputDateTime)
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
            return (int)CommonEnums.RetCode.SUCCESS;
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
                                 let unit = GetUnitById(asset.UnitId).RetObject
                                 let departmentUsed = GetDepartmentUsedById(asset.DepartmentUsedId).RetObject
                                 let assetGroup = GetAssetGroupById(asset.AssetGroupId).RetObject
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
        public ResultObject<List<AssetData>> GetAssetByAssetGroupTypeId(string AssetGroupTypeId)
        {
              var resultObject = new ResultObject<List<AssetData>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            try
            {
                var db = new Services.AssetService();
                
                var assets = db.GetByAssetGroupId(AssetGroupTypeId);
                var assetsList= (from asset in assets
                                 let unit = GetUnitById(asset.UnitId).RetObject
                                 let departmentUsed = GetDepartmentUsedById(asset.DepartmentUsedId).RetObject
                                 let assetGroup = GetAssetGroupById(asset.AssetGroupId).RetObject
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
                resultObject.RetCode = (int)CommonEnums.RetCode.SYSTEM_ERROR;
                return resultObject;
            }
        }

        [WebMethod]
        public ResultObject<Asset> GetAssetById(string id)
        {
            cunghoc3_AssetManager.Services.AssetService db = new Services.AssetService();
            var resultObject = new ResultObject<Asset> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            resultObject.RetObject = db.GetById(id);
            if (resultObject.RetObject != null)
                resultObject.Message = "Get Asset by Id success";
            else
                resultObject.Message = "Get Asset not exist";
            return resultObject;
        }

        [WebMethod]
        public int IncresaseAsset(string id, int count)
        {
            cunghoc3_AssetManager.Services.AssetService db = new Services.AssetService();
            var resultObject = new ResultObject<Asset> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            var asset = db.GetById(id);
            for (int i = 0; i < count; i++)
            {
                int num = randomId.Next(1000000, 9999999);
                string newId = "AS_" + num;
                while (GetAssetById(newId).RetObject == null)
                {
                    num = randomId.Next(1000000, 9999999);
                    newId = "AS_" + num;
                }
                var newAsset = asset;
                newAsset.Id = newId;
                db.Insert(newAsset);
            }
            return (int)CommonEnums.RetCode.SUCCESS;
        }
        [WebMethod]
        public ResultObject<List<AssetData>> GetAssetByDepartmentUsedId(string DepartmentUsedId)
        {
            var resultObject = new ResultObject<List<AssetData>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            try
            {
                var db = new Services.AssetService();

                var assets = db.GetByDepartmentUsedId(DepartmentUsedId);
                var assetsList = (from asset in assets
                                  let unit = GetUnitById(asset.UnitId).RetObject
                                  let departmentUsed = GetDepartmentUsedById(asset.DepartmentUsedId).RetObject
                                  let assetGroup = GetAssetGroupById(asset.AssetGroupId).RetObject
                                  select new AssetData
                                  {
                                      Amount = asset.Amount,
                                      AnotherDepreciation = asset.AnotherDepreciation,
                                      AnotherPrice = asset.AnotherPrice,
                                      AnotherRemain = asset.AnotherRemain,
                                      BugeRemain = asset.BudgetRemain,
                                      BugetDepreciation = asset.BudgetDepreciation,
                                      BugetPrice = asset.BudgetPrice,
                                      CounPro = asset.CounPro,
                                      Id = asset.Id,
                                      InputDateTime = asset.InputDateTime,
                                      Name = asset.Name,
                                      OwnDepreciation = asset.OwnDepreciation,
                                      OwnPrice = asset.OwnPrice,
                                      OwnRemain = asset.OwnRemain,
                                      TotalDepreciation = asset.TotalDepreciation,
                                      TotalPrice = asset.TotalPrice,
                                      TotalRemain = asset.TotalReamain,
                                      UpDownCode = asset.UpDownCode,
                                      VentureDepreciation = asset.VentureDepreciation,
                                      VenturePrice = asset.VenturePrice,
                                      VentureRemain = asset.VentureRemain,
                                      YearPro = asset.YearPro,
                                      //refer
                                      Unit = unit.Name,
                                      DepartmentUsed = departmentUsed.Name,
                                      AssetGroup = assetGroup.Name
                                  }).ToList();
                resultObject.RetObject = assetsList;
                resultObject.Message = "Get asset list success";
                return resultObject;
            }
            catch (Exception ex)
            {
                resultObject.RetCode = (int)CommonEnums.RetCode.SYSTEM_ERROR;
                return resultObject;
            }
        }

        [WebMethod]
        public int DelAssetById(string id)
        {
            cunghoc3_AssetManager.Services.AssetService db = new Services.AssetService();
            Asset item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
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
        public int UpdatePartner(string id, string Name, string Phone, string TaxCode, string Address)
        {
            cunghoc3_AssetManager.Services.PartnerService db = new Services.PartnerService();
            Partner item = db.GetById(id);
            item.Name = Name;
            item.Phone = Phone;
            item.Address = Address;
            item.TaxCode = TaxCode;
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public ResultObject<List<Partner>> GetAllPartner()
        {
            cunghoc3_AssetManager.Services.PartnerService db = new Services.PartnerService();
            var resultObject = new ResultObject<List<Partner>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            resultObject.RetObject = db.GetAll().ToList();
            resultObject.Message = "Get Partner list success";
            return resultObject;
        }

        [WebMethod]
        public ResultObject<Partner> GetPartnerById(string id)
        {
            cunghoc3_AssetManager.Services.PartnerService db = new Services.PartnerService();
            var resultObject = new ResultObject<Partner> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
	        resultObject.RetObject = db.GetById(id);
            if(resultObject.RetObject!=null)
                resultObject.Message = "Get Partner by Id success";
            else
                resultObject.Message = "Get Partner not exist";
            return resultObject;
        }

        [WebMethod]
        public int DelPartnerById(string id)
        {
            cunghoc3_AssetManager.Services.PartnerService db = new Services.PartnerService();
            Partner item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
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
        public int UpdateUpDownReason(string id, string Name, string Type)
        {
            cunghoc3_AssetManager.Services.UpDownReasonService db = new Services.UpDownReasonService();
            UpDownReason item = db.GetById(id);
            item.Name = Name;
            item.Type = Type;
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public ResultObject<List<UpDownReason>> GetAllUpDownReason()
        {
            cunghoc3_AssetManager.Services.UpDownReasonService db = new Services.UpDownReasonService();
            var resultObject = new ResultObject<List<UpDownReason>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            resultObject.RetObject = db.GetAll().ToList();
            resultObject.Message = "Get UpDownReason list success";
            return resultObject;
        }

        [WebMethod]
        public ResultObject<UpDownReason> GetUpDownReasonById(string id)
        {
            cunghoc3_AssetManager.Services.UpDownReasonService db = new Services.UpDownReasonService();
            var resultObject = new ResultObject<UpDownReason> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
	        resultObject.RetObject = db.GetById(id);
            if(resultObject.RetObject!=null)
                resultObject.Message = "Get UpDownReason by Id success";
            else
                resultObject.Message = "Get UpDownReason not exist";
            return resultObject;
        }

        [WebMethod]
        public int DelUpDownReasonById(string id)
        {
            cunghoc3_AssetManager.Services.UpDownReasonService db = new Services.UpDownReasonService();
            UpDownReason item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
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
        public int UpdateAssetLiquidation(string id, string AssetId, string DepartmentUsedId, string LiDateTime, string LiPrice)
        {
            cunghoc3_AssetManager.Services.AssetLiquidationService db = new Services.AssetLiquidationService();
            AssetLiquidation item = db.GetById(id);
            item.AssetId = AssetId;
            item.DepartmentUsedId = DepartmentUsedId;
            item.LiDateTime = DateTime.Parse(LiDateTime);
            item.LiPrice = Convert.ToInt64(LiPrice);
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public ResultObject<List<AssetLiquidationData>> GetAllAssetLiquidation()
        {
            cunghoc3_AssetManager.Services.AssetLiquidationService db = new Services.AssetLiquidationService();
            var resultObject = new ResultObject<List<AssetLiquidationData>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            var aLList = db.GetAll().ToList();
            foreach (AssetLiquidation al in aLList)
            {
                AssetLiquidationData ald = new AssetLiquidationData() {
                    Id = al.Id,
                    AssetName = GetAssetById(al.AssetId).RetObject.Name,
                    DepartmentUsedName = GetDepartmentUsedById(al.DepartmentUsedId).RetObject.Name,
                    LiDateTime = al.LiDateTime,
                    LiPrice = al.LiPrice
                };
                resultObject.RetObject.Add(ald);
            }
            resultObject.Message = "Get AssetLiquidationData list success";
            return resultObject;
        }

        [WebMethod]
        public ResultObject<AssetLiquidationData> GetAssetLiquidationById(string id)
        {
            cunghoc3_AssetManager.Services.AssetLiquidationService db = new Services.AssetLiquidationService();
            var resultObject = new ResultObject<AssetLiquidationData> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            var al = db.GetById(id);
            AssetLiquidationData ald = new AssetLiquidationData()
            {
                Id = al.Id,
                AssetName = GetAssetById(al.AssetId).RetObject.Name,
                DepartmentUsedName = GetDepartmentUsedById(al.DepartmentUsedId).RetObject.Name,
                LiDateTime = al.LiDateTime,
                LiPrice = al.LiPrice
            };
            resultObject.RetObject = ald;
            if(resultObject.RetObject!=null)
                resultObject.Message = "Get AssetLiquidation by Id success";
            else
                resultObject.Message = "Get AssetLiquidation not exist";
            return resultObject;
        }

        [WebMethod]
        public int DelAssetLiquidationById(string id)
        {
            cunghoc3_AssetManager.Services.AssetLiquidationService db = new Services.AssetLiquidationService();
            AssetLiquidation item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
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
        public int UpdateRepairAsset(string id, string AssetId, string DepartmentUsedId, string PartnerId, string Address, string RepairDate, string Fee)
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
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public ResultObject<List<RepairAssetData>> GetAllRepairAsset()
        {
            cunghoc3_AssetManager.Services.RepairAssetService db = new Services.RepairAssetService();
            var resultObject = new ResultObject<List<RepairAssetData>> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            var list = db.GetAll().ToList();
            foreach (RepairAsset item in list)
            {
                RepairAssetData itemData = new RepairAssetData()
                {
                    Id = item.Id,
                    AssetName = GetAssetById(item.AssetId).RetObject.Name,
                    DepartmentUsedName = GetDepartmentUsedById(item.DepartmentUsedId).RetObject.Name,
                    PartnerName = GetPartnerById(item.PartnerId).RetObject.Name,
                    Address = item.Address,
                    Fee = item.Fee,
                    RepairDate = item.RepairDate
                };
                resultObject.RetObject.Add(itemData);
            }
            resultObject.Message = "Get RepairAsset list success";
            return resultObject;
        }

        [WebMethod]
        public ResultObject<RepairAssetData> GetRepairAssetById(string id)
        {
            cunghoc3_AssetManager.Services.RepairAssetService db = new Services.RepairAssetService();
            var resultObject = new ResultObject<RepairAssetData> { RetCode = (int)CommonEnums.RetCode.SUCCESS };
            var item = db.GetById(id);
            RepairAssetData itemData = new RepairAssetData()
            {
                Id = item.Id,
                AssetName = GetAssetById(item.AssetId).RetObject.Name,
                DepartmentUsedName = GetDepartmentUsedById(item.DepartmentUsedId).RetObject.Name,
                PartnerName = GetPartnerById(item.PartnerId).RetObject.Name,
                Address = item.Address,
                Fee = item.Fee,
                RepairDate = item.RepairDate
            };
            resultObject.RetObject = itemData;
            if (resultObject.RetObject != null)
                resultObject.Message = "Get RepairAssetData by Id success";
            else
                resultObject.Message = "Get RepairAssetData not exist";
            return resultObject;
        }

        [WebMethod]
        public int DelRepairAssetById(string id)
        {
            cunghoc3_AssetManager.Services.RepairAssetService db = new Services.RepairAssetService();
            RepairAsset item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
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
                    AsssetId = AssetId,
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
        public int UpdateWarrantyAsset(string id, string AssetId, string DepartmentUsedId, string PartnerId, string WarDateTime, string DeadlineWar, string Address, string PersonWar)
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
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
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
        public int DelWarrantyAssetById(string id)
        {
            cunghoc3_AssetManager.Services.WarrantyAssetService db = new Services.WarrantyAssetService();
            WarrantyAsset item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public int NewImage(long Id, string AssetId, string ImageURL)
        {
            try
            {
                var db = new Services.ImageService();
                if (GetImageById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new Image
                {
                    Id = Id,
                    AssetId = AssetId,
                    ImageUrl = ImageURL

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
        public int UpdateImage(long id, string AssetId, string ImageURL)
        {
            cunghoc3_AssetManager.Services.ImageService db = new Services.ImageService();
            Image item = db.GetById(id);
            item.AssetId = AssetId;
            item.ImageUrl = ImageURL;
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public Image GetImageById(long id)
        {
            cunghoc3_AssetManager.Services.ImageService db = new Services.ImageService();
            return db.GetById(id);
        }

        [WebMethod]
        public int DelImageById(long id)
        {
            cunghoc3_AssetManager.Services.ImageService db = new Services.ImageService();
            Image item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public int NewAudit(long Id, string AssetId, DateTime AuditDate, string Comment, string User, string Computer)
        {
            try
            {
                var db = new Services.AuditService();
                if (GetAuditById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new Audit
                {
                    Id = Id,
                    AssetId = AssetId,
                    AuditDate = AuditDate,
                    Comment = Comment,
                    User = User,
                    Computer = Computer
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
        public int UpdateAudit(long Id, string AssetId, DateTime AuditDate, string Comment, string User, string Computer)
        {
            cunghoc3_AssetManager.Services.AuditService db = new Services.AuditService();
            Audit item = db.GetById(Id);
            item.AssetId = AssetId;
            item.AuditDate = AuditDate;
            item.Comment = Comment;
            item.User = User;
            item.Computer = Computer;
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public Audit GetAuditById(long id)
        {
            cunghoc3_AssetManager.Services.AuditService db = new Services.AuditService();
            return db.GetById(id);
        }

        [WebMethod]
        public int DelAuditById(long id)
        {
            cunghoc3_AssetManager.Services.AuditService db = new Services.AuditService();
            Audit item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public int NewCheckOut(long Id, string AssetId, DateTime CheckOutDate, string Comment, string User, string Computer, short Status)
        {
            try
            {
                var db = new Services.CheckOutService();
                if (GetCheckOutById(Id) != null)
                {
                    return (int)CommonEnums.RetCode.DATA_ALREADY_EXIST;
                }
                using (var item = new CheckOut
                {
                    Id = Id,
                    AssetId = AssetId,
                    CheckOutDate = CheckOutDate,
                    Comment = Comment,
                    User = User,
                    Computer = Computer
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
        public int UpdateCheckOut(long Id, string AssetId, DateTime CheckOutDate, string Comment, string User, string Computer)
        {
            cunghoc3_AssetManager.Services.CheckOutService db = new Services.CheckOutService();
            CheckOut item = db.GetById(Id);
            item.AssetId = AssetId;
            item.CheckOutDate = CheckOutDate;
            item.Comment = Comment;
            item.User = User;
            item.Computer = Computer;
            db.Update(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

        [WebMethod]
        public List<CheckOut> GetAllCheckOut()
        {
            cunghoc3_AssetManager.Services.CheckOutService db = new Services.CheckOutService();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public CheckOut GetCheckOutById(long id)
        {
            cunghoc3_AssetManager.Services.CheckOutService db = new Services.CheckOutService();
            return db.GetById(id);
        }

        [WebMethod]
        public int DelCheckOutById(long id)
        {
            cunghoc3_AssetManager.Services.CheckOutService db = new Services.CheckOutService();
            CheckOut item = db.GetById(id);
            db.Delete(item);
            return (int)CommonEnums.RetCode.SUCCESS;
        }

    }
}