using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations
{
    public class FinancialInstrumentEntityConfiguration : IEntityTypeConfiguration<FinancialInstrument>
    {
        public void Configure(EntityTypeBuilder<FinancialInstrument> builder)
        {
            builder.HasData(GenerateFinancialInstruments());
        }

        private FinancialInstrument[] GenerateFinancialInstruments()
        {
            ICollection<FinancialInstrument> financialInstruments = new HashSet<FinancialInstrument>();

            FinancialInstrument financialInstrument;

            financialInstrument = new FinancialInstrument()
            {
                Id = 1,
                Name = "BULGARIAN STOCK EXCHANGE",
                Description = "Financial and insurance activities",
                ISIN = "BG1100016978",
            };
            financialInstruments.Add(financialInstrument);

            financialInstrument = new FinancialInstrument()
            {
                Id = 2,
                Name = "SOPHARMA",
                Description = "Manufacturing",
                ISIN = "BG11SOSOBT18",
            };
            financialInstruments.Add(financialInstrument);

            financialInstrument = new FinancialInstrument()
            {
                Id = 3,
                Name = "INDUSTRIAL HOLDING BULGARIA",
                Description = "Financial and insurance activities",
                ISIN = "BG1100019980",
            };
            financialInstruments.Add(financialInstrument);

            financialInstrument = new FinancialInstrument()
            {
                Id = 4,
                Name = "SHELLY GROUP",
                Description = "Financial and insurance activities",
                ISIN = "BG1100003166",
            };
            financialInstruments.Add(financialInstrument);

            return financialInstruments.ToArray();            
        }
    }
}
