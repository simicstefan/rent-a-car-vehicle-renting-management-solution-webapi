using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehiclesController(IVehicleRepository vehicleRepository,
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all vehicles
        /// </summary>
        /// <returns>List of all vehicles</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVehicles()
        {
            try
            {
                var vehicles = await _vehicleRepository.FindAll();
                var response = _mapper.Map<IList<VehicleDTO>>(vehicles);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows a vehicle by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One vehicle</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVehicle(int id)
        {
            try
            {
                var vehicle = await _vehicleRepository.FindById(id);
                if (vehicle == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<VehicleDTO>(vehicle);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a vehicle
        /// </summary>
        /// <param name="vehicleDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] VehicleCreateDTO vehicleDTO)
        {
            try
            {
                if (vehicleDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var vehicle = _mapper.Map<Vehicle>(vehicleDTO);
                var isSuccess = await _vehicleRepository.Create(vehicle);
                if(!isSuccess)
                {
                    return InternalError($"Creation failed");
                }
                return Created("Create", new { vehicle });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates a vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehicleDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] VehicleUpdateDTO vehicleDTO)
        {
            try
            {
                if (id < 1 || vehicleDTO == null || id != vehicleDTO.IDVehicle)
                {
                    return BadRequest();
                }

                var isExists = await _vehicleRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var vehicle = _mapper.Map<Vehicle>(vehicleDTO);
                var isSuccess = await _vehicleRepository.Update(vehicle);
                if (!isSuccess)
                {
                    return InternalError($"Update failed.");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Deletes a vehicle
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

                var isExists = await _vehicleRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var vehicle = await _vehicleRepository.FindById(id);
                var isSuccess = await _vehicleRepository.Delete(vehicle);
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
    }}