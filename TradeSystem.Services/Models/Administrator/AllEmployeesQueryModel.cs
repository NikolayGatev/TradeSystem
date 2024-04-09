using TradeSystem.Core.Models.Employees;

namespace TradeSystem.Core.Models.Administrator
{
    public class AllEmployeesQueryModel
    {
        public AllEmployeesQueryModel()
        {
            this.TypeApproved = new string[] { "Approved", "NotApproved" };
            Employees = new HashSet<EmployeeDetailsServiceModel>();
        }

        public int EmployeesPerPage { get; } = 3;

        public bool? IsApproved { get; set; } = null;

        public string? EmployeeId { get; set; }

        public int CurrentPage { get; init; } = 1;

        public int TotalEmployeesCount { get; set; }

        public IEnumerable<string> TypeApproved { get; set; }

        public IEnumerable<EmployeeDetailsServiceModel> Employees { get; set; }
    }
}
