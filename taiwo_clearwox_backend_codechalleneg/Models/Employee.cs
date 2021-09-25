using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace taiwo_clearwox_backend_codechalleneg.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "You should Provide a Name Value.")]
        [MinLength (2)]
        [MaxLength(10, ErrorMessage = "Lenght of name should no be more than 10 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You should Provide a Name Value.")]
        [MaxLength(10, ErrorMessage = "Lenght of name should no be more than 10 characters.")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "You should Provide  a Job Title ")]
        [MaxLength(30, ErrorMessage = "Lenght of Job Title should not be more than 20 characters.")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "You should Provide  an email address ")]
        [MaxLength(30, ErrorMessage = "Lenght of email should not be more than 20 characters.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You should Provide the date of birth.")]
        public DateTime DateofBirth { get; set; }
        [Required(ErrorMessage = "You should Provide the date of birth.")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "You should Provide gender")]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string PhotoPath { get; set; }
        public string Address { get; set; }
        //public Department Department { get; set; }

    }
}
