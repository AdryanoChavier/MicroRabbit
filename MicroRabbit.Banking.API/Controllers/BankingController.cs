using MicroRabbit.Banking.API.ViewModel;
using MicroRabbit.Banking.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.API.Controllers
{
    [Route("api/banking")]
    [ApiController]
    public class BankingController(IAccountService accountService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<AccountViewModel>> Get()
        {
            var accounts = accountService.GetAccounts();
            return Ok(accounts);
        }
    }
}
