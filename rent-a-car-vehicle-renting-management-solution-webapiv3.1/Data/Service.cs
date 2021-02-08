using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    [Table("Service")]
    public partial class Service
    {
        [Key]
        public int IDService { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ServicePrice { get; set; }
        public int IDVehicle { get; set; }
    }
}