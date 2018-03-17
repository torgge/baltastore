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
    }
}