using System.ComponentModel.DataAnnotations;

namespace INWalks.API.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKms { get; set; }
        public string? WalkImageUrl { get; set; }
        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }

    public class AddWalkRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Max length of description is 500 characters")]
        public string Description { get; set; }
        [Required]
        [Range(0,50, ErrorMessage ="Length of walk should be between 0 and 50 kms")]
        public double LengthInKms { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }

    public class UpdateWalkRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Max length of description is 500 characters")]
        public string Description { get; set; }
        [Required]
        [Range(0, 50, ErrorMessage = "Length of walk should be between 0 and 50 kms")]
        public double LengthInKms { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
