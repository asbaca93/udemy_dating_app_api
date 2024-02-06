using API.Data;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        #region DECLARATION
        private readonly IUsersService _service;
        #endregion
        
        #region CONSTRUCTOR
        public UsersController(IUsersService service)
        {
            _service = service;
        }
        #endregion

        [HttpGet]
        public List<AppUser> GetUsers()
        {
            List<AppUser> users = _service.GetUsers();
            return users;
        }
    }
}

