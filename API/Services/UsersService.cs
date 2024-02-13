using API.Entities;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

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
    
    #region FUNCTIONS
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        try
        {
            return await _repository.GetUsers();
        }
        catch (Exception ex)
        {
            return new List<AppUser>();
            // TODO - figure out how to I am going to handle errors, remove above line
        }
    }

    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        try
        {
            return await _repository.GetUser(id);
        }
        catch (Exception ex)
        {
            return new AppUser();
        }
    }
    #endregion
}