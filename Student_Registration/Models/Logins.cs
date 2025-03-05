using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Models
{
    public class Logins
    {
        [Key]
        public int LoginId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string SPassword { get; set; }
    }
}
