using System.ComponentModel.DataAnnotations;

namespace website.Dtos
{
    public record CreateAccountDto
    {
        [Required]
        [MinLength(1)]

        public string uname { get; init; }
        [Required]
        [MinLength(1)]
        public string pass { get; init; }

        [Required]
        [MinLength(1)]

        public string idPo { get; init; }
    }
}