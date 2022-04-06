using System;
using System.ComponentModel.DataAnnotations;

namespace website.Dtos
{
    public record CreateTopicDto
    {
        [Required]
        [MinLength(1)]
        public string idTop { get; init; }
        [Required]
        [MinLength(1)]
        public string nameTop { get; init; }
    }
}