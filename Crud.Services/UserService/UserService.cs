using Crud.Database.Infrastructure;
using Crud.Database.Repository.UserRepository;
using Crud.Model.Account;
using Crud.ModelDTO.Account;
using Crud.UtilityHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Services.UserService
{
    public interface IUserService
    {
        Task Add(User user);
        string Authenticate(LoginDTO login);
    }


    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Authenticate(LoginDTO login)
        {
            
            var isAuthenticate = _userRepository.ValidateUser(login);
            if (isAuthenticate)
            {
               var user= _userRepository.GetUser(login);
                JWTHelper obj = new JWTHelper();
                var token = obj.GenerateToken(user.UserName);
                return token;
            }
            return null;
        }

        public async Task Add(User user)
        {
            await _userRepository.Add(user);
        }
    }
}
