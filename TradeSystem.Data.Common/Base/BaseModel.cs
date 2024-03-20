namespace TradeSystem.Data.Common.Base
{
    using System;

    public abstract class BaseModel : IAuditInfo
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }
    }
}
