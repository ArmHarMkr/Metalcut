using System;
using System.Diagnostics.CodeAnalysis;

namespace MetalcutWeb.Domain.Entity
{
    public class Delivery
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public AppUser RequestedUser { get; set; } // The customer
        [AllowNull]
        public AppUser AcceptedUser { get; set; } = null; // The manager or employee that accepted the delivery
        public ProductEntity DeliveryProduct { get; set; }
        public DateTime RequestedTime { get; set; } = DateTime.Now;
        [AllowNull]
        public DateTime AcceptedTime { get; set; }
        public bool IsAccepted { get; set; } = false;
        public double Price { get; set; }
    }
}
