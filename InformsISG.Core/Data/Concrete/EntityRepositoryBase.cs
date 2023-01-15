using InformsISG.Core.Data.Abstract;
using InformsISG.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Core.Data.Concrete
{
    public class EntityRepositoryBase<T> : IEntityRepositoryBase<T> where T : class, IEntity, new()
    {
        protected readonly DbContext _context;
        public EntityRepositoryBase(DbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().CountAsync(predicate);
        }
      
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate!=null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(T entity)//TASKLAR asyncdir
        {
            await Task.Run(()=>_context.Remove(entity));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => _context.Entry<T>(entity).State = EntityState.Detached);


                await Task.Run(() => _context.Update(entity));
            
            //await Task.Run(() => _context.Update(entity));
            //await Task.Run(() => _context.Update(entity));
            //await Task.Run(() => { _context.Set<T>().Update(entity); });


            return entity;
        }
    }
}
