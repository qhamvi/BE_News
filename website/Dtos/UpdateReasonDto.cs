using System.ComponentModel.DataAnnotations;

namespace website.Dtos
{
    public record UpdateReasonDto
    {
        [Required]
        [MinLength(1)]
        public string idNew { get; init; }
        [Required]
        [MinLength(1)]
        public string contentRea { get; init; }
    }
}