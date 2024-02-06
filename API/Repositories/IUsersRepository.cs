using API.Entities;

namespace API.Repositories
{
    public interface IUsersRepository
    {
        List<AppUser> GetUsers();
    }
}