using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Entities;

namespace website.Repositories
{


    public class InMemTopicsRepository : TTopicsRepository
    {
        private readonly List<Topic> topics = new()
        {
            new Topic { _id = "thoisu", nameTop = "Thời sự" },
            new Topic { _id = "giaitri", nameTop = "Giải trí" },
            new Topic { _id = "vanhoa", nameTop = "Văn hóa" },
            new Topic { _id = "giaoduc", nameTop = "Giáo dục" },
        };
        public List<Topic> Topics => topics;

        public async Task<IEnumerable<Topic>> GetTopicsAsync()
        {
            return await Task.FromResult(topics);
        }

        public async Task<Topic> GetTopicAsync(string idTopic)
        {
            var topic = topics.Where(topic => topic._id == idTopic).SingleOrDefault();
            return await Task.FromResult(topic);
        }

        public async Task CreateTopicAsync(Topic topic)
        {
            topics.Add(topic);
            await Task.CompletedTask;
        }

        public async Task UpdateTopicAsync(Topic topic)
        {
            var index = topics.FindIndex(exsitingTopic => exsitingTopic._id == topic._id);
            topics[index] = topic;
            await Task.CompletedTask;

        }

        public async Task DeleteTopicAsync(string idTopic)
        {
            var index = topics.FindIndex(existingTopic => existingTopic._id == idTopic);
            topics.RemoveAt(index);
            await Task.CompletedTask;

        }
    }
}