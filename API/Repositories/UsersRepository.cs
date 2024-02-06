using API.Data;
using API.Entities;

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
        public List<AppUser> GetUsers()
        {
            List<AppUser> users = _dataContext.Users.ToList();
            return users;
        }
    }
}