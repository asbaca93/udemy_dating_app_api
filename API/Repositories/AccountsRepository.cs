using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class AccountsRepository: IAccountsRepository
    {
        #region DECLARATION
        private readonly DataContext _dataContext;
        #endregion
        
        #region CONSTRUCTOR
        public AccountsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        #endregion
        
        #region FUNCTIONS

        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                Username = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }
        #endregion
    }
}