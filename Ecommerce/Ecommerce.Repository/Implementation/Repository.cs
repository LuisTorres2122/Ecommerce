
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Repository.DBConext;
using System.Linq.Expressions;

namespace Ecommerce.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EcommerceContext _context;
        public Repository(EcommerceContext context)
        {
            _context = context;
        }

        public IQueryable<T> get(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = (filter == null) ? _context.Set<T>() : _context.Set<T>().Where(filter);
            return query;
        }

        public async Task<T> Create(T data)
        {
            try
            {
                _context.Set<T>().Add(data);
                await _context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(T data)
        {
            try
            {
                _context.Set<T>().Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(T data)
        {
            try
            {
                _context.Set<T>().Update(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
