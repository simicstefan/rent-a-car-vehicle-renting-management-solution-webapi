using Microsoft.EntityFrameworkCore;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _db;

        public VehicleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Vehicle entity)
        {
            await _db.Vehicles.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Vehicle entity)
        {
            _db.Vehicles.Remove(entity);
            return await Save();
        }

        public async Task<IList<Vehicle>> FindAll()
        {
            var vehicles = await _db.Vehicles.ToListAsync();
            return vehicles;
        }

        public async Task<Vehicle> FindById(int id)
        {
            var vehicle = await _db.Vehicles.FindAsync(id);
            return vehicle;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Vehicles.AnyAsync(q => q.IDVehicle == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Vehicle entity)
        {
            _db.Vehicles.Update(entity);
            return await Save();
        }
    }
}