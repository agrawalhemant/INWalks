﻿using System.ComponentModel.DataAnnotations;

namespace INWalks.API.Models.DTO
{
    public class ImageDto
    {
    }
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
