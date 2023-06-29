using ICAI_ISA.Model;
using ICAI_ISA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ICAI_ISA.Controllers
{
    public class InfoController : Controller
    {
        private readonly ILogger<InfoController> _logger;

        private readonly IInfoService _infoService;

        public InfoController(ILogger<InfoController> logger, IInfoService infoService)
        {
            _logger = logger;
            _infoService = infoService;
        }

        public IActionResult Welcome()
        {
            ViewBag.Session = "July 2023";
            ViewData["Title"] = "Welcome";
            return View();
        }

        public IActionResult Instruction()
        {
            ViewBag.Session = "July 2023";
            return View();
        }

        public async Task<IActionResult>  ExamCenter()
        {
            ViewBag.Session = "July 2023";
            var result = await _infoService.GetExamCenterList();
            return View(result.ToList());
        }

        public async Task<IActionResult> ImportantDates()
        {
            ViewBag.Session = "July 2023";
            var result = await _infoService.GetCurrentExamSessionDetails();
            return View(result);
        }

        public async Task<IActionResult> ContactUs()
        {
            return View();
        }
    }
}
