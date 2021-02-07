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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository countryRepository,
            IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all countries
        /// </summary>
        /// <returns>List of all countries</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _countryRepository.FindAll();
                var response = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows a country by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One country</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _countryRepository.FindById(id);
                if (country == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<CountryDTO>(country);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a country
        /// </summary>
        /// <param name="countryDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CountryCreateDTO countryDTO)
        {
            try
            {
                if (countryDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var country = _mapper.Map<Country>(countryDTO);
                var isSuccess = await _countryRepository.Create(country);
                if (!isSuccess)
                {
                    return InternalError($"Creation failed");
                }
                return Created("Create", new { country });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates a country
        /// </summary>
        /// <param name="id"></param>
        /// <param name="countryDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] CountryUpdateDTO countryDTO)
        {
            try
            {
                if (id < 1 || countryDTO == null || id != countryDTO.IDCountry)
                {
                    return BadRequest();
                }

                var isExists = await _countryRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var country = _mapper.Map<Country>(countryDTO);
                var isSuccess = await _countryRepository.Update(country);
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
        /// Deletes a country
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

                var isExists = await _countryRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var country = await _countryRepository.FindById(id);
                var isSuccess = await _countryRepository.Delete(country);
                if (!isSuccess)
                {
                    return InternalError($"Delete operation failed");
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
