using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using website.Entities;

namespace website.Repositories
{
    public interface PPositionsRepository
    {
        List<Position> Positions { get; }

        Task<Position> GetPositionAsync(string idPosition);
        Task<IEnumerable<Position>> GetPositionsAsync();

        Task CreatePositionAsync(Position position);

        Task UpdatePositionAsync(Position position);

        Task DeletePositionAsync(string idPosition);


    }
}