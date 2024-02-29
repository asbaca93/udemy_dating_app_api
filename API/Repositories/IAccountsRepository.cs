using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories
{
    public interface IAccountsRepository
    {
        Task<ActionResult<AppUser>> Register(string username, string password);
    }
}