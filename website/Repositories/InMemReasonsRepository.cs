using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Entities;

namespace website.Repositories
{


    public class InMemReasonsRepository : RReasonsRepository
    {
        private readonly List<Reason> reasons = new()
        {
            new Reason { _id = Guid.NewGuid(), idNew = "idNew1", contentRea = " Nội dung Lí do 1" },
            new Reason { _id = Guid.NewGuid(), idNew = "idNew1", contentRea = " Nội dung Lí do 1" },
            new Reason { _id = Guid.NewGuid(), idNew = "idNew1", contentRea = " Nội dung Lí do 1" },

        };
        public List<Reason> Reasons => reasons;

        public async Task<IEnumerable<Reason>> GetReasonsAsync()
        {
            return await Task.FromResult(reasons);

        }
        public async Task<Reason> GetReasonAsync(Guid idReason)
        {
            var reason = reasons.Where(idReaa => idReaa._id == idReason).SingleOrDefault();
            return await Task.FromResult(reason);
        }

        public async Task CreateReasonAsync(Reason reason)
        {
            reasons.Add(reason);
            await Task.CompletedTask;
        }

        public async Task UpdateReasonAsync(Reason reason)
        {
            var index = reasons.FindIndex(existingReason => existingReason._id == reason._id);
            reasons[index] = reason;
            await Task.CompletedTask;
        }

        public async Task DeleteReasonAsync(Guid idReason)
        {
            var index = reasons.FindIndex(existingReason => existingReason._id == idReason);
            reasons.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}