using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; //ControllerBase
using website.Dtos;
using website.Entities;//Position
using website.Repositories;//InMemPositionsRepository

namespace website.Controllers
{
    
    [ApiController]
    [Route("positions")]
    public class PositionsController : ControllerBase
    {
        private readonly PPositionsRepository repositoryPo;
        public PositionsController(PPositionsRepository repositoryPo2)
        {
            this.repositoryPo = repositoryPo2;
        }

        //GET/ positions 
        [HttpGet]
        public async Task<IEnumerable<PositionDto>> GetPositionsAsync()
        {
            var positions = (await repositoryPo.GetPositionsAsync())
                            .Select(position => position.AsDtoPosition());
            return positions;
        }
        
        //GET/positions/{idPosition}
        [HttpGet("{idPosition}")]
        public async Task<ActionResult<PositionDto>> GetPositionAsync(string idPosition)
        {
            var position = await repositoryPo.GetPositionAsync(idPosition);
            if(position is null)
            {
                return NotFound();
            }
            return position.AsDtoPosition();
        }
        //POST/positions
        [HttpPost]
        public async Task<ActionResult<PositionDto>> CreatePositionAsync(CreatePositionDto positionDto)
        {
            Position position = new()
            {
                _id = positionDto.idPo,
                namePo = positionDto.namePo
            };
            await repositoryPo.CreatePositionAsync(position);
            return CreatedAtAction(nameof(GetPositionAsync), new { idPosition = position._id }, position.AsDtoPosition());           
        }
        //PUT/position 
        [HttpPut("{idPosition}")]
        //Vi position chi dung hai gia tri idPo va namePo nen 
        //Ko can tao them UpdatePositionDto , lay CreatePositionDto la ok
        public async Task<ActionResult> UpdatePositionAsync(string idPosition, CreatePositionDto positionDto)
        {
            var existingPosition = await repositoryPo.GetPositionAsync(idPosition);
            if (existingPosition is null)
            {
                return NotFound();
            }
            Position updatePosition = existingPosition with
            {
               _id = positionDto.idPo,
               namePo = positionDto.namePo
            };
            await repositoryPo.UpdatePositionAsync(updatePosition);
            return NoContent();
        }
        //DELETE/position
        [HttpDelete("{idPosition}")]
        public async Task<ActionResult> DeletePositionAsync(string idPosition)
        {
            var existingPosition = await repositoryPo.GetPositionAsync(idPosition);
            if(existingPosition is null)
            {
                return NotFound();
            }
            await repositoryPo.DeletePositionAsync(idPosition);
            return NoContent();
        }
    }
}