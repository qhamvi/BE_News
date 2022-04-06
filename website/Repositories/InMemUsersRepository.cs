using System;//Guid
using System.Collections.Generic;//List
using System.Linq;//Where
using System.Threading.Tasks;
using website.Entities;//User

namespace website.Repositories
{


    public class InMemUsersRepository : UUsersRepository
    {
        private readonly List<User> users = new()
        {
            new User { _id = Guid.NewGuid(), name = "tuongvi", email = "tv@gmail.com", sdt = "0857537537", idAc = "1" },
            new User { _id = Guid.NewGuid(), name = "phamvi", email = "pv@gmail.com", sdt = "0857537538", idAc = "2" },
            new User { _id = Guid.NewGuid(), name = "phamnguyen", email = "pnv@gmail.com", sdt = "0857537539", idAc = "3" },

        };
        public List<User> Users => users;

        public  async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await Task.FromResult(users);
        }

        public  async Task<User> GetUserAsync(Guid idUser)
        {
            var user = users.Where(user => user._id == idUser).SingleOrDefault();
            return await Task.FromResult(user);
        }

        public async Task CreateUserAsync(User user)
        {
            users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateUserAsync(User user)
        {
            var index = users.FindIndex(existingUser => existingUser._id == user._id);
            users[index] = user;
            await Task.CompletedTask;

        }

        public async Task DeleteUserAsync(Guid idUser)
        {
            var index = users.FindIndex(existingUser => existingUser._id == idUser);
            users.RemoveAt(index);
            await Task.CompletedTask;
        }
    }

}