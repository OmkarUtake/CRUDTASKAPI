using Crud.Database.DbContext;
using Crud.Database.Infrastructure;
using Crud.Model.Account;
using Crud.ModelDTO.Account;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Database.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task Login(User user);
        Task Add(User user);
        // Task<User> GetUser(LoginDTO login);
        bool ValidateUser(LoginDTO login);
        User GetUser(LoginDTO login);
        string GenerateToken();
    }

    public class UserRepository : IUserRepository
    {
        private CategoryDBContext _db;
        public UserRepository(CategoryDBContext db)
        {
            _db = db;
        }

        public async Task Login(User user)
        {
            await _db.Users.AnyAsync(x => x.UserEmail == user.UserEmail && x.Password == user.Password);

        }

        public async Task Add(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }


        public bool ValidateUser(LoginDTO login)
        {
            var user =  _db.Users.Any(x => x.UserEmail == login.Email && x.Password == login.Password);
            return user;
        }

        public User GetUser(LoginDTO login)
        {
            var user = _db.Users.Where(x => x.UserEmail == login.Email).FirstOrDefault();
            return user;
        }

        public string GenerateToken()
        {
            throw new System.NotImplementedException();
        }
    }
}
