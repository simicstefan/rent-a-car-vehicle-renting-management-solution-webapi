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
    public class PickupsController : ControllerBase
    {
        private readonly IPickupRepository _pickupRepository;
        private readonly IMapper _mapper;

        public PickupsController(IPickupRepository pickupRepository,
            IMapper mapper)
        {
            _pickupRepository = pickupRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all pickups
        /// </summary>
        /// <returns>List of all pickups</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPickups()
        {
            try
            {
                var pickups = await _pickupRepository.FindAll();
                var response = _mapper.Map<IList<PickupDTO>>(pickups);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows a pickup by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One pickup</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPickup(int id)
        {
            try
            {
                var pickup = await _pickupRepository.FindById(id);
                if (pickup == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<PickupDTO>(pickup);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a pickup
        /// </summary>
        /// <param name="pickupDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] PickupCreateDTO pickupDTO)
        {
            try
            {
                if (pickupDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var pickup = _mapper.Map<Pickup>(pickupDTO);
                var isSuccess = await _pickupRepository.Create(pickup);
                if(!isSuccess)
                {
                    return InternalError($"Creation failed");
                }
                return Created("Create", new { pickup });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates a pickup
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pickupDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] PickupUpdateDTO pickupDTO)
        {
            try
            {
                if (id < 1 || pickupDTO == null || id != pickupDTO.IDPickup)
                {
                    return BadRequest();
                }

                var isExists = await _pickupRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var pickup = _mapper.Map<Pickup>(pickupDTO);
                var isSuccess = await _pickupRepository.Update(pickup);
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
        /// Deletes a pickup
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

                var isExists = await _pickupRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var pickup = await _pickupRepository.FindById(id);
                var isSuccess = await _pickupRepository.Delete(pickup);
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