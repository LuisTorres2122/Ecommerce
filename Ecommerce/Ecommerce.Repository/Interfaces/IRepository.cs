using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> get(Expression<Func<T, bool>>? filter = null);
        Task<T> Create(T data);
        Task<bool> Update(T data);
        Task<bool> Delete(T data);

    }
}
