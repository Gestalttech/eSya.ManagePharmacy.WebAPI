using Microsoft.AspNetCore.Mvc;
using eSya.ManagePharmacy.IF;

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
    }
}
