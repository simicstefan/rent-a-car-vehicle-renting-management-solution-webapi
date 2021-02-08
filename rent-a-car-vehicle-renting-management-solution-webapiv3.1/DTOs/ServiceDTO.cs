using System;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class ServiceDTO
    {
        public int IDService { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ServicePrice { get; set; }
        public int IDVehicle { get; set; }
    }

    public class ServiceCreateDTO
    {
        public DateTime ServiceDate { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ServicePrice { get; set; }
        public int IDVehicle { get; set; }
    }

    public class ServiceUpdateDTO
    {
        public int IDService { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ServicePrice { get; set; }
        public int IDVehicle { get; set; }
    }
}