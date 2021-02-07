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
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _db;

        public DocumentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Document entity)
        {
            await _db.Documents.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Document entity)
        {
            _db.Documents.Remove(entity);
            return await Save();
        }

        public async Task<IList<Document>> FindAll()
        {
            var documents = await _db.Documents.ToListAsync();
            return documents;
        }

        public async Task<Document> FindById(int id)
        {
            var document = await _db.Documents.FindAsync(id);
            return document;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Documents.AnyAsync(q => q.IDDocument == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Document entity)
        {
            _db.Documents.Update(entity);
            return await Save();
        }
    }
}
