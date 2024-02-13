using MetalcutWeb.DAL.Data;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.DAL.Implementations
{
    public class DeliveryRepository : Repository<Delivery>, IDeliveryRepository
    {
        private AppDbContext _db;
        public DeliveryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Delivery> AcceptDelivery(AppUser employee, Delivery delivery)
        {
            /*            var deliveryList = await _db.Deliveries
                                                        .Include(d => d.DeliveryProduct)
                                                        .Include(d => d.RequestedUser)
                                                        .ToListAsync();*/
            var deliveryFromDb = await _db.Deliveries.FirstOrDefaultAsync(d => d.Id == delivery.Id);
            deliveryFromDb.IsAccepted = true;
            deliveryFromDb.AcceptedUser = employee;
            deliveryFromDb.AcceptedTime = DateTime.Now;
            await _db.SaveChangesAsync();
            return deliveryFromDb;

        }


        public async Task RequestDelivery(AppUser customer, ProductEntity productEntity)
        {
            Delivery delivery = new Delivery();
            delivery.DeliveryProduct = productEntity;
            delivery.RequestedUser = customer;
            delivery.RequestedTime = DateTime.Now;
            delivery.Price = productEntity.Price;
            await _db.Deliveries.AddAsync(delivery);
        }
    }
}
