using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TradeSystem.Core.Models.Clients
{
    public class ClientAcountServiceModel
    {
        public decimal Balance { get; set; }

        [Display(Name = "Blocked sum for open orders")]

        public decimal BlockedSum { get; set; }

        [Display(Name = "All amount deposited")] 

        public decimal AllAmountDeposited { get; set; }
    }
}
