using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Web.Models
{
	public class AppUserUpdateModel
	{
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public IFormFile Picture { get; set; }
	}
}
