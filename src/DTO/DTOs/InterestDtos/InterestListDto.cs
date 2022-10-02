using DTO.Interfaces;

namespace DTO.DTOs.InterestDtos
{
    public class InterestListDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}