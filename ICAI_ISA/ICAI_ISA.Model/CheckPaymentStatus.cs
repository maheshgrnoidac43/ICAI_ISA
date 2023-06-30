using System.ComponentModel.DataAnnotations;

namespace ICAI_ISA.Model
{
    public class MemberDetail
    {
        [Required(ErrorMessage ="Please enter Membership No!")]
        public string MembershipNo { get; set; }

        [Required(ErrorMessage = "Please enter ISA Registration No!")]
        public string RegistrationNo { get; set; }
    }
}
