using System.ComponentModel.DataAnnotations;

namespace ICAI_ISA.Model
{
    public class MemberDetail
    {
        [Required(ErrorMessage ="Please enter Membership No!", AllowEmptyStrings = false)]
        public string MembershipNo { get; set; }

        [Required(ErrorMessage = "Please enter ISA Registration No!", AllowEmptyStrings = false)]
        public string RegistrationNo { get; set; }
    }
}
