using System;//Guid

namespace website.Entities
{
    public record Image
    {
        public Guid _id { get; init; }
        public string srcIma { get; init; }
        public string idNew { get; init; }

    }
}