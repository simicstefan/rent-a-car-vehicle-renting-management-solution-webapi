using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.Data
{
    [Table("Reservation")]
    public partial class Reservation
    {
        [Key]
        public int IDReservation { get; set; }
        public int IDClient { get; set; }
        public int IDVehicle { get; set; }
        public int IDHirePointStart { get; set; }
        public int? IDHirePointEnd { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public decimal Price { get; set; }
        public int IDReservationStatus { get; set; }
        public int IDUser_insert { get; set; }
        public DateTime DateTime_insert { get; set; }
        public int IDUser_update { get; set; }
        public DateTime DateTime_update { get; set; }
    }
}
