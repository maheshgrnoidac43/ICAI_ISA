using ICAI_ISA.Model;
using ICAI_ISA.Services.Interfaces;
using ICAI_ISA.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ICAI_ISA.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMemberService _memberService;

        public MemberController(ILogger<HomeController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchIsaNo()
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetIsaNoDetails([FromBody] SearchIsaNo searchisanumber)
        {            
            if (!ModelState.IsValid) return BadRequest("Enter required fields");

            var result = await _memberService.GetIsaNoDetails(searchisanumber);
            return Json(result);
        }

        [HttpGet]
        public IActionResult CheckStatus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckPaymentStatus([FromBody] MemberDetail memberDetail)
        {
            if (!ModelState.IsValid) return BadRequest("Enter required fields");

            var result = await _memberService.CheckPaymentStatus(memberDetail);
            return Json(result);
        }

        public IActionResult Provisional()
        {
            return View();
        }

        public IActionResult MemberApplicationForm()
        {
            return View();
        }

        [Authentication]
        public IActionResult PreviewForm()
        {
            return View();
        }
    }
}
