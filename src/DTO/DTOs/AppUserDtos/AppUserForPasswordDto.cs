using DTO.Interfaces;

namespace DTO.DTOs.AppUserDtos
{
    public class AppUserForPasswordDto : IDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}