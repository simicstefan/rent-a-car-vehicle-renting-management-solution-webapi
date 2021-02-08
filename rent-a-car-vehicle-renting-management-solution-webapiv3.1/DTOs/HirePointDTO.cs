using System;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    public class HirePointDTO
    {
        public int IDHirePoint { get; set; }
        public string HirePointName { get; set; }
        public string Address { get; set; }
        public int IDCity { get; set; }

    }

    public class HirePointCreateDTO
    {
        [Required]
        public string HirePointName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int IDCity { get; set; }

    }

    public class HirePointUpdateDTO
    {
        [Required]
        public int IDHirePoint { get; set; }
        [Required]
        public string HirePointName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int IDCity { get; set; }

    }


}