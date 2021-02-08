using Microsoft.EntityFrameworkCore;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
        public class TransmissionRepository : ITransmissionRepository
    {
        private readonly ApplicationDbContext _db;

        public TransmissionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Transmission entity)
        {
            await _db.Transmissions.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Transmission entity)
        {
            _db.Transmissions.Remove(entity);
            return await Save();
        }

        public async Task<IList<Transmission>> FindAll()
        {
            var transmissions = await _db.Transmissions.ToListAsync();
            return transmissions;
        }

        public async Task<Transmission> FindById(int id)
        {
            var transmission = await _db.Transmissions.FindAsync(id);
            return transmission;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Transmissions.AnyAsync(q => q.IDTransmission == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Transmission entity)
        {
            _db.Transmissions.Update(entity);
            return await Save();
        }
    }

}