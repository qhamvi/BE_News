using System;

namespace website.Dtos
{
    public record UserDto
    {
        public Guid idUser { get; init; }
        public string name { get; init; }
        public string email { get; init; }
        public string sdt { get; init; }
        public string idAc { get; init; }
        
    }
}