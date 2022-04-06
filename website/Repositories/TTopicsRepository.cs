using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using website.Entities;

namespace website.Repositories
{
    public interface TTopicsRepository
    {
        List<Topic> Topics { get; }

        Task<Topic> GetTopicAsync(string idTopic);
        Task<IEnumerable<Topic>> GetTopicsAsync();
        Task CreateTopicAsync(Topic topic);
        Task UpdateTopicAsync(Topic topic);
        Task DeleteTopicAsync(string idTopic);

    }
}