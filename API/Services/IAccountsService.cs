using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public interface IAccountsService
    {
        Task<ActionResult<AppUser>> Register(string username, string password);
    }
}