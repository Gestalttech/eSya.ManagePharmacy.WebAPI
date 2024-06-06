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
        /// Getting  Selected Drug Brand LIst.
        /// UI Reffered - Drug Brands
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugBrandList(int TradeID)
        {
            var i_Codes = await _drugBrandRepository.GetDrugBrandList(TradeID);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Getting  Selected Drug Brand LIst.
        /// UI Reffered - Drug Brands
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugBrandList(int CompositionID, int FormulationID, int ManufacturerID)
        {
            var i_Codes = await _drugBrandRepository.GetDrugBrandList(CompositionID, FormulationID, ManufacturerID);
            return Ok(i_Codes);
        }

        /// <summary>
        /// Insert Item Codes.
        /// UI Reffered - Item Codes
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertDrugBrands(DO_DrugBrands drugBrands)
        {
            var msg = await _drugBrandRepository.InsertDrugBrands(drugBrands);
            return Ok(msg);
        }

        /// <summary>
        /// Update Item Codes.
        /// UI Reffered - Item Codes
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateDrugBrands(DO_DrugBrands drugBrands)
        {
            var msg = await _drugBrandRepository.UpdateDrugBrands(drugBrands);
            return Ok(msg);

        }

        #endregion Drug Brand
    }
}
