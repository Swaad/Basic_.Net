using System.ComponentModel.DataAnnotations;

namespace DLS_WebAPI.Models
{
    public class PointOfInterestForUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
