using System.ComponentModel.DataAnnotations;

namespace NewRampUpAssign2.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter Gender")]
        [Display(Name = "Gender(M or F)")]
        [StringLength(1)]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;


    }
}
