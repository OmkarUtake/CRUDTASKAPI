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
        void Add(T model);
        void Delete(T model);
        Task Update(int id, T model);
        Task<IEnumerable<T>> GetAll();

    }
}
