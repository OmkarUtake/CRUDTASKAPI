using Crud.Model.Account;
using Crud.Model.Category;
using Microsoft.EntityFrameworkCore;

namespace Crud.Database.DbContext
{
    public class CategoryDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public CategoryDBContext(DbContextOptions<CategoryDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
