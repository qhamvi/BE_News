using System.ComponentModel.DataAnnotations;

namespace website.Dtos
{
    public record CreateImageDto
    {
       [Required]
        [MinLength(1)] 
        public string srcIma { get; init; }
        [Required]
        [MinLength(1)]
        public string idNew { get; init; }
    }

}