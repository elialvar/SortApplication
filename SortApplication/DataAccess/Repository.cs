using System;
using System.Collections.Generic;
using System.Linq;
using SortApplication.DataAccess.Interfaces;

namespace SortApplication.DataAccess
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private IList<TEntity> _context;

        public Repository(IList<TEntity> context)
        {
            _context = context;
        }

        public TEntity Get(Guid id)
        {
            return _context.SingleOrDefault(x => x.Id == id);
        }

        public IList<TEntity> GetAll()
        {
            return _context;
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void RemoveAll()
        {
            _context.Clear();
        }
    }
}