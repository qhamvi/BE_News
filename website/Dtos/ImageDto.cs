using System;

namespace website.Dtos
{
     public record ImageDto
    {
        public Guid idIma { get; init; }
        public string srcIma { get; init; }
        public string idNew { get; init; }

    }
}