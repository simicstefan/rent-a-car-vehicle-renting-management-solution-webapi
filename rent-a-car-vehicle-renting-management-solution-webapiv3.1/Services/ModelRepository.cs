using Microsoft.EntityFrameworkCore;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _db;

        public ModelRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Model entity)
        {
            await _db.Models.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Model entity)
        {
            _db.Models.Remove(entity);
            return await Save();
        }

        public async Task<IList<Model>> FindAll()
        {
            var models = await _db.Models.ToListAsync();
            return models;
        }

        public async Task<Model> FindById(int id)
        {
            var model = await _db.Models.FindAsync(id);
            return model;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Models.AnyAsync(q => q.IDModel == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Model entity)
        {
            _db.Models.Update(entity);
            return await Save();
        }
    }
}