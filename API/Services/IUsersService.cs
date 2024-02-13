using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public interface IUsersService
    {
        Task<ActionResult<IEnumerable<AppUser>>> GetUsers();
        Task<ActionResult<AppUser>> GetUser(int id);
    }
}