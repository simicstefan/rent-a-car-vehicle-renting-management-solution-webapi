using Microsoft.EntityFrameworkCore;
using rent_a_car_vehicle_renting_management_solution_webapi.Contracts;
using rent_a_car_vehicle_renting_management_solution_webapi.Data;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.Services
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(City entity)
        {
            await _db.Cities.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(City entity)
        {
            _db.Cities.Remove(entity);
            return await Save();
        }

        public async Task<IList<City>> FindAll()
        {
            var cities = await _db.Cities.ToListAsync();
            return cities;
        }

        public async Task<City> FindById(int id)
        {
            var city = await _db.Cities.FindAsync(id);
            return city;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Cities.AnyAsync(q => q.IDCity == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(City entity)
        {
            _db.Cities.Update(entity);
            return await Save();
        }
    }
}
