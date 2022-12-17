using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Zip.Installments.DAL.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IList<T>> FindAll();
        Task<IList<T>> FindConditoin(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        Task<T> Update(T entity);
        Task<int> Delete(T entity);
    }
}
