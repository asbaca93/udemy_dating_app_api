using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories
{
    public interface IUsersRepository
    {
        Task<ActionResult<IEnumerable<AppUser>>> GetUsers();
        Task<ActionResult<AppUser>> GetUser(int id);
    }
}