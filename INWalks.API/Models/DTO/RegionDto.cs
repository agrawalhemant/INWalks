using System.ComponentModel.DataAnnotations;

namespace INWalks.API.Models.DTO
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(2,ErrorMessage = "Length should be of 2 characters")]
        [MinLength(2,ErrorMessage = "Length should be of 2 characters")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
    public class UpdateRegionRequestDto
    {
        [Required]
        [MaxLength(2, ErrorMessage = "Length should be of 2 characters")]
        [MinLength(2, ErrorMessage = "Length should be of 2 characters")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }

    public enum RegionEnum
    {
        Code,
        Name
    }
}
