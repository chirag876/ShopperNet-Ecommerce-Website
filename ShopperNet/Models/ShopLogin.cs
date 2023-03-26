using System.ComponentModel.DataAnnotations;

namespace ShopperNet.Models
{
    public class ShopLogin
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
