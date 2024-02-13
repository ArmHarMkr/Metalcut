namespace MetalcutWeb.DAL.Repository
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
        IProductRepository Product { get; }
        IDeliveryRepository Delivery { get; }
        Task Save();
    }
}
