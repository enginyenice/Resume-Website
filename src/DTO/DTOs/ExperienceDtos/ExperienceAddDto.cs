using System;
using DTO.Interfaces;

namespace DTO.DTOs.ExperienceDtos
{
    public class ExperienceAddDto : IDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}