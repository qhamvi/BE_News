using System;

namespace website.Dtos
{
    public record ReasonDto
    {
        public Guid idRea { get; init; }

        public string idNew { get; init; }
        public string contentRea { get; init; }
    }
}