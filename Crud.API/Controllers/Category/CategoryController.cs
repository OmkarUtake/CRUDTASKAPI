using Crud.Model.Category;
using Crud.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.API.Controllers.CategoryController
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Category")]
        public async Task Add(Category category)
        {
            await _categoryService.Add(category);
        }

        [HttpGet("Category/{id}")]
        public async Task<Category> Category(int id)
        {
            var category = await _categoryService.Get(id);
            return category;
        }

        [HttpGet("Categories")]
        public async Task<IEnumerable<Category>> Category()
        {
            var category = await _categoryService.GetAllCategories();
            return category;
        }

        [HttpDelete("Delete/{id}")]
        public async Task Delete(int id)
        {
            var category = await _categoryService.Get(id);
            await _categoryService.Delete(category);
        }

        [HttpPut("Update/{id}")]
        public async Task Update(int id, Category category)
        {
            await _categoryService.Update(id, category);
        }

    }
}
