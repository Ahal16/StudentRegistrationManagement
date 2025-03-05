using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        public string StudentId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string University { get; set; }

        [Required]
        public int YearOfPassing { get; set; }

        [Required]
        public decimal Percentage { get; set; }
    }
}
