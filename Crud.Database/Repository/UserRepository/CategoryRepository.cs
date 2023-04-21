using Crud.Database.DbContext;
using Crud.Database.Infrastructure;
using Crud.Model.Category;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Database.Repository.UserRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {

    }
    public class CategoryRepository : ICategoryRepository
    {
        private CategoryDBContext _db;
        public CategoryRepository(CategoryDBContext db)
        {
            _db = db;
        }
        public async Task Add(Category model)
        {
            _db.Categories.Add(model);
            await _db.SaveChangesAsync();

        }

        public async Task Delete(Category model)
        {
            _db.Categories.Remove(model);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> Get(Expression<Func<Category, bool>> expression)
        {
            var categories = _db.Categories;
            return categories;
        }

        public async Task<Category> GetById(int id)
        {
            var data =await _db.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public Task<IEnumerable<Category>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task Update(Category model)
        {
            throw new NotImplementedException();
        }
    }
}
