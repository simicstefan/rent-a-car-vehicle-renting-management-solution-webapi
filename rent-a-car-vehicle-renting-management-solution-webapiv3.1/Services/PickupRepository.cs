using Microsoft.EntityFrameworkCore;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
        public class PickupRepository : IPickupRepository
    {
        private readonly ApplicationDbContext _db;

        public PickupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Pickup entity)
        {
            await _db.Pickups.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Pickup entity)
        {
            _db.Pickups.Remove(entity);
            return await Save();
        }

        public async Task<IList<Pickup>> FindAll()
        {
            var pickups = await _db.Pickups.ToListAsync();
            return pickups;
        }

        public async Task<Pickup> FindById(int id)
        {
            var pickup = await _db.Pickups.FindAsync(id);
            return pickup;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Pickups.AnyAsync(q => q.IDPickup == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Pickup entity)
        {
            _db.Pickups.Update(entity);
            return await Save();
        }
    }

}