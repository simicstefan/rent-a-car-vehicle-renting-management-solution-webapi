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
        }
    }
}
