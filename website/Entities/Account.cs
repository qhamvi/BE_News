using System;

namespace website.Entities
{
    public record Account
    {
        public Guid _id { get; init; }
        public string uname { get; init; }
        public string pass { get; init; }
        public string idPo {get; init; }

    }
}