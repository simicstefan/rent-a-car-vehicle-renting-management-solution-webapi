using Microsoft.EntityFrameworkCore;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _db;

        public ServiceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Service entity)
        {
            await _db.Services.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Service entity)
        {
            _db.Services.Remove(entity);
            return await Save();
        }

        public async Task<IList<Service>> FindAll()
        {
            var services = await _db.Services.ToListAsync();
            return services;
        }

        public async Task<Service> FindById(int id)
        {
            var service = await _db.Services.FindAsync(id);
            return service;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Services.AnyAsync(q => q.IDService == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Service entity)
        {
            _db.Services.Update(entity);
            return await Save();
        }
    }
}