using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            Items = new List<OrderItem>();
            Deliveries = new List<OrderItem>(Deliveries);
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EorderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get; private set; }
        public IReadOnlyCollection<OrderItem> Deliveries { get; private set; }

        public override string ToString()
        {
            return $"{Customer.Name.ToString()} {Number}";
        }

        public void AddItem(OrderItem orderItem)
        {
            //Valida Item
            //Adiciona Item
        }


        //To Place an Order
        public void Place()
        {
        }
    }
}