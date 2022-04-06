using System;
using System.ComponentModel.DataAnnotations;

namespace website.Dtos
{
    public record CreateUserDto
    {
        [Required]
        [MinLength(1)]
        public string name { get; init; }
        [Required]
        [MinLength(1)]
        public string email { get; init; }
        [Required]
        [MinLength(1)]
        public string sdt { get; init; }
        [Required]
        [MinLength(1)]
        public string idAc { get; init; }
        
        
    }
}