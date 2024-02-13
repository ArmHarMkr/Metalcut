using MetalcutWeb.Domain.Entity;


namespace MetalcutWeb.DAL.Repository
{
    public interface IDeliveryRepository : IRepository<Delivery>
    {
        Task<Delivery> AcceptDelivery(AppUser employee, Delivery delivery);
        Task RequestDelivery(AppUser customer, ProductEntity productEntity);
    }
}