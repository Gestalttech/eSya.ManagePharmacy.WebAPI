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
        public async Task<List<DO_DrugBrands>> GetDrugBrandList(int CompositionID, int FormulationID, int ManufacturerID)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var result = await db.GtEphmdbs.Where(w => w.CompositionId == CompositionID && w.FormulationId == FormulationID && w.ManufacturerId == ManufacturerID).Join(db.GtEskucds,
                        x => x.TradeId,
                        y => y.Skucode,
                        (x, y) => new { x, y })
                        .Select(r => new DO_DrugBrands
                        {
                            Skuid = r.y.Skuid,
                            CompositionID = r.x.CompositionId,
                            FormulationID = r.x.FormulationId,
                            TradeID = r.x.TradeId,
                            TradeName = r.x.TradeName,
                            PackSize = r.x.PackSize,
                            Packing = r.x.Packing,
                            ManufacturerID = r.x.ManufacturerId,
                            ISDCode = r.x.Isdcode,
                            BarcodeID = r.x.BarcodeId,
                            ActiveStatus = r.x.ActiveStatus,
                            Skutype = r.y.Skutype,
                            Skucode = r.y.Skucode

                        }).ToListAsync();
                    //foreach (var obj in result)
                    //{
                    //    if (obj.InventoryClass == "S")
                    //    {
                    //        obj.InventoryClass = "Stockable";
                    //    }
                    //    else
                    //    {
                    //        obj.InventoryClass = "Non-Stockable";
                    //    }

                    //    if (obj.ItemClass == "B")
                    //    {
                    //        obj.ItemClass = "Bought Out";
                    //    }
                    //    else if (obj.ItemClass == "C")
                    //    {
                    //        obj.ItemClass = "Consignment";
                    //    }
                    //    else if (obj.ItemClass == "I")
                    //    {
                    //        obj.ItemClass = "In-House";
                    //    }
                    //    else
                    //    {
                    //        obj.ItemClass = "Sub Contract";
                    //    }

                    //    if (obj.ItemSource == "L")
                    //    {
                    //        obj.ItemSource = "Local";
                    //    }
                    //    else if (obj.ItemSource == "I")
                    //    {
                    //        obj.ItemSource = "Imported";
                    //    }
                    //    else
                    //    {
                    //        obj.ItemSource = "Out Station";
                    //    }

                    //    if (obj.ItemCriticality == "D")
                    //    {
                    //        obj.ItemCriticality = "Desirable";
                    //    }
                    //    else if (obj.ItemCriticality == "E")
                    //    {
                    //        obj.ItemCriticality = "Essential";
                    //    }
                    //    else
                    //    {
                    //        obj.ItemCriticality = "Vital";
                    //    }
                    //}
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_DrugBrands>> GetDrugBrandList(int TradeID)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {


                    var result = await db.GtEphmdbs.Join(db.GtEskucds,
                         x => x.TradeId,
                         y => y.Skucode,
                         (x, y) => new { x, y })
                         .Select(r => new DO_DrugBrands
                         {
                             Skuid = r.y.Skuid,
                             CompositionID = r.x.CompositionId,
                             FormulationID = r.x.FormulationId,
                             TradeID = r.x.TradeId,
                             TradeName = r.x.TradeName,
                             PackSize = r.x.PackSize,
                             Packing = r.x.Packing,
                             ManufacturerID = r.x.ManufacturerId,
                             ISDCode = r.x.Isdcode,
                             BarcodeID = r.x.BarcodeId,
                             ActiveStatus = r.x.ActiveStatus,
                             Skutype = r.y.Skutype,
                             Skucode = r.y.Skucode

                         }).ToListAsync();
                    //foreach (var obj in result)
                    //{
                    //    if (obj.InventoryClass == "S")
                    //    {
                    //        obj.InventoryClass = "Stockable";
                    //    }
                    //    else
                    //    {
                    //        obj.InventoryClass = "Non-Stockable";
                    //    }

                    //    if (obj.ItemClass == "B")
                    //    {
                    //        obj.ItemClass = "Bought Out";
                    //    }
                    //    else if (obj.ItemClass == "C")
                    //    {
                    //        obj.ItemClass = "Consignment";
                    //    }
                    //    else if (obj.ItemClass == "I")
                    //    {
                    //        obj.ItemClass = "In-House";
                    //    }
                    //    else
                    //    {
                    //        obj.ItemClass = "Sub Contract";
                    //    }

                    //    if (obj.ItemSource == "L")
                    //    {
                    //        obj.ItemSource = "Local";
                    //    }
                    //    else if (obj.ItemSource == "I")
                    //    {
                    //        obj.ItemSource = "Imported";
                    //    }
                    //    else
                    //    {
                    //        obj.ItemSource = "Out Station";
                    //    }

                    //    if (obj.ItemCriticality == "D")
                    //    {
                    //        obj.ItemCriticality = "Desirable";
                    //    }
                    //    else if (obj.ItemCriticality == "E")
                    //    {
                    //        obj.ItemCriticality = "Essential";
                    //    }
                    //    else
                    //    {
                    //        obj.ItemCriticality = "Vital";
                    //    }
                    //}
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DO_ReturnParameter> InsertDrugBrands(DO_DrugBrands drugBrands)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEphmdb is_itemDescExists = db.GtEphmdbs.FirstOrDefault(u => u.TradeName.ToUpper().Replace(" ", "") == drugBrands.TradeName.ToUpper().Replace(" ", ""));
                        if (is_itemDescExists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0127", Message = string.Format(_localizer[name: "W0127"]) };
                        }

                        int _tradeId = db.GtEphmdbs.Select(c => c.TradeId).DefaultIfEmpty().Max();
                        _tradeId = _tradeId + 1;

                        var b_Entity = new GtEphmdb
                        {
                            CompositionId = drugBrands.CompositionID,
                            FormulationId = drugBrands.FormulationID,
                            TradeId = _tradeId,
                            TradeName = drugBrands.TradeName,
                            PackSize = drugBrands.PackSize,
                            Packing = drugBrands.Packing,
                            ManufacturerId = drugBrands.ManufacturerID,
                            Isdcode = drugBrands.ISDCode,
                            BarcodeId = drugBrands.BarcodeID,
                            ActiveStatus = drugBrands.ActiveStatus,
                            FormId = drugBrands.FormID,
                            CreatedBy = drugBrands.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = drugBrands.TerminalID
                        };
                        db.GtEphmdbs.Add(b_Entity);

                        await db.SaveChangesAsync();

                        int _skuid = db.GtEskucds.Select(c => c.Skuid).DefaultIfEmpty().Max();
                        _skuid = _skuid + 1;

                        var sku_Entity = new GtEskucd
                        {
                            Skuid = _skuid,
                            Skutype = drugBrands.Skutype,
                            Skucode = _tradeId,
                            ActiveStatus = drugBrands.ActiveStatus,
                            FormId = drugBrands.FormID,
                            CreatedBy = drugBrands.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = drugBrands.TerminalID
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
        public async Task<DO_ReturnParameter> UpdateDrugBrands(DO_DrugBrands drugBrands)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEphmdb is_tradeExists = db.GtEphmdbs.FirstOrDefault(be => be.TradeName.ToUpper().Replace(" ", "") == drugBrands.TradeName.ToUpper().Replace(" ", "") && be.TradeId != drugBrands.TradeID);
                        if (is_tradeExists != null)
                        {
                            return new DO_ReturnParameter() { Status = false, StatusCode = "W0127", Message = string.Format(_localizer[name: "W0127"]) };

                        }

                        GtEphmdb b_Entity = db.GtEphmdbs.Where(be => be.TradeId == drugBrands.TradeID).FirstOrDefault();

                        if (b_Entity != null)
                        {
                            b_Entity.CompositionId = drugBrands.CompositionID;
                            b_Entity.FormulationId = drugBrands.FormulationID;
                            b_Entity.TradeId = drugBrands.TradeID;
                            b_Entity.TradeName = drugBrands.TradeName;
                            b_Entity.PackSize = drugBrands.PackSize;
                            b_Entity.Packing = drugBrands.Packing;
                            b_Entity.ManufacturerId = drugBrands.ManufacturerID;
                            b_Entity.Isdcode = drugBrands.ISDCode;
                            b_Entity.BarcodeId = drugBrands.BarcodeID;
                            b_Entity.ActiveStatus = drugBrands.ActiveStatus;
                            b_Entity.ModifiedBy = drugBrands.UserID;
                            b_Entity.ModifiedOn = System.DateTime.Now;
                            b_Entity.ModifiedTerminal = drugBrands.TerminalID;

                            await db.SaveChangesAsync();

                            GtEskucd _sku = db.GtEskucds.FirstOrDefault(x => x.Skuid == drugBrands.Skuid && x.Skucode == drugBrands.Skucode);
                            if (_sku != null)
                            {
                                _sku.Skutype = drugBrands.Skutype;
                                _sku.Skucode = drugBrands.Skucode;
                                _sku.ActiveStatus = drugBrands.ActiveStatus;
                                _sku.ModifiedBy = drugBrands.UserID;
                                _sku.ModifiedOn = System.DateTime.Now;
                                _sku.ModifiedTerminal = drugBrands.TerminalID;
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
    }
}
