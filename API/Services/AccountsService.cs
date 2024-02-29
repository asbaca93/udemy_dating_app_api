using API.Entities;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class AccountsService: IAccountsService
    {
        #region DECLARATIONS
        private readonly IAccountsRepository _repository;
        #endregion
    
        #region CONSTRUCTOR
        public AccountsService(IAccountsRepository repository)
        {
            _repository = repository;
        }
        #endregion
        
        #region FUNCTIONS

        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            try
            {
                return await _repository.Register(username, password);
            }
            catch (Exception ex)
            {
                return new AppUser();
                //  figure out how to I am going to handle errors, remove above line
            }
        }
        
        #endregion
    }
}

