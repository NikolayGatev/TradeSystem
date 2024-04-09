using System.ComponentModel.DataAnnotations;

namespace TradeSystem.Core.Models.Employees
{
    public class EmployeeDetailsServiceModel : EmployeeFormModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string ApplicationName { get; set; } = null!;

        [Required]
        [Display(Name = "Name of Division")]

        public string DivisionName { get; set; } = null!;

        public bool IsApproved { get; set; }
    }
}
