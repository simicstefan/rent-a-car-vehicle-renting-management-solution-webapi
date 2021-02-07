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
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _db;

        public ReservationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Reservation entity)
        {
            await _db.Reservations.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Reservation entity)
        {
            _db.Reservations.Remove(entity);
            return await Save();
        }

        public async Task<IList<Reservation>> FindAll()
        {
            var reservations = await _db.Reservations.ToListAsync();
            return reservations;
        }

        public async Task<Reservation> FindById(int id)
        {
            var reservation = await _db.Reservations.FindAsync(id);
            return reservation;
        }

        public async Task<bool> isExists(int id)
        {
            return await _db.Reservations.AnyAsync(q => q.IDReservation == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Reservation entity)
        {
            _db.Reservations.Update(entity);
            return await Save();
        }
    }
}
