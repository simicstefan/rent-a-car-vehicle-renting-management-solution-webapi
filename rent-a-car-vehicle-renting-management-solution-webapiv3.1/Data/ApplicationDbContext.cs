using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rent_a_car_vehicle_renting_management_solution_webapi;
using rent_a_car_vehicle_renting_management_solution_webapi.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<HirePoint> HirePoints { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Pickup> Pickups { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<ServiceNotification> ServiceNotifications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
