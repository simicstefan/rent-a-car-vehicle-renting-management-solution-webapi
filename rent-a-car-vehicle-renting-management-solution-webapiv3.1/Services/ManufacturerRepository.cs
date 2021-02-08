using Microsoft.EntityFrameworkCore;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ApplicationDbContext _db;

        public ManufacturerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Manufacturer entity)
        {
            await _db.Manufacturers.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Manufacturer entity)
        {
            _db.Manufacturers.Remove(entity);
            return await Save();
        }

        public async Task<IList<Manufacturer>> FindAll()
        {
            var manufacturers = await _db.Manufacturers.ToListAsync();
            return manufacturers;
        }

        public async Task<Manufacturer> FindById(int id)
        {
            var manufacturer = await _db.Manufacturers.FindAsync(id);
            return manufacturer;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Manufacturers.AnyAsync(q => q.IDManufacturer == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Manufacturer entity)
        {
            _db.Manufacturers.Update(entity);
            return await Save();
        }

    }
}