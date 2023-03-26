using System.ComponentModel.DataAnnotations;

namespace ShopperNet.Models
{
    public class Items
    {
        [Key]
        
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ItemImage { get; set; }
        [Display(Name = "Price")]
        public int ItemPrice { get; set; }
    }
}

