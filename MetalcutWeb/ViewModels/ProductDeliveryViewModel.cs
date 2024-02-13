using MetalcutWeb.Domain.Entity;

namespace MetalcutWeb.ViewModels
{
    public class ProductDeliveryViewModel
    {
        public string ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdDesciption { get; set; }
        public double Price { get; set; }
        public AppUser RequestedUser { get; set; }
        public AppUser AcceptedUser { get; set; }
        public Delivery Delivery{ get; set; }
        public ProductEntity Product { get; set; }
    }
}
