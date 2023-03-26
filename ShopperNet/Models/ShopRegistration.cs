using Microsoft.Build.Framework;

namespace ShopperNet.Models
{
    public class ShopRegistration
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Country { get; set; }


    }
}
