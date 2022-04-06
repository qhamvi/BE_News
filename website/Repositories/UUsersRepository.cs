using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using website.Entities;

namespace website.Repositories
{
    public interface UUsersRepository
    {
        Task<User> GetUserAsync(Guid idUser);
        Task<IEnumerable<User>> GetUsersAsync();
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid idUser);
    }
}