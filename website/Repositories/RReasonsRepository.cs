using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using website.Entities;

namespace website.Repositories
{
    public interface RReasonsRepository
    {
        List<Reason> Reasons { get; }

        Task<Reason> GetReasonAsync(Guid idReason);
        Task<IEnumerable<Reason>> GetReasonsAsync();

        Task CreateReasonAsync(Reason reason);

        Task UpdateReasonAsync(Reason reason);
        Task DeleteReasonAsync(Guid idReason);

        
    }
}