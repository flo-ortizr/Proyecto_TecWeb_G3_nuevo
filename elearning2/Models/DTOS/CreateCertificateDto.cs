using System;
using System.ComponentModel.DataAnnotations;

namespace elearning2.Models.DTOS
{
    public record CreateCertificateDto
    {
        [Required]
        public Guid StudentId { get; init; }

        [Required]
        public string Title { get; init; }

        public string? Description { get; init; }
    }
}
