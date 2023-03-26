using System.ComponentModel.DataAnnotations;

namespace ShopperNet.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public int ItemPrice { get; set; }

        public int Quantity { get; set; }

        public string Email { get; set; }

       


    }


}
