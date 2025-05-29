using FinancialManager.Business.Core.Data;
using FinancialManager.Business.Core.Models;
using FinancialManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManager.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _contextSet;

        protected Repository(AppDbContext context)
        {
            _context = context;
            _contextSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _contextSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _contextSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _contextSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Create(TEntity entity)
        {
            _contextSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            _contextSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(Guid id)
        {
            _context.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
