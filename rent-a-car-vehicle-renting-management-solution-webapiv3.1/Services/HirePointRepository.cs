using Microsoft.EntityFrameworkCore;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class HirePointRepository : IHirePointRepository
    {
        private readonly ApplicationDbContext _db;

        public HirePointRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(HirePoint entity)
        {
            await _db.HirePoints.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(HirePoint entity)
        {
            _db.HirePoints.Remove(entity);
            return await Save();
        }

        public async Task<IList<HirePoint>> FindAll()
        {
            var hirepoints = await _db.HirePoints.ToListAsync();
            return hirepoints;
        }

        public async Task<HirePoint> FindById(int id)
        {
            var hirepoint = await _db.HirePoints.FindAsync(id);
            return hirepoint;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.HirePoints.AnyAsync(q => q.IDHirePoint == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(HirePoint entity)
        {
            _db.HirePoints.Update(entity);
            return await Save();
        }

    }
}