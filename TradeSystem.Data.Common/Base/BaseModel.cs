namespace TradeSystem.Data.Common.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseModel : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
