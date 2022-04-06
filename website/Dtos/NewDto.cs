using System;

namespace website.Dtos
{
    public record NewDto
    {
        public Guid idNew { get; init; }
        public string title { get; init; } // nhap
        public string description { get; init; } // nhap
        public string content { get; init; } //nhap
        public bool status { get ; init; }
    
        public string idImage { get; init; } //nhap
        public string idTop { get; init; } // nhap
        public string idAc { get; init; } //nhap
        public DateTimeOffset creatDate {get; init; }  

    }
}