using System;

namespace website.Entities
{
    public record Reason
    {
        public Guid _id { get; init; }

        public string idNew { get; init; }
        public string contentRea { get; init; }
    }
    
}