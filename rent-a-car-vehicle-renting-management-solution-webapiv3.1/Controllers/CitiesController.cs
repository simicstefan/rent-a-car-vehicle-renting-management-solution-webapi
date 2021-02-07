using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rent_a_car_vehicle_renting_management_solution_webapi.Contracts;
using rent_a_car_vehicle_renting_management_solution_webapi.Data;
using rent_a_car_vehicle_renting_management_solution_webapi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityRepository cityRepository,
            IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all cities
        /// </summary>
        /// <returns>List of all clients</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                var cities = await _cityRepository.FindAll();
                var response = _mapper.Map<IList<CityDTO>>(cities);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows a city by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One client</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCity(int id)
        {
            try
            {
                var city = await _cityRepository.FindById(id);
                if (city == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<CityDTO>(city);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a city
        /// </summary>
        /// <param name="cityDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CityCreateDTO cityDTO)
        {
            try
            {
                if (cityDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var city = _mapper.Map<City>(cityDTO);
                var isSuccess = await _cityRepository.Create(city);
                if (!isSuccess)
                {
                    return InternalError($"City creation failed");
                }
                return Created("Create", new { city });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates a city
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cityDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] CityUpdateDTO cityDTO)
        {
            try
            {
                if (id < 1 || cityDTO == null || id != cityDTO.IDCity)
                {
                    return BadRequest();
                }

                var isExists = await _cityRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var city = _mapper.Map<City>(cityDTO);
                var isSuccess = await _cityRepository.Update(city);
                if (!isSuccess)
                {
                    return InternalError($"Update operation failed.");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Deletes a city
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }

                var isExists = await _cityRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var city = await _cityRepository.FindById(id);
                var isSuccess = await _cityRepository.Delete(city);
                if (!isSuccess)
                {
                    return InternalError($"City delete failed");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }
    }
}
