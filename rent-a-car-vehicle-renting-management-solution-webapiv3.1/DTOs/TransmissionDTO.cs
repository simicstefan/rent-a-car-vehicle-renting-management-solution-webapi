using System;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class TransmissionDTO
    {
        public int IDTransmission { get; set; }
        public string TransmissionName { get; set; }
    }

    public class TransmissionCreateDTO
    {
        [Required]
        public string TransmissionName { get; set; }
    }

    public class TransmissionUpdateDTO
    {
        [Required]
        public int IDTransmission { get; set; }
        [Required]
        public string TransmissionName { get; set; }
    }
}