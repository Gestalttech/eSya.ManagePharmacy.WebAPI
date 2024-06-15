using Microsoft.AspNetCore.Mvc;
using eSya.ManagePharmacy.IF;
using eSya.ManagePharmacy.DL.Entities;

namespace eSya.ManagePharmacy.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : Controller
    {
        private readonly ICommonRepository _commonRepository;
        public CommonController(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        /// <summary>
        /// Getting  Application Codes.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetApplicationCodesByCodeType(int codeType)
        {
            var ds = await _commonRepository.GetApplicationCodesByCodeType(codeType);
            return Ok(ds);
        }

        /// <summary>
        /// Getting  Composition
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetComposition()
        {
            var ds = await _commonRepository.GetComposition();
            return Ok(ds);
        }

        /// <summary>
        /// Getting  Composition
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDrugFormulation(int CompositionId)
        {
            var ds = await _commonRepository.GetDrugFormulation(CompositionId);
            return Ok(ds);
        }

        /// <summary>
        /// Getting  Manufacturers
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetManufacturers(int CompositionId, int FormulationID)
        {
            var ds = await _commonRepository.GetManufacturers(CompositionId, FormulationID);
            return Ok(ds);
        }

        /// <summary>
        /// Get ISDCodes.
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetISDCodes()
        {
            var ds = await _commonRepository.GetISDCodes();
            return Ok(ds);
        }

        /// <summary>
        /// Get Business Location.
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBusinessKey()
        {
            var ds = await _commonRepository.GetBusinessKey();
            return Ok(ds);
        }

        /// <summary>
        /// Get Business Location.
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetManufacturersList()
        {
            var ds = await _commonRepository.GetManufacturersList();
            return Ok(ds);
        }

        /// <summary>
        /// Get Vendor List
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetVendorList(int BusinessKey)
        {
            var ds = await _commonRepository.GetVendorList(BusinessKey);
            return Ok(ds);
        }
    }
}
