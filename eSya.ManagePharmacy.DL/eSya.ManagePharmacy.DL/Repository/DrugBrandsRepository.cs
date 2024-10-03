using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSya.ManagePharmacy.DL.Entities;
using eSya.ManagePharmacy.DO;
using eSya.ManagePharmacy.IF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace eSya.ManagePharmacy.DL.Repository
{
    public class DrugBrandsRepository : IDrugBrandsRepository
    {
        private readonly IStringLocalizer<DrugBrandsRepository> _localizer;

        #region Drug Brand
        public DrugBrandsRepository(IStringLocalizer<DrugBrandsRepository> localizer)
        {
            _localizer = localizer;
        }
        public async Task<List<DO_DrugBrands>> GetDrugBrandList()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEphmdbs
                        .Select(r => new DO_DrugBrands
                        {
                            TradeID = r.TradeId,
                            TradeName = r.TradeName
                        }).OrderBy(o => o.TradeName).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_DrugBrands>> GetFullDrugBrandList()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {


                    var result = await db.GtEphmdbs
                        .Join(db.GtEcapcds,
                       a => a.Packing,
                       p => p.ApplicationCode,
                       (a, p) => new { a, p })
                        .Join(db.GtEskucds.Where(q => q.Skutype == "D"),
                         x => x.a.TradeId,
                         y => y.Skucode,
                         (x, y) => new { x, y })
                         .Select(r => new DO_DrugBrands
                         {
                             Skuid = r.y.Skuid,
                             CompositionID = r.x.a.CompositionId,
                             FormulationID = r.x.a.FormulationId,
                             TradeID = r.x.a.TradeId,
                             TradeName = r.x.a.TradeName,
                             PackSize = r.x.a.PackSize,
                             Packing = r.x.a.Packing,
                             PackingDesc = r.x.p.CodeDesc,
                             ManufacturerID = r.x.a.ManufacturerId,
                             ISDCode = r.x.a.Isdcode,
                             BarcodeID = r.x.a.BarcodeId,
                             ActiveStatus = r.x.a.ActiveStatus,
                             Skutype = r.y.Skutype,
                             Skucode = r.y.Skucode

                         }).ToListAsync();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_DrugBrands>> GetDrugBrandListByGroup(int CompositionID, int FormulationID, int ManufacturerID)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var result = await db.GtEphmdbs.Where(w => w.CompositionId == CompositionID && w.FormulationId == FormulationID && w.ManufacturerId == ManufacturerID)
                        .Join(db.GtEcapcds,
                       a => a.Packing,
                       p => p.ApplicationCode,
                       (a, p) => new { a, p })
                        .Join(db.GtEskucds.Where(q => q.Skutype == "D"),
                        x => x.a.TradeId,
                        y => y.Skucode,
                        (x, y) => new { x, y })
                        .Select(r => new DO_DrugBrands
                        {
                            Skuid = r.y.Skuid,
                            CompositionID = r.x.a.CompositionId,
                            FormulationID = r.x.a.FormulationId,
                            TradeID = r.x.a.TradeId,
                            TradeName = r.x.a.TradeName,
                            PackSize = r.x.a.PackSize,
                            Packing = r.x.a.Packing,
                            PackingDesc = r.x.p.CodeDesc,
                            ManufacturerID = r.x.a.ManufacturerId,
                            ISDCode = r.x.a.Isdcode,
                            BarcodeID = r.x.a.BarcodeId,
                            ActiveStatus = r.x.a.ActiveStatus,
                            Skutype = r.y.Skutype,
                            Skucode = r.y.Skucode
                        }).ToListAsync();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_DrugBrands>> GetDrugBrandListByTradeID(int TradeID)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {


                    var result = await db.GtEphmdbs.Where(w => w.TradeId == TradeID)
                        .Join(db.GtEcapcds,
                       a => a.Packing,
                       p => p.ApplicationCode,
                       (a, p) => new { a, p })
                        .Join(db.GtEskucds.Where(q => q.Skutype == "D"),
                         x => x.a.TradeId,
                         y => y.Skucode,
                         (x, y) => new { x, y })
                         .Select(r => new DO_DrugBrands
                         {
                             Skuid = r.y.Skuid,
                             CompositionID = r.x.a.CompositionId,
                             FormulationID = r.x.a.FormulationId,
                             TradeID = r.x.a.TradeId,
                             TradeName = r.x.a.TradeName,
                             PackSize = r.x.a.PackSize,
                             Packing = r.x.a.Packing,
                             PackingDesc = r.x.p.CodeDesc,
                             ManufacturerID = r.x.a.ManufacturerId,
                             ISDCode = r.x.a.Isdcode,
                             BarcodeID = r.x.a.BarcodeId,
                             ActiveStatus = r.x.a.ActiveStatus,
                             Skutype = r.y.Skutype,
                             Skucode = r.y.Skucode

                         }).ToListAsync();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DO_DrugBrands> GetDrugBrandParameterList(int TradeID)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var ds = db.GtEphmdbs
                        .Where(w => w.TradeId == TradeID)
                        .Select(r => new DO_DrugBrands
                        {
                            l_FormParameter =db.GtEphdpas.Where(x=>x.TradeId==TradeID).Select(p => new DO_eSyaParameter
                            {
                                ParameterID = p.ParameterId,
                                ParmAction = p.ParmAction,
                                ParmPerct = p.ParmPerc,
                                ParmDesc = p.ParmDesc,
                                ParmValue = p.ParmValue
                            }).ToList()
                        }).FirstOrDefaultAsync();

                    return await ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public async Task<List<DO_BusinessLocation>> GetBusinessKey(int TradeId)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = await db.GtEcbslns.Where(x => x.ActiveStatus)
                        .Select(r => new DO_BusinessLocation
                        {
                            BusinessKey = r.BusinessKey,
                            TradeID = TradeId,
                            LocationDescription = r.BusinessName + "-" + r.LocationDescription,
                            ActiveStatus = false,
                        }).ToListAsync();

                    foreach (var obj in ds)
                    {
                        GtEphdbl pf = db.GtEphdbls.Where(x => x.BusinessKey == obj.BusinessKey && x.TradeId == obj.TradeID).FirstOrDefault();
                        if (pf != null)
                        {
                            obj.ActiveStatus = pf.ActiveStatus;
                        }
                        else
                        {
                            obj.ActiveStatus = false;

                        }
                    }
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DO_ReturnParameter> InsertDrugBrands(DO_DrugBrands obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEphmdb is_itemDescExists = db.GtEphmdbs.FirstOrDefault(u => u.TradeName.ToUpper().Replace(" ", "") == obj.TradeName.ToUpper().Replace(" ", ""));
                        if (is_itemDescExists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0127", Message = string.Format(_localizer[name: "W0127"]) };
                        }

                        int _tradeId = db.GtEphmdbs.Select(c => c.TradeId).DefaultIfEmpty().Max();
                        _tradeId = _tradeId + 1;

                        var b_Entity = new GtEphmdb
                        {
                            CompositionId = obj.CompositionID,
                            FormulationId = obj.FormulationID,
                            TradeId = _tradeId,
                            TradeName = obj.TradeName,
                            PackSize = obj.PackSize,
                            Packing = obj.Packing,
                            ManufacturerId = obj.ManufacturerID,
                            Isdcode = obj.ISDCode,
                            BarcodeId = obj.BarcodeID,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormID,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID
                        };
                        db.GtEphmdbs.Add(b_Entity);

                        foreach (DO_eSyaParameter ip in obj.l_FormParameter)
                        {
                            var pMaster = new GtEphdpa
                            {
                                TradeId = _tradeId,
                                ParameterId = ip.ParameterID,
                                ParmPerc = ip.ParmPerct,
                                ParmAction = ip.ParmAction,
                                ParmDesc = ip.ParmDesc,
                                ParmValue = ip.ParmValue,
                                ActiveStatus = ip.ActiveStatus,
                                FormId = obj.FormID,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtEphdpas.Add(pMaster);
                        }

                        foreach (DO_BusinessLocation ib in obj.l_BusinessLocation)
                        {
                            var bMaster = new GtEphdbl
                            {
                                BusinessKey = ib.BusinessKey,
                                TradeId = _tradeId,
                                ActiveStatus = ib.ActiveStatus,
                                FormId = obj.FormID,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtEphdbls.Add(bMaster);

                            int _srNo = db.GtEphdmls.Select(c => c.SerialNumber).DefaultIfEmpty().Max();
                            _srNo = _srNo + 1;

                            var dml_Entity = new GtEphdml
                            {
                                BusinessKey = ib.BusinessKey,
                                TradeId = _tradeId,
                                ManufacturerId = obj.ManufacturerID,
                                SerialNumber = _srNo,
                                EffectiveFrom = System.DateTime.Now,
                                PurchaseRate = 0,
                                Mrp = 0,
                                ActiveStatus = ib.ActiveStatus,
                                FormId = obj.FormID,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtEphdmls.Add(dml_Entity);
                        }

                        await db.SaveChangesAsync();

                        int _skuid = db.GtEskucds.Select(c => c.Skuid).DefaultIfEmpty().Max();
                        _skuid = _skuid + 1;

                        var sku_Entity = new GtEskucd
                        {
                            Skuid = _skuid,
                            Skutype = obj.Skutype,
                            Skucode = _tradeId,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormID,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID
                        };
                        db.GtEskucds.Add(sku_Entity);
                        await db.SaveChangesAsync();

                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, StatusCode = "S0001", Message = string.Format(_localizer[name: "S0001"]) };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonRepository.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public async Task<DO_ReturnParameter> UpdateDrugBrands(DO_DrugBrands obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEphmdb is_tradeExists = db.GtEphmdbs.FirstOrDefault(be => be.TradeName.ToUpper().Replace(" ", "") == obj.TradeName.ToUpper().Replace(" ", "") && be.TradeId != obj.TradeID);
                        if (is_tradeExists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0127", Message = string.Format(_localizer[name: "W0127"]) };

                        }

                        GtEphmdb b_Entity = db.GtEphmdbs.Where(be => be.TradeId == obj.TradeID).FirstOrDefault();

                        if (b_Entity != null)
                        {
                            b_Entity.CompositionId = obj.CompositionID;
                            b_Entity.FormulationId = obj.FormulationID;
                            b_Entity.TradeId = obj.TradeID;
                            b_Entity.TradeName = obj.TradeName;
                            b_Entity.PackSize = obj.PackSize;
                            b_Entity.Packing = obj.Packing;
                            b_Entity.ManufacturerId = obj.ManufacturerID;
                            b_Entity.Isdcode = obj.ISDCode;
                            b_Entity.BarcodeId = obj.BarcodeID;
                            b_Entity.ActiveStatus = obj.ActiveStatus;
                            b_Entity.ModifiedBy = obj.UserID;
                            b_Entity.ModifiedOn = System.DateTime.Now;
                            b_Entity.ModifiedTerminal = obj.TerminalID;

                            await db.SaveChangesAsync();

                            foreach (DO_eSyaParameter ip in obj.l_FormParameter)
                            {
                                var sPar = db.GtEphdpas.Where(x => x.TradeId == obj.TradeID && x.ParameterId == ip.ParameterID).FirstOrDefault();
                                if (sPar != null)
                                {
                                    sPar.ParmAction = ip.ParmAction;
                                    sPar.ParmDesc = ip.ParmDesc;
                                    sPar.ParmPerc = ip.ParmPerct;
                                    sPar.ParmValue = ip.ParmValue;
                                    sPar.ActiveStatus = obj.ActiveStatus;
                                    sPar.ModifiedBy = obj.UserID;
                                    sPar.ModifiedOn = System.DateTime.Now;
                                    sPar.ModifiedTerminal = obj.TerminalID;
                                }
                                else
                                {
                                    var pMaster = new GtEphdpa
                                    {
                                        TradeId = obj.TradeID,
                                        ParameterId = ip.ParameterID,
                                        ParmPerc = ip.ParmPerct,
                                        ParmAction = ip.ParmAction,
                                        ParmDesc = ip.ParmDesc,
                                        ParmValue = ip.ParmValue,
                                        ActiveStatus = ip.ActiveStatus,
                                        FormId = obj.FormID,
                                        CreatedBy = obj.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = obj.TerminalID
                                    };
                                    db.GtEphdpas.Add(pMaster);
                                }
                                await db.SaveChangesAsync();
                            }

                            foreach (DO_BusinessLocation ib in obj.l_BusinessLocation)
                            {
                                GtEphdbl blink = db.GtEphdbls.Where(x => x.TradeId == obj.TradeID && x.BusinessKey == ib.BusinessKey).FirstOrDefault();
                                if (blink != null)
                                {
                                    blink.ActiveStatus = obj.ActiveStatus;
                                    blink.ModifiedBy = obj.UserID;
                                    blink.ModifiedOn = System.DateTime.Now;
                                    blink.ModifiedTerminal = obj.TerminalID;
                                }
                                else
                                {
                                    var bMaster = new GtEphdbl
                                    {
                                        TradeId = obj.TradeID,
                                        BusinessKey = ib.BusinessKey,
                                        ActiveStatus = ib.ActiveStatus,
                                        FormId = obj.FormID,
                                        CreatedBy = obj.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = obj.TerminalID
                                    };
                                    db.GtEphdbls.Add(bMaster);
                                }

                                GtEphdml mdllink = db.GtEphdmls.Where(x => x.TradeId == obj.TradeID && x.BusinessKey == ib.BusinessKey && x.ManufacturerId == obj.ManufacturerID).FirstOrDefault();
                                if (mdllink != null)
                                {
                                    mdllink.ActiveStatus = obj.ActiveStatus;
                                    mdllink.ModifiedBy = obj.UserID;
                                    mdllink.ModifiedOn = System.DateTime.Now;
                                    mdllink.ModifiedTerminal = obj.TerminalID;
                                }
                                else
                                {
                                    int _srNo = db.GtEphdmls.Select(c => c.SerialNumber).DefaultIfEmpty().Max();
                                    _srNo = _srNo + 1;
                                    var dml_Entity = new GtEphdml
                                    {
                                        BusinessKey = ib.BusinessKey,
                                        TradeId = obj.TradeID,
                                        ManufacturerId = obj.ManufacturerID,
                                        SerialNumber = _srNo,
                                        EffectiveFrom = System.DateTime.Now,
                                        PurchaseRate = 0,
                                        Mrp = 0,
                                        ActiveStatus = ib.ActiveStatus,
                                        FormId = obj.FormID,
                                        CreatedBy = obj.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = obj.TerminalID
                                    };
                                    db.GtEphdmls.Add(dml_Entity);
                                }
                                await db.SaveChangesAsync();
                            }

                            GtEskucd _sku = db.GtEskucds.FirstOrDefault(x => x.Skuid == obj.Skuid && x.Skucode == obj.Skucode);
                            if (_sku != null)
                            {
                                _sku.Skutype = obj.Skutype;
                                _sku.Skucode = obj.Skucode;
                                _sku.ActiveStatus = obj.ActiveStatus;
                                _sku.ModifiedBy = obj.UserID;
                                _sku.ModifiedOn = System.DateTime.Now;
                                _sku.ModifiedTerminal = obj.TerminalID;
                            }
                            await db.SaveChangesAsync();

                            dbContext.Commit();

                            return new DO_ReturnParameter() { Status = true, StatusCode = "S0002", Message = string.Format(_localizer[name: "S0002"]) };
                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0128", Message = string.Format(_localizer[name: "W0128"]) };

                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonRepository.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        #endregion Drug Brand

        #region Drug Manufacturer Link
        public async Task<List<DO_DrugManufacturerLink>> GetDrugManufacturerLink(int BusinessKey, int ManufacturerID)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var result = await db.GtEphdmls.Where(w => w.BusinessKey == BusinessKey && w.ManufacturerId == ManufacturerID)
                        .Join(db.GtEphmdbs,
                       a => a.TradeId,
                       p => p.TradeId,
                       (a, p) => new { a, p })
                        .Select(r => new DO_DrugManufacturerLink
                        {
                            //BusinessKey = r.a.BusinessKey,
                            //ManufacturerID = r.a.ManufacturerId,
                            TradeID = r.a.TradeId,
                            TradeName = r.p.TradeName,
                            EffectiveFrom = r.a.EffectiveFrom,
                            PurchaseRate = r.a.PurchaseRate,
                            MRP = r.a.Mrp,
                            LastMRPDate = r.a.LastMrpdate,
                            //EffectiveTill = r.a.EffectiveTill,
                            ActiveStatus = r.a.ActiveStatus
                        }).ToListAsync();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> AddOrUpdateDrugManufacturer(List<DO_DrugManufacturerLink> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var ser_br in obj)
                        {
                            GtEphdml mdllink = db.GtEphdmls.Where(x => x.BusinessKey == ser_br.BusinessKey && x.TradeId == ser_br.TradeID && x.ManufacturerId == ser_br.ManufacturerID && x.EffectiveTill == null && x.PurchaseRate ==0 && ser_br.PurchaseRate !=0).FirstOrDefault();
                            if (mdllink != null)
                            {
                                mdllink.EffectiveFrom = ser_br.EffectiveFrom;
                                mdllink.PurchaseRate = ser_br.PurchaseRate;
                                mdllink.Mrp = ser_br.MRP;
                                mdllink.LastMrpdate = ser_br.LastMRPDate;
                                mdllink.EffectiveTill = ser_br.EffectiveTill;
                                mdllink.ActiveStatus = ser_br.ActiveStatus;
                                mdllink.ModifiedBy = ser_br.UserID;
                                mdllink.ModifiedOn = System.DateTime.Now;
                                mdllink.ModifiedTerminal = ser_br.TerminalID;
                            }
                            
                            await db.SaveChangesAsync();
                        }
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, StatusCode = "S0002", Message = string.Format(_localizer[name: "S0002"]) };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonRepository.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
        #endregion Drug Manufacturer Link

        #region Drug Vendor Link
        public async Task<List<DO_DrugVendorLink>> GetDrugVendorLink(int BusinessKey, int VendorID)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = await db.GtEphmdbs.Where(x => x.ActiveStatus)
                        .Select(r => new DO_DrugVendorLink
                        {
                            BusinessKey = BusinessKey,
                            VendorID = VendorID,
                            TradeID = r.TradeId,
                            TradeName = r.TradeName,
                            MinimumSupplyQty = 0,
                            BusinessSharePerc = 0,
                            PartNumber = null,
                            PartDesc = null,
                            ActiveStatus = true,
                        }).ToListAsync();

                    foreach (var obj in ds)
                    {
                        GtEphdvl pf = db.GtEphdvls.Where(x => x.BusinessKey == obj.BusinessKey && x.VendorId == obj.VendorID).FirstOrDefault();
                        if (pf != null)
                        {
                            obj.MinimumSupplyQty = pf.MinimumSupplyQty;
                            obj.BusinessSharePerc = pf.BusinessSharePerc;
                            obj.PartNumber = pf.PartNumber;
                            obj.PartDesc = pf.PartDesc;
                            obj.ActiveStatus = pf.ActiveStatus;
                        }
                        else
                        {
                            obj.ActiveStatus = true;

                        }
                    }

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_ReturnParameter> AddOrUpdateDrugVendorLink(List<DO_DrugVendorLink> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var ser_br in obj)
                        {
                            GtEphdvl dvllink = db.GtEphdvls.Where(x => x.BusinessKey == ser_br.BusinessKey && x.TradeId == ser_br.TradeID && x.VendorId == ser_br.VendorID).FirstOrDefault();
                            if (dvllink != null)
                            {
                                dvllink.MinimumSupplyQty = ser_br.MinimumSupplyQty;
                                dvllink.BusinessSharePerc = ser_br.BusinessSharePerc;
                                dvllink.PartNumber = ser_br.PartNumber;
                                dvllink.PartDesc = ser_br.PartDesc;
                                dvllink.ActiveStatus = ser_br.ActiveStatus;
                                dvllink.ModifiedBy = ser_br.UserID;
                                dvllink.ModifiedOn = System.DateTime.Now;
                                dvllink.ModifiedTerminal = ser_br.TerminalID;
                            }
                            else
                            {
                                var vdl = new GtEphdvl
                                {
                                    BusinessKey = ser_br.BusinessKey,
                                    TradeId = ser_br.TradeID,
                                    VendorId = ser_br.VendorID,
                                    MinimumSupplyQty = ser_br.MinimumSupplyQty,
                                    BusinessSharePerc = ser_br.BusinessSharePerc,
                                    PartNumber = ser_br.PartNumber,
                                    PartDesc = ser_br.PartDesc,
                                    LastPurchaseRate = 0,
                                    ActiveStatus = ser_br.ActiveStatus,
                                    FormId = ser_br.FormID,
                                    CreatedBy = ser_br.UserID,
                                    CreatedOn = System.DateTime.Now,
                                    CreatedTerminal = ser_br.TerminalID
                                };
                                db.GtEphdvls.Add(vdl); 
                            }
                            await db.SaveChangesAsync();
                        }
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, StatusCode = "S0002", Message = string.Format(_localizer[name: "S0002"]) };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonRepository.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
        #endregion Drug Vendor Link
    }
}
