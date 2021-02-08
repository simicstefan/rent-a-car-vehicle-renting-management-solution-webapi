using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapiv3._1.DTOs
{
    public class ReservationDTO
    {
        public int IDReservation { get; set; }
        public int IDClient { get; set; }
        public int IDVehicle { get; set; }
        public int IDHirePointStart { get; set; }
        public int IDHirePointEnd { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public decimal Price { get; set; }
        public int IDReservationStatus { get; set; }
        public int IDUser_insert { get; set; }
        public DateTime DateTime_insert { get; set; }
        public int IDUser_update { get; set; }
        public DateTime DateTime_update { get; set; }
    }

    public class ReservationCreateDTO
    {
        [Required]
        public int IDClient { get; set; }
        [Required]
        public int IDVehicle { get; set; }
        [Required]
        public int IDHirePointStart { get; set; }
        public int IDHirePointEnd { get; set; }
        [Required]
        public DateTime ReservationStart { get; set; }
        [Required]
        public DateTime ReservationEnd { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int IDUser_insert { get; set; }
        [Required]
        public DateTime DateTime_insert { get; set; }
        [Required]
        public int IDUser_update { get; set; }
        [Required]
        public DateTime DateTime_update { get; set; }
    }

    public class ReservationUpdateDTO
    {
        [Required]
        public int IDReservation { get; set; }
        [Required]
        public int IDClient { get; set; }
        [Required]
        public int IDVehicle { get; set; }
        [Required]
        public int IDHirePointStart { get; set; }
        [Required]
        public int IDHirePointEnd { get; set; }
        [Required]
        public DateTime ReservationStart { get; set; }
        [Required]
        public DateTime ReservationEnd { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int IDReservationStatus { get; set; }
        [Required]
        public int IDUser_insert { get; set; }
        [Required]
        public DateTime DateTime_insert { get; set; }
        [Required]
        public int IDUser_update { get; set; }
        [Required]
        public DateTime DateTime_update { get; set; }
    }

}
