using System;

namespace BaltaStore.Domain.StoreContent.Entities
{
    public class Delivery
    {
        public DateTime CreateDate { get; set; }
        public DateTime EstimateDeliveryDate { get; set; }
        public string Status { get; set; }
    }
}