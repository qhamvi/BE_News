using System;//Guid
using System.Collections.Generic;//List
using System.Threading.Tasks;
using website.Entities;//Account

namespace website.Repositories
{
    public interface AAccountsRepository
    {
        // List<Account> Accounts { get; }

        Task<Account> GetAccountAsync(Guid idAccount); //Xem 1 tai khoan
        Task<IEnumerable<Account>> GetAccountsAsync(); //Xem nhieu tai khoan
        Task CreateAccountAsync(Account account); //Tao tai khoan
        Task UpdateAccountAsync(Account account); //Cap nhat / chinh sua tai khoan
        Task DeleteAccountAsync(Guid idAccount); // Xoa tai khoan
        
    }
}