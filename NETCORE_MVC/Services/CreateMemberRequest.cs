using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NETCORE_MVC.Services
{
    public class CreateMemberRequest
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(10)]
        public string? FirtName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        public int Gender { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }
        [DisplayName("Birth Place")]
        public string? BirthPlace { get; set; }
    }
}
