
namespace ShopBridge.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string DateOfCreation { get; set; }
        public string DateOfUpdation { get; set; }
        public string DateOfDeletion { get; set; }
        public bool IsActive { get; set; }

    }
}