using InformsISG.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Core.Data.Abstract
{
    public interface IEntityRepositoryBase<T> where T : class, IEntity, new()
    {

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task RemoveAsync(T entity);

        Task<IList<T>> GetAllAsync(Expression<Func<T,bool>> predicate=null,params Expression<Func<T,object>>[] includeProperties);//_personelBilgiRepository.GetAll(x=>x.Cinsiyet==0,y=>y.Personel_Ayrinti,z=>z.Dof)

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
