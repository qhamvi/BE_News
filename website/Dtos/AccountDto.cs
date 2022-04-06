using System;

namespace website.Dtos
{
    public record AccountDto
    {
        public Guid idAc { get; init; }
        public string uname { get; init; }
        public string pass { get; init; }
        public string idPo { get; init; }

    }
}