using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BaltaStore.Domain.StoreContent.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EorderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EorderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public override string ToString()
        {
            return $"{Customer.Name.ToString()} {Number}";
        }

        public void AddItem(OrderItem item)
        {
            //Valida Item
            _items.Add(item);
        }

        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }

        //Criar um pedido
        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
        }

        //Pagar um pedido
        public void Pay()
        {
            Status = EorderStatus.Paid;
        }

        //Enviar um pedido
        public void Ship()
        {
            //A cada 5 produtos é uma entrega
            var count = 1;
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 0;
                    _deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }

                count++;
            }

            //Envia todas as entregas
            _deliveries.ToList().ForEach(x => x.Ship());
            //Adiciona todas as entregas ao pedido
            _deliveries.ToList().ForEach(x => _deliveries.Add(x));
        }

        //Cancelar um pedido
        public void Cancel()
        {
            Status = EorderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}