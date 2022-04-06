using System;

namespace website.Dtos
{
    public record CheckAccountDto
    {
        public string uname { get; init; }
        public string pass { get; init; }

    }
}