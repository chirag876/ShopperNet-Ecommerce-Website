using System.ComponentModel.DataAnnotations;

namespace ShopperNet.Models
{
    public class shippingadd
    {
        [Key]
        public int shipaddid { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
    }
}
