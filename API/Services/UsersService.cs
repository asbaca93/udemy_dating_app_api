using API.Entities;
using API.Repositories;

namespace API.Services;

public class UsersService: IUsersService
{
    #region DECLARATIONS
    private readonly IUsersRepository _repository;
    #endregion
    
    #region CONSTRUCTOR

    public UsersService(IUsersRepository repository)
    {
        _repository = repository;
    }
    #endregion
    public List<AppUser> GetUsers()
    {
        try
        {
            List<AppUser> users = _repository.GetUsers();

            return users; 
        }
        catch (Exception ex)
        {
            return new List<AppUser>();
            // TODO - figure out how to I am going to handle errors, remove above line
        }
    }
}