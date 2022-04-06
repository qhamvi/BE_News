using System;//Guid
using System.Collections.Generic;//List
using System.Linq;//Where
using System.Threading.Tasks;
using website.Entities; //Account

namespace website.Repositories
{


    public class InMemAccountsRepository : AAccountsRepository
    {
        private readonly List<Account> accounts = new()
        {
            new Account { _id = Guid.NewGuid(), uname = "taikhoan1", pass = "taikhoan1", idPo = "admin" },
            new Account { _id = Guid.NewGuid(), uname = "taikhoan2", pass = "taikhoan2", idPo = "author" },
            new Account { _id = Guid.NewGuid(), uname = "taikhoan1", pass = "taikhoan1", idPo = "editor" },
        };
        public List<Account> Accounts => accounts;

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await Task.FromResult(Accounts);
        }
        public async Task<Account> GetAccountAsync(Guid idAccount)
        {
            var account = accounts.Where(account=> account._id == idAccount).SingleOrDefault();
            return await Task.FromResult(account);
        }
         public Account GetUname(string uName)
        {
            return Accounts.Where(account => account.uname == uName).SingleOrDefault();
        }

        public async Task CreateAccountAsync(Account account)
        {
            accounts.Add(account);
            await Task.CompletedTask;
        }

        public async Task UpdateAccountAsync(Account account)
        {
            var index = accounts.FindIndex(existingAccount => existingAccount._id == account._id);
            accounts[index] = account;
            await Task.CompletedTask;
        }

        public async Task DeleteAccountAsync(Guid idAccount)
        {
            var index = accounts.FindIndex(existingAccount => existingAccount._id == idAccount);
            accounts.RemoveAt(index);
            await Task.CompletedTask;
        }

        // public void CheckAccount(Account account)
        // {
        //     var index = accounts.FindIndex(existingAccount => existingAccount.idAc == account.idAc);
        //     accounts[index] = account;
        // }

        // public Account GetPass(string Pass)
        // {
        //     return Accounts.Where(account => account.pass == Pass).SingleOrDefault();
        // }
    }
}