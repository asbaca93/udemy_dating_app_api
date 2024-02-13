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

        #region API_CALLS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _service.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _service.GetUser(id);
        }
        #endregion
    }
}

