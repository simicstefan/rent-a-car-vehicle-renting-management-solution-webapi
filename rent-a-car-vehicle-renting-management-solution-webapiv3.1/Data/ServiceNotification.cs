using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    [Table("ServiceNotification")]
    public partial class ServiceNotification
    {
        [Key]
        public int IDServiceNotification { get; set; }
        public int IDVehicle { get; set; }
        public string NotificationText { get; set; }
        public DateTime NotificationDate { get; set; }
        public int NotificationKm { get; set; }
        public int NotificationSeen { get; set; }
    }
}