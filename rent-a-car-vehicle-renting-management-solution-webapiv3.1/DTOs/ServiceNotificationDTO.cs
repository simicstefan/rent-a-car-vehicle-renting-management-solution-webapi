using System;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class ServiceNotificationDTO
    {
        public int IDServiceNotification { get; set; }
        public int IDVehicle { get; set; }
        public string NotificationText { get; set; }
        public DateTime NotificationDate { get; set; }
        public int NotificationKm { get; set; }
        public int NotificationSeen { get; set; }
    }

    public class ServiceNotificationCreateDTO
    {
        [Required]
        public int IDVehicle { get; set; }
        [Required]
        public string NotificationText { get; set; }
        public DateTime NotificationDate { get; set; }
        public int NotificationKm { get; set; }
        public int NotificationSeen { get; set; }
    }

    public class ServiceNotificationUpdateDTO
    {
        [Required]
        public int IDServiceNotification { get; set; }
        [Required]
        public int IDVehicle { get; set; }
        [Required]
        public string NotificationText { get; set; }
        public DateTime NotificationDate { get; set; }
        public int NotificationKm { get; set; }
        public int NotificationSeen { get; set; }
    }
}