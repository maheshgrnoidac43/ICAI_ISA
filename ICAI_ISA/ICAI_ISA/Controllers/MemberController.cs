using ICAI_ISA.Model;
using ICAI_ISA.Services.Interfaces;
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
        public async Task<IActionResult> SearchIsaNo()
        {            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CheckStatus()
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
    }
}
