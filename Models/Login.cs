using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zencareservice.Models
{
    public class Login
    {

        public int LoginId { get; set; }

        [Required]
        public string ?Username { get; set; }

        [Required]
        public string? Password { get; set; }


        public string ?Email { get; set; }
        public string? CRPassword { get; set; }
    }
}
