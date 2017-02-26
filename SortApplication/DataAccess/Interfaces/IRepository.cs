using System;
using System.Collections.Generic;

namespace SortApplication.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where  TEntity : EntityBase
    {
        TEntity Get(Guid id);

        IList<TEntity> GetAll();
        
        void Add(TEntity entity);

        void Remove(TEntity entity);

        void RemoveAll();
    }
}