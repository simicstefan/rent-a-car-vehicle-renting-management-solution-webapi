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
    public class TransmissionsController : ControllerBase
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public TransmissionsController(ITransmissionRepository transmissionRepository,
            IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all transmissions
        /// </summary>
        /// <returns>List of all transmissions</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTransmissions()
        {
            try
            {
                var transmissions = await _transmissionRepository.FindAll();
                var response = _mapper.Map<IList<TransmissionDTO>>(transmissions);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows a transmission by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One transmission</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTransmission(int id)
        {
            try
            {
                var transmission = await _transmissionRepository.FindById(id);
                if (transmission == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<TransmissionDTO>(transmission);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a transmission
        /// </summary>
        /// <param name="transmissionDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] TransmissionCreateDTO transmissionDTO)
        {
            try
            {
                if (transmissionDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var transmission = _mapper.Map<Transmission>(transmissionDTO);
                var isSuccess = await _transmissionRepository.Create(transmission);
                if(!isSuccess)
                {
                    return InternalError($"Creation failed");
                }
                return Created("Create", new { transmission });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates a transmission
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transmissionDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] TransmissionUpdateDTO transmissionDTO)
        {
            try
            {
                if (id < 1 || transmissionDTO == null || id != transmissionDTO.IDTransmission)
                {
                    return BadRequest();
                }

                var isExists = await _transmissionRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var transmission = _mapper.Map<Transmission>(transmissionDTO);
                var isSuccess = await _transmissionRepository.Update(transmission);
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
        /// Deletes a transmission
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

                var isExists = await _transmissionRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var transmission = await _transmissionRepository.FindById(id);
                var isSuccess = await _transmissionRepository.Delete(transmission);
                if (!isSuccess)
                {
                    return InternalError($"Delete failed");
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