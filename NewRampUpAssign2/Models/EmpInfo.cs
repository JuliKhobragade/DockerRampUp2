using System.ComponentModel.DataAnnotations;

namespace NewRampUpAssign2.Models
{
    public class EmpInfo
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
