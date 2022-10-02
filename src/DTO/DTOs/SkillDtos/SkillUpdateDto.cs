using DTO.Interfaces;

namespace DTO.DTOs.SkillDtos
{
    public class SkillUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}