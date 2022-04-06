using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Entities;

namespace website.Repositories
{


    public class InMemPositionsRepository : PPositionsRepository
    {
        private readonly List<Position> positions = new()
        {
            new Position { _id = "admin", namePo = "Admin" },
            new Position { _id = "author", namePo = "Author" }, //Tác giả
            new Position { _id = "editor", namePo = "Editor" }//Biên tập

        };
        public List<Position> Positions => positions;
        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await Task.FromResult(positions);
        }
        public async Task<Position> GetPositionAsync(string idPosition)
        {
            var position = positions.Where(position => position._id == idPosition).SingleOrDefault();
            return await Task.FromResult(position);
        }

        public async Task CreatePositionAsync(Position position)
        {
            positions.Add(position);
            await Task.CompletedTask;
        }
        //UpdatePosition có idPo là chuối string sẽ khác với idPo Gui
        //Giá trị cập nhật phải là namePo vì idPo (string) là mặc định để tìm kiếm rồi
        public async Task UpdatePositionAsync(Position position2)
        {
            var index = positions.FindIndex(existingNew => existingNew._id == position2._id);
            positions[index] = position2;
            await Task.CompletedTask;
        }

        public async Task DeletePositionAsync(string idPosition)
        {
            var index = positions.FindIndex(existingPosition => existingPosition._id == idPosition);
            positions.RemoveAt(index);
            await Task.CompletedTask;
        }
    }

}