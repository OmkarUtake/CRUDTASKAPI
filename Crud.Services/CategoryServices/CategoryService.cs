using Crud.Database.Repository.UserRepository;
using Crud.Model.Category;
using System.Threading.Tasks;

namespace Crud.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task Add(Category category);
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
            await _categoryRepository.Add(category);
        }
    }
}
