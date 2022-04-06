using System;//Guid
using System.Collections.Generic;//IEnumerable
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;//ApiController
using website.Dtos;
using website.Entities;//Account
using website.Repositories;//InMemAccountRepository

namespace website.Controllers
{
    //GET/accounts
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly AAccountsRepository repositoryAc;
        public AccountsController(AAccountsRepository repositoryAc2)
        {
            this.repositoryAc = repositoryAc2;
        }
        //GET/accounts
        [HttpGet]
        public async Task<IEnumerable<AccountDto>> GetAccountsAsync()
        {
            var accounts = (await repositoryAc.GetAccountsAsync())
                            .Select(account => account.AsDtoAccount());
            return accounts;
        }

        //GET/accounts/{idAccount}
        [HttpGet("{idAccount}")]
        public async Task<ActionResult<AccountDto>> GetAccountAsync(Guid idAccount)
        {
            var account = await repositoryAc.GetAccountAsync(idAccount);
            if (account is null)
            {
                return NotFound();
            }
            return account.AsDtoAccount();
        }
        //POST/accounts
        [HttpPost]
        public async Task<ActionResult<AccountDto>> CreateAccountAsync(CreateAccountDto accountDto)
        {
            Account account = new()
            {
                _id = Guid.NewGuid(),
                uname = accountDto.uname,
                pass = accountDto.pass,
                idPo = accountDto.idPo
            };
            await repositoryAc.CreateAccountAsync(account);
            return CreatedAtAction(nameof(GetAccountAsync), new { idAccount = account._id }, account.AsDtoAccount());

        }
        //PUT/accounts
        [HttpPut("{idAccount}")]
        public async Task<ActionResult> UpdateAccountAsync(Guid idAccount, UpdateAccountDto accountDto)
        {
            var existingAccount = await repositoryAc.GetAccountAsync(idAccount);
            if (existingAccount is null)
            {
                return NotFound();
            }
            Account updateAccount = existingAccount with
            {
                uname = accountDto.uname,
                pass = accountDto.pass,
                idPo = accountDto.idPo
            };
            await repositoryAc.UpdateAccountAsync(updateAccount);
            return NoContent();

        }
        //DELETE/accounts/{idAccount}
        [HttpDelete("{idAccount}")]
        public async Task<ActionResult> DeleteAccountAsync(Guid idAccount)
        {
            var existingAccount = await repositoryAc.GetAccountAsync(idAccount);
            if (existingAccount is null)
            {
                return NotFound();
            }
            
            await repositoryAc.DeleteAccountAsync(idAccount);
            return NoContent();
        }
        
    }

}