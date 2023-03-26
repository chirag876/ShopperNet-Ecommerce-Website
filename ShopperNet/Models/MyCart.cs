namespace ShopperNet.Models
{
    public class MyCart
    {
        public int CartId { get; set; }
        public Items items { get; set; }

        public int Quantity { get; set; }

        public int totalprice { get; set; }

    }
}
