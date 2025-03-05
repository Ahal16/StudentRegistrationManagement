using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        //public int Age => DateTime.Now.Year - DOB.Year;

        [Required]
        public string Gender { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(10, MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        public List<Qualification> Qualifications { get; set; } = new List<Qualification>();
    }
}
