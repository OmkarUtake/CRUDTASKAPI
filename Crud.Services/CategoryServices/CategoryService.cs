using Crud.Database.Repository.UserRepository;
using Crud.Model.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task Add(Category category);
        Task<Category> Get(int id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task Delete(Category category);
        Task Update(int id, Category category);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Add(Category category)
        {
            _categoryRepository.Add(category);
        }
        public async Task<Category> Get(int id)
        {
            var category = await _categoryRepository.GetById(id);
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return categories;
        }

        public async Task Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public async Task Update(int id, Category category)
        {
            await _categoryRepository.Update(id, category);
        }
    }
}
