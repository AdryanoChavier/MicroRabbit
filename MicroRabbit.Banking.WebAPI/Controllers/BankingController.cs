using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.API.Controllers
{
    [Route("api/banking")]
    [ApiController]
    public class BankingController(IAccountService accountService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            var accounts = accountService.GetAccounts();
            return Ok(accounts);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer) 
        {
            accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
