﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSya.ManagePharmacy.DO;

namespace eSya.ManagePharmacy.IF
{
    public interface IDrugBrandsRepository
    {
        #region Drug Brands
        Task<List<DO_DrugBrands>> GetDrugBrandList();
        Task<List<DO_DrugBrands>> GetFullDrugBrandList();
        Task<List<DO_DrugBrands>> GetDrugBrandListByGroup(int CompositionID, int FormulationID, int ManufacturerID);
        Task<List<DO_DrugBrands>> GetDrugBrandListByTradeID(int TradeID);
        Task<DO_DrugBrands> GetDrugBrandParameterList(int TradeID);
        Task<List<DO_BusinessLocation>> GetBusinessKey(int TradeId);
        Task<DO_ReturnParameter> InsertDrugBrands(DO_DrugBrands obj);
        Task<DO_ReturnParameter> UpdateDrugBrands(DO_DrugBrands obj);
        #endregion Drug Brands

        #region Drug Manufacturer Link
        Task<List<DO_DrugManufacturerLink>> GetDrugManufacturerLink(int BusinessKey, int ManufacturerID);
        Task<DO_ReturnParameter> AddOrUpdateDrugManufacturer(List<DO_DrugManufacturerLink> obj);
        #endregion Drug Manufacturer Link

        #region Drug Vendor Link
        Task<List<DO_DrugVendorLink>> GetDrugVendorLink(int BusinessKey, int VendorID);
        Task<DO_ReturnParameter> AddOrUpdateDrugVendorLink(List<DO_DrugVendorLink> obj);
        #endregion Drug Vendor Link
    }
}
