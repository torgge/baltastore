using System;

namespace BaltaStore.Domain.StoreContent.Entities
{
    public class Delivery
    {
        public Delivery(DateTime estimateDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimateDeliveryDate = estimateDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimateDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public override string ToString()
        {
            return $"{CreateDate.ToString()} {EstimateDeliveryDate.ToString() }";
        }

        public void Ship()
        {
            //Se a Data estimada de entrega for no passado, não entregar.
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //Se o status já estiver entrega, não pode cancelar.
            Status = EDeliveryStatus.Canceled;
        }
    }
}