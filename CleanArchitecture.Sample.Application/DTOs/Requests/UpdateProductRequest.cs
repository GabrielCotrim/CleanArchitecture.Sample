using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Sample.Application.DTOs.Requests
{
    public class UpdateProductRequest : CreateProductRequest
    {
        [Required]
        [Range(0, 100)]
        public int Stock { get; set; }
    }
}
