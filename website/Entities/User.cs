using System;

namespace website.Entities
{
    public record User
    {
        public Guid _id { get; init; }
        public string name { get; init; }
        public string sdt { get; init; }
        public string email { get; init; }
        public string idAc { get; init; }

    }

}