using API.Entities;

namespace API.Services
{
    public interface IUsersService
    {
        List<AppUser> GetUsers();
    }
}