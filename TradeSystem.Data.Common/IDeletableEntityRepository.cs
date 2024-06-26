﻿using TradeSystem.Data.Common.Base;

namespace TradeSystem.Data.Common
{
    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        Task<TEntity> GetByIdWithDeletedAsync(params object[] id);

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
