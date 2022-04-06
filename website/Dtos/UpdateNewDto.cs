using System;
using System.ComponentModel.DataAnnotations;

namespace website.Dtos
{
    public record UpdateNewDto
    {
        [Required]
        [MinLength(1)]
        public string title { get; init; } // nhap
        [Required]
        [MinLength(1)]
        public string description { get; init; } // nhap
        [Required]
        [MinLength(1)]
        public string content { get; init; } //nhap
        // [Required]
        // [MinLength(1)]
        // public bool status { get; init; }
        [Required]
        [MinLength(1)]
        public string idImage { get; init; } //nhap
        [Required]
        [MinLength(1)]
        public string idTop { get; init; } // nhap
        [Required]
        [MinLength(1)]
        public string idAc { get; init; } //nhap
        // public DateTimeOffset creatDate { get; init; }

    }
}