using System.ComponentModel.DataAnnotations;

namespace ICAI_ISA.Model
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage ="Please enter user name!", AllowEmptyStrings =false)]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password!", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
