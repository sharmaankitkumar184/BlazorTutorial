using EmployeeManagement.Models.CustomValidators;
using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailDomainValidator(AllowedDomain = "pragimtech.com")]
        public string Email { get; set; }

        [CompareProperty("Email",
         ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public int? DepartmentId { get; set; }
        [ValidateComplexType]
        public Department Department { get; set; } = new Department();
        public string PhotoPath { get; set; }
    }
}
