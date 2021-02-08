using rent_a_car_vehicle_renting_management_solution_webapi.Data;
using rent_a_car_vehicle_renting_management_solution_webapi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.Data;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.DTOs;

namespace rent_a_car_vehicle_renting_management_solution_webapi.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Client, ClientCreateDTO>().ReverseMap();
            CreateMap<Client, ClientUpdateDTO>().ReverseMap();
            
            CreateMap<Reservation, ReservationDTO>().ReverseMap();
            CreateMap<Reservation, ReservationCreateDTO>().ReverseMap();
            CreateMap<Reservation, ReservationUpdateDTO>().ReverseMap();
            
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<City, CityCreateDTO>().ReverseMap();
            CreateMap<City, CityUpdateDTO>().ReverseMap();
            
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CountryCreateDTO>().ReverseMap();
            CreateMap<Country, CountryUpdateDTO>().ReverseMap();
            
            CreateMap<Document, DocumentDTO>().ReverseMap();
            CreateMap<Document, DocumentCreateDTO>().ReverseMap();
            CreateMap<Document, DocumentUpdateDTO>().ReverseMap();

            CreateMap<HirePoint, HirePointDTO>().ReverseMap();
            CreateMap<HirePoint, HirePointCreateDTO>().ReverseMap();
            CreateMap<HirePoint, HirePointUpdateDTO>().ReverseMap();

            CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerCreateDTO>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerUpdateDTO>().ReverseMap();

            CreateMap<Model, ModelDTO>().ReverseMap();
            CreateMap<Model, ModelCreateDTO>().ReverseMap();
            CreateMap<Model, ModelUpdateDTO>().ReverseMap();
            
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<Service, ServiceCreateDTO>().ReverseMap();
            CreateMap<Service, ServiceUpdateDTO>().ReverseMap();

            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleCreateDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleUpdateDTO>().ReverseMap();

            CreateMap<Pickup, PickupDTO>().ReverseMap();
            CreateMap<Pickup, PickupCreateDTO>().ReverseMap();
            CreateMap<Pickup, PickupUpdateDTO>().ReverseMap(); 
            
            CreateMap<Transmission, TransmissionDTO>().ReverseMap();
            CreateMap<Transmission, TransmissionCreateDTO>().ReverseMap();
            CreateMap<Transmission, TransmissionUpdateDTO>().ReverseMap();

            CreateMap<ServiceNotification, ServiceNotificationDTO>().ReverseMap();
            CreateMap<ServiceNotification, ServiceNotificationCreateDTO>().ReverseMap();
            CreateMap<ServiceNotification, ServiceNotificationUpdateDTO>().ReverseMap();
        }
    }
}
