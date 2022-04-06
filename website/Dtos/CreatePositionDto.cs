using System.ComponentModel.DataAnnotations;

namespace website.Dtos
{
    public record CreatePositionDto
    {
        [Required]
        [MinLength(1)]
        public string idPo { get; init; }
        [Required]
        [MinLength(1)]
        public string namePo { get; init; }

    }
}