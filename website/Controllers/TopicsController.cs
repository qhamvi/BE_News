using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; //ControllerBase
using website.Dtos;
using website.Entities;//Position
using website.Repositories;//

namespace website.Controllers
{
    
    [ApiController]
    [Route("topics")]
    public class TopicsController : ControllerBase
    {
        private readonly TTopicsRepository repositoryTop;
        public TopicsController(TTopicsRepository repositoryTop2)
        {
            this.repositoryTop = repositoryTop2;
        }
        //GET/ topics 
        [HttpGet]
        public  async Task<IEnumerable<TopicDto>> GetTopicsAsync()
        {
            var topics = ( await repositoryTop.GetTopicsAsync())
            .Select(topic => topic.AsDtoTopic());
            return topics;
        } 
        //GET/topics/{idTopic}
        [HttpGet("{idTopic}")]
        public  async Task<ActionResult<TopicDto>> GetTopicAsync(string idTopic)
        {
            var topic = await repositoryTop.GetTopicAsync(idTopic);
            if(topic is null)
            {
                return NotFound();
            }
            return topic.AsDtoTopic() ;
        }
        //POST/topic
        [HttpPost]
        public  async Task<ActionResult> CreateTopicAsync(CreateTopicDto topicDto)
        {
            Topic topic = new()
            {
                _id = topicDto.idTop,
                nameTop = topicDto.nameTop
            };
            await repositoryTop.CreateTopicAsync(topic);
            return CreatedAtAction(nameof(GetTopicAsync),new {idTopic = topic._id}, topic.AsDtoTopic());
        }
        [HttpPut("{idTopic}")]
        public  async Task<ActionResult> UpdateTopicAsync(string idTopic, CreateTopicDto topicDto)
        {
            var existingTopic = await repositoryTop.GetTopicAsync(idTopic);
            if(existingTopic is null)
            {
                return NotFound();
            }
            Topic updateTopic = existingTopic with
            {
                _id = topicDto.idTop,
                nameTop = topicDto.nameTop
            } ;
            await repositoryTop.UpdateTopicAsync(updateTopic);
            // return Content("Update Topic thanh cong");
            return NoContent();
        }
        [HttpDelete("{idTopic}")]
        public  async Task<ActionResult> DeleteTopicAsync(string idTopic)
        {
            var existingTopic = repositoryTop.GetTopicAsync(idTopic);
            if(existingTopic is null)
            {
                return NotFound();
            }
            await repositoryTop.DeleteTopicAsync(idTopic);
            return NoContent();
        }
    }
}