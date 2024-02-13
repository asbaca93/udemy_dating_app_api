using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        #region DECLARATION
        private readonly DataContext _dataContext;
        #endregion
        
        #region CONSTRUCTOR
        public UsersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        #endregion
        
        #region FUNCTIONS
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _dataContext.Users.FindAsync(id);
        }
        #endregion
    }
}