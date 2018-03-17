namespace BaltaStore.Domain.StoreContent.Entities
{
    public class Product
    {
        public Product(string title, string description, string image, string price, decimal quantity)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityOnHand = quantity;
        }
        
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public string Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }

        public override string ToString()
        {
            return $"{Title} {Description} {Price} {QuantityOnHand.ToString()}";
        }
    }
}