using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    [Table("Pickup")]
    public partial class Pickup
    {
        [Key]
        public int IDPickup { get; set; }
        public int IDReservation { get; set; }
        public int IDClient { get; set; }
        public int IDVehicle { get; set; }
        public DateTime PickupStart { get; set; }
        public DateTime PickupEnd { get; set; }
        public decimal Price { get; set; }
        public int IDHirePointStart { get; set; }
        public int IDHirePointEnd { get; set; }
        public int VehicleReturned { get; set; }
        public int IDUser_insert { get; set; }
        public DateTime DateTime_insert { get; set; }
        public int IDUser_update { get; set; }
        public DateTime DateTime_update { get; set; }
        public int KilometerStart { get; set; }
        public int KilometerEnd { get; set; }
    }
}