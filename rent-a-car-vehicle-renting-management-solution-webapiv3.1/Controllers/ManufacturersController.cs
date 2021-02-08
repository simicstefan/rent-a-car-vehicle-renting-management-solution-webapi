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
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public ManufacturersController(IManufacturerRepository manufacturerRepository,
            IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all manufacturers
        /// </summary>
        /// <returns>List of all manufacturers</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetManufacturers()
        {
            try
            {
                var manufacturers = await _manufacturerRepository.FindAll();
                var response = _mapper.Map<IList<ManufacturerDTO>>(manufacturers);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows a manufacturer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One manufacturer</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetManufacturer(int id)
        {
            try
            {
                var manufacturer = await _manufacturerRepository.FindById(id);
                if (manufacturer == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<ManufacturerDTO>(manufacturer);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a manufacturer
        /// </summary>
        /// <param name="manufacturerDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ManufacturerCreateDTO manufacturerDTO)
        {
            try
            {
                if (manufacturerDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var manufacturer = _mapper.Map<Manufacturer>(manufacturerDTO);
                var isSuccess = await _manufacturerRepository.Create(manufacturer);
                if (!isSuccess)
                {
                    return InternalError($"Creation failed");
                }
                return Created("Create", new { manufacturer });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates a manufacturer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="manufacturerDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ManufacturerUpdateDTO manufacturerDTO)
        {
            try
            {
                if (id < 1 || manufacturerDTO == null || id != manufacturerDTO.IDManufacturer)
                {
                    return BadRequest();
                }

                var isExists = await _manufacturerRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var manufacturer = _mapper.Map<Manufacturer>(manufacturerDTO);
                var isSuccess = await _manufacturerRepository.Update(manufacturer);
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
        /// Deletes a manufacturer
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

                var isExists = await _manufacturerRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var manufacturer = await _manufacturerRepository.FindById(id);
                var isSuccess = await _manufacturerRepository.Delete(manufacturer);
                if (!isSuccess)
                {
                    return InternalError($"Delete  failed");
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