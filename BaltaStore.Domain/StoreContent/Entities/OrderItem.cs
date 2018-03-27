using System.Net.Security;
using FluentValidator;

namespace BaltaStore.Domain.StoreContent.Entities
{
    public class OrderItem : Notifiable

    {
    public OrderItem(Product product, decimal quantity)
    {
        Product = product;
        Quantity = quantity;
        Price = product.Price;
        
        if (product.QuantityOnHand < quantity)
            AddNotification("Quantity","Produto fora de estoque.");
        
        Product.DecreaseQuantity(quantity);
    }

    public Product Product { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal Price { get; private set; }
    }
}