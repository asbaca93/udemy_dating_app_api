using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountsController: BaseApiController
    {
        #region DECLARATION
        private readonly IAccountsService _service;
        #endregion
        
        #region CONSTRUCTOR
        public AccountsController(IAccountsService service)
        {
            _service = service;
        }
        #endregion
        
        #region API_CALLS
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            return await _service.Register(username, password);
        }
        #endregion
    }
}

