using Microsoft.EntityFrameworkCore;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class ServiceNotificationRepository : IServiceNotificationRepository
    {
        private readonly ApplicationDbContext _db;
        public ServiceNotificationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(ServiceNotification entity)
        {
            await _db.ServiceNotifications.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(ServiceNotification entity)
        {
            _db.ServiceNotifications.Remove(entity);
            return await Save();
        }

        public async Task<IList<ServiceNotification>> FindAll()
        {
            var servicenotifications = await _db.ServiceNotifications.ToListAsync();
            return servicenotifications;
        }

        public async Task<ServiceNotification> FindById(int id)
        {
            var servicenotification = await _db.ServiceNotifications.FindAsync(id);
            return servicenotification;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.ServiceNotifications.AnyAsync(q => q.IDServiceNotification == id);
        }
        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }
        
        public async Task<bool> Update(ServiceNotification entity)
        {
            _db.ServiceNotifications.Update(entity);
            return await Save();
        }
    }

}