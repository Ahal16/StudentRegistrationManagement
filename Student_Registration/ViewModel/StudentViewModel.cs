using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(10, MinimumLength = 10)]
        public string PhoneNumber { get; set; }
        public int QualificationId { get; set; }

        public string CourseName { get; set; }

        public string University { get; set; }

        public int YearOfPassing { get; set; }

        public decimal Percentage { get; set; }

    }
}
