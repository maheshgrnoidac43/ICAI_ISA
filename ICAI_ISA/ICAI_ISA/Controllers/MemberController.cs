using Microsoft.AspNetCore.Mvc;

namespace ICAI_ISA.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public MemberController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SearchIsaNo()
        {            
            return View();
        }
    }
}
