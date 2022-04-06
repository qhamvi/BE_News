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
    [Route("images")]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesRepository repositoryIma;

        public ImagesController(IImagesRepository repositoryIma2)
        {
            this.repositoryIma = repositoryIma2;
        }

        //GET/images
        [HttpGet]
        public async Task<IEnumerable<ImageDto>> GetImagesAsync()
        {
            var images =(await repositoryIma.GetImagesAsync())
                        .Select(image => image.AsDtoImage());
            return images;
        }

        //GET/images/{idIMage}
        [HttpGet("{idImage}")]
        public async Task<ActionResult<ImageDto>> GetImageAsync(Guid idImage)
        {
            var image = await repositoryIma.GetImageAsync(idImage);
            if (image is null)
            {
                return NotFound();
            }
            return image.AsDtoImage();
        }
        //POST/images
        [HttpPost]
        public async Task<ActionResult<ImageDto>> CreateImageAsync(CreateImageDto imageDto)
        {
            Image image = new()
            {
                _id = Guid.NewGuid(),
                idNew = imageDto.idNew,
                srcIma = imageDto.srcIma,
            };
            await repositoryIma.CreateImageAsync(image);
            return CreatedAtAction(nameof(GetImageAsync),new {idImage = image._id}, image.AsDtoImage());
        }
        //PUT/images/{idImage}
        [HttpPut("{idImage2}")]
        public async Task<ActionResult> UpdateImageAsync(Guid idImage2, UpdateImageDto imageDto)
        {
            var existingImage = await repositoryIma.GetImageAsync(idImage2);
            if(existingImage is null)
            {
                return NotFound();
            }
            Image updateImage = existingImage with
            {
                idNew = imageDto.idNew,
                srcIma = imageDto.srcIma
            };
            await repositoryIma.UpdateImageAsync(updateImage);
            return NoContent();
        }
        //DELETE/images/{idImage}
        //Author/Editor/Admin
        [HttpDelete("{idImage2}")]
        public async Task<ActionResult> DeleteImageAsync(Guid idImage2)
        {
            var existingImage = await repositoryIma.GetImageAsync(idImage2);
            if(existingImage is null )
            {
                return NotFound();
            }
            await repositoryIma.DeleteImageAsync(idImage2);
            return NoContent();
        }

    }
}