namespace MetalcutWeb.DAL.Repository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        IProductRepository Product { get; }
        IDeliveryRepository Delivery { get; }
        IDepartmentRepository Department { get; }
        IChatRepository Chat { get; }
        Task Save();
    }
}
