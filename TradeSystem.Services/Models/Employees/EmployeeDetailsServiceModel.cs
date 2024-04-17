using System.ComponentModel.DataAnnotations;

namespace TradeSystem.Core.Models.Employees
{
    public class EmployeeDetailsServiceModel : EmployeeFormModel
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }

        [Display(Name = "Email")]

        public string? ApplicationName { get; set; } = null;
                
        [Display(Name = "Name of Division")]

        public string? DivisionName { get; set; } = null;

        public bool IsApproved { get; set; }
    }
}
