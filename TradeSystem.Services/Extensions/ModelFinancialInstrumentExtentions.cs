using System.Text.RegularExpressions;
using TradeSystem.Core.Contracts.ModelExtention;

namespace TradeSystem.Core.Extensions
{
    public static class ModelFinancialInstrumentExtentions
    {
        public static string GetNameAndIsin(this IFinancialInstrumentModel financialInstrument)
        {
            string info = financialInstrument.Name.Replace(" ", "-") + financialInstrument.ISIN;

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }
    }
}
