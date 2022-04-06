using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using website.Dtos;
using website.Entities;
using website.Repositories;

namespace website.Controllers
{
    [ApiController]
    [Route("reasons")]
    public class ReasonsController : ControllerBase
    {
        private readonly RReasonsRepository repositoryReason ;

        public ReasonsController(RReasonsRepository repositoryReason2)
        {
            this.repositoryReason = repositoryReason2;
        }

        //GET/reasons
        [HttpGet]
        public async Task<IEnumerable<ReasonDto>> GetReasonsAsync()
        {
            var reasons = (await repositoryReason.GetReasonsAsync())
                        .Select(reason => reason.AsDtoReason());
            return reasons;
        }

        //GET/reasons/{idReason}
        [HttpGet("{idReason}")]
        public async Task<ActionResult<ReasonDto>> GetReasonAsync(Guid idReason)
        {
            var reason = await repositoryReason.GetReasonAsync(idReason);
            if(reason is null)
            {
                return NotFound();
            }
            return reason.AsDtoReason();
        }

        //POST/reasons
        [HttpPost]
        public async Task<ActionResult> CreateReasonAsync (CreateReasonDto reasonDto)
        {
            Reason reason = new()
            {
                _id = Guid.NewGuid(),
                idNew = reasonDto.idNew,
                contentRea = reasonDto.contentRea
            };
            await repositoryReason.CreateReasonAsync(reason);
            return CreatedAtAction(nameof(GetReasonAsync), new { idReason = reason._id }, reason.AsDtoReason());           
        }
        //PUT/reasons/{idReason}
        [HttpPut("{idReason}")]
        public async Task<ActionResult> UpdateReasonAsync (Guid idReason, CreateReasonDto reasonDto)
        {
            var existingReason = await repositoryReason.GetReasonAsync(idReason);
            if (existingReason is null)
            {
                return NotFound();
            }
            Reason updateReason = existingReason with {
                idNew = reasonDto.idNew,
                contentRea = reasonDto.contentRea
            }; 
            await repositoryReason.UpdateReasonAsync(updateReason);
            return NoContent();
        }

        //DELETE/reasons/{idReason}
        [HttpDelete("{idReason}")]
        public async Task<ActionResult> DeleteReasonAsync( Guid idReason)
        {
            var existingReason = await repositoryReason.GetReasonAsync(idReason);
            if ( existingReason is null)
            {
                return NotFound();
            }
            await repositoryReason.DeleteReasonAsync(idReason);
            return NoContent();
        }

    }
    
}