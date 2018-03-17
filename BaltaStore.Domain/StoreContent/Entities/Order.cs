using System;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContent.Entities
{
    public class Order
    {
        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EorderStatus.Created;
            
        }
        
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EorderStatus Status { get; private set; }
        public IReadOnlyList<OrderItem> Items { get; private set; }
        public IReadOnlyList<OrderItem> Deliveries { get; private set; }

        public override string ToString()
        {
            return $"{Customer.FirstName} {Number}";
        }

        public void AddItem(OrderItem orderItem)
        {
            
        }
            

        //To Place an Order
        public void Place(){}
        
        
        
    }
}