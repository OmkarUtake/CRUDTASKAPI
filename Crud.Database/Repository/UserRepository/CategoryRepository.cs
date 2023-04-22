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

        public void Add(Category model)
        {
            _db.Categories.Add(model);
            _db.SaveChanges();
        }

        public void Delete(Category model)
        {
            _db.Categories.Remove(model);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var allCategories = _db.Categories.ToList();
            return allCategories;
        }

        public async Task<Category> GetById(int id)
        {
            var category = _db.Categories.Where(x => x.Id == id).FirstOrDefault();
            return category;
        }

        public async Task<IEnumerable<Category>> GetProducts()
        {
            var category = await _db.Categories.ToListAsync();
            return category;
        }

        public async Task Update(int id, Category model)
        {
            var category = await GetById(id);
            category.Name = model.Name;
            category.Description = model.Description;
            _db.Categories.Update(category);
            _db.SaveChanges();
        }
    }
}
