using ICAI_ISA.Model;
using ICAI_ISA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ICAI_ISA.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(MemberDetail model)
        {
            if (HttpContext.Session.GetString("MembershipNo") == null)
            {
                if (ModelState.IsValid)
                {
                    FormStatus formStatus  = await _accountService.GetLoggedInUserDetails(model).ConfigureAwait(false);

                    if (formStatus == FormStatus.FormSubmitted)
                    {                        
                        HttpContext.Session.SetString("MembershipNo", model.MembershipNo);
                        HttpContext.Session.SetString("RegistrationNo", model.RegistrationNo);
                        return RedirectToAction("PreviewForm", "Member");
                    }
                    else if(formStatus == FormStatus.Provisional)
                    {
                        return RedirectToAction("Provisional", "Member");
                    }
                    else if (formStatus == FormStatus.FormToBeSubmitted)
                    {
                        return RedirectToAction("MemberApplicationForm", "Member");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Membership No or ISA Registration No.";
                        return View();
                    }
                }
            }
            else
            {
                return RedirectToAction("UserLogin", "Account");
            }
            return View();
        }
    }
}
