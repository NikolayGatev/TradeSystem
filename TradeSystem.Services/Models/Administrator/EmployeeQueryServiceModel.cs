using TradeSystem.Core.Models.Employees;

namespace TradeSystem.Core.Models.Administrator
{
    public class EmployeeQueryServiceModel
    {
        public EmployeeQueryServiceModel()
        {
            Employees = new HashSet<EmployeeDetailsServiceModel>();
        }
        public int TotalEmployeeCount { get; set; }

        public IEnumerable<EmployeeDetailsServiceModel> Employees { get; set; }
    }
}
