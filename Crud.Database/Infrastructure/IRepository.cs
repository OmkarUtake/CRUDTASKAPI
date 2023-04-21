using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Database.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task Add(T model);
        Task Delete(T model);
        Task Update(T model);
        Task<IEnumerable<T>> GetProducts();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression);
    }
}
