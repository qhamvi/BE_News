using System.ComponentModel.DataAnnotations;
namespace website.Dtos
{
    public class CreateNewDto
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

        // Không để status vì khai báo ở NewController mặc định thành false rồi
        // Nếu để thì status = true
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

    }
}