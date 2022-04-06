using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Repositories;

namespace website.Entities
{

    public class InMemImagesRepository : IImagesRepository
    {
        private readonly List<Image> images = new()
        {
            new Image { _id = Guid.NewGuid(), srcIma = "https://dean2020.edu.vn/wp-content/uploads/2019/05/hinh-anh-hoa-sen-12.jpg", idNew = "idNew1 " },
            new Image { _id = Guid.NewGuid(), srcIma = "https://dean2020.edu.vn/wp-content/uploads/2019/05/hinh-anh-hoa-sen-2.jpg", idNew = "idNew2" },
            new Image { _id = Guid.NewGuid(), srcIma = "https://dean2020.edu.vn/wp-content/uploads/2019/05/hinh-anh-hoa-sen-32.jpg", idNew = "idNew3" },

        };

        public List<Image> Images => images;

        public async Task<IEnumerable<Image>> GetImagesAsync()
        {
            return await Task.FromResult(Images);
        }

        public async Task<Image> GetImageAsync(Guid idImage)
        {
            var image =  images.Where(idIMa => idIMa._id == idImage).SingleOrDefault();
            return await Task.FromResult(image);
        }

        public async Task CreateImageAsync(Image image)
        {
            images.Add(image);
            await Task.CompletedTask;
        }

        public async Task UpdateImageAsync(Image image)
        {
            var index = images.FindIndex(existingImage => existingImage._id == image._id);
            images[index] = image;
            await Task.CompletedTask;

        }

        public async Task DeleteImageAsync(Guid idImage)
        {
            var index = images.FindIndex(existingImage => existingImage._id == idImage);
            images.RemoveAt(index);
            await Task.CompletedTask;
        }
    }

}