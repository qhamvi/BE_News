using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using website.Entities;

namespace website.Repositories
{
    public interface NNewsRepository
    {
        List<New> News { get; }

        Task<New> GetNewAsync(Guid idNeww);
        Task<New> GetNewTrueAsync(Guid idNeww); // Tim tin tuc true theo idNeww
        Task<New> GetNewFalseAsync(Guid idNeww); //Tin tuc false cua Author
        Task<IEnumerable<New>> GetNewsAsync();
        Task<IEnumerable<New>> GetNewsTrueAsync();//1. lien ket voi InMemNewRepository
        Task CreateNewAsync(New new2);
        Task UpdateNewAsync(New new2); //Author + Admin
        Task OkeyUpdateNewAsync(New new2);
        Task DeleteNewAsync(Guid idNeww);
        Task DeleteNewFalseAsync(Guid idNeww);
        

    }
}