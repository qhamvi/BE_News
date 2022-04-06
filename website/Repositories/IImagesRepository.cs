using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using website.Entities;

namespace website.Repositories
{
    public interface IImagesRepository
    {
        List<Image> Images { get; }

        Task<Image> GetImageAsync(Guid idImage);
        Task<IEnumerable<Image>> GetImagesAsync();
        Task CreateImageAsync(Image image);
        Task UpdateImageAsync(Image image);
        Task DeleteImageAsync(Guid idImage);
    }

}