using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MetalcutWeb.Domain.Entity
{
    public class Delivery
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // Navigation properties
        public AppUser RequestedUser { get; set; } // The customer
        public AppUser AcceptedUser { get; set; } // The manager or employee that accepted the delivery
        public ProductEntity DeliveryProduct { get; set; }

  /*      // Foreign key properties
        public string RequestedUserId { get; set; } // Foreign key for RequestedUser
        public string AcceptedUserId { get; set; } // Foreign key for AcceptedUser
        public string DeliveryProductId { get; set; } // Foreign key for DeliveryProduct

*/        // Other properties
        public DateTime RequestedTime { get; set; } = DateTime.Now;
        public DateTime? AcceptedTime { get; set; }
        public bool IsAccepted { get; set; } = false;
        public double Price { get; set; }
    }


}
