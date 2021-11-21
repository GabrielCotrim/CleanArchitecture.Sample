using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Sample.Application.DTOs.Requests
{
    public class CreateProductRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
