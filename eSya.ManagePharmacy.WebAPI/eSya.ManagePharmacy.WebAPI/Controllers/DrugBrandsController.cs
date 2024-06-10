using Microsoft.AspNetCore.Mvc;
using eSya.ManagePharmacy.DO;
using eSya.ManagePharmacy.IF;
using eSya.ManagePharmacy.DL.Repository;

namespace eSya.ManagePharmacy.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrugBrandsController : Controller
    {
        private readonly IDrugBrandsRepository _drugBrandRepository;
        public DrugBrandsController(IDrugBrandsRepository drugBrandRepository)
        {
            _drugBrandRepository = drugBrandRepository;
        }

        #region Drug Brands

        /// <summary>
        /// Getting  Drug Brand LIst.
        /// UI Reffered - Drug Brands.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugBrandList()
        {
            var i_Codes = await _drugBrandRepository.GetDrugBrandList();
            return Ok(i_Codes);
        }

        /// <summary>
        /// Getting  Full Drug Brand LIst.
        /// UI Reffered - Drug Brands.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetFullDrugBrandList()
        {
            var i_Codes = await _drugBrandRepository.GetFullDrugBrandList();
            return Ok(i_Codes);
        }

        /// <summary>
        /// Getting  Selected Drug Brand LIst.
        /// UI Reffered - Drug Brands
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugBrandListByTradeID(int TradeID)
        {
            var i_Codes = await _drugBrandRepository.GetDrugBrandListByTradeID(TradeID);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Getting  Selected Drug Brand LIst.
        /// UI Reffered - Drug Brands
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugBrandListByGroup(int CompositionID, int FormulationID, int ManufacturerID)
        {
            var i_Codes = await _drugBrandRepository.GetDrugBrandListByGroup(CompositionID, FormulationID, ManufacturerID);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Getting  Drug Brands Parameter List.
        /// UI Reffered - Drug Brands
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugBrandParameterList(int TradeID)
        {
            var i_Codes = await _drugBrandRepository.GetDrugBrandParameterList(TradeID);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Insert Drug Brands
        /// UI Reffered - Drug Brands
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertDrugBrands(DO_DrugBrands obj)
        {
            var msg = await _drugBrandRepository.InsertDrugBrands(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update Drug Brands
        /// UI Reffered - Drug Brands
        /// </summary>
        [HttpPost]     
        public async Task<IActionResult> UpdateDrugBrands(DO_DrugBrands obj)
        {
            var msg = await _drugBrandRepository.UpdateDrugBrands(obj);
            return Ok(msg);

        }

        #endregion Drug Brand
    }
}
