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
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _db;

        public ClientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Client entity)
        {
            await _db.Clients.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Client entity)
        {
            _db.Clients.Remove(entity);
            return await Save();
        }

        public async Task<IList<Client>> FindAll()
        {
            var clients = await _db.Clients.ToListAsync();
            return clients;
        }

        public async Task<Client> FindById(int id)
        {
            var client = await _db.Clients.FindAsync(id);
            return client;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Clients.AnyAsync(q => q.IDClient == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Client entity)
        {
            _db.Clients.Update(entity);
            return await Save();
        }
    }
}
