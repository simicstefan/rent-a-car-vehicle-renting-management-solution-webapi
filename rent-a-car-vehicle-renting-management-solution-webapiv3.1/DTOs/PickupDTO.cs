using System;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class PickupDTO
    {
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

    public class PickupCreateDTO
    {
        public int IDReservation { get; set; }
        [Required]
        public int IDClient { get; set; }
        [Required]
        public int IDVehicle { get; set; }
        [Required]
        public DateTime PickupStart { get; set; }
        [Required]
        public DateTime PickupEnd { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int IDHirePointStart { get; set; }
        [Required]
        public int IDHirePointEnd { get; set; }
        [Required]
        public int IDUser_insert { get; set; }
        [Required]
        public DateTime DateTime_insert { get; set; }
        [Required]
        public int IDUser_update { get; set; }
        [Required]
        public DateTime DateTime_update { get; set; }
        [Required]
        public int KilometerStart { get; set; }
        public int KilometerEnd { get; set; }
    }

    public class PickupUpdateDTO
    {
        [Required]
        public int IDPickup { get; set; }
        public int IDReservation { get; set; }
        [Required]
        public int IDClient { get; set; }
        [Required]
        public int IDVehicle { get; set; }
        [Required]
        public DateTime PickupStart { get; set; }
        [Required]
        public DateTime PickupEnd { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int IDHirePointStart { get; set; }
        [Required]
        public int IDHirePointEnd { get; set; }
        [Required]
        public int VehicleReturned { get; set; }
        [Required]
        public int IDUser_insert { get; set; }
        [Required]
        public DateTime DateTime_insert { get; set; }
        [Required]
        public int IDUser_update { get; set; }
        [Required]
        public DateTime DateTime_update { get; set; }
        [Required]
        public int KilometerStart { get; set; }
        public int KilometerEnd { get; set; }
    }


}