using FinancialManager.Business.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManager.Business.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(Guid id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
