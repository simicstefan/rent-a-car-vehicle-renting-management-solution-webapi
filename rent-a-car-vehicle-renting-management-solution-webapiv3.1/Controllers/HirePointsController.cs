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
    public class HirePointsController : ControllerBase
    {
        private readonly IHirePointRepository _hirePointRepository;
        private readonly IMapper _mapper;

        public HirePointsController(IHirePointRepository hirePointRepository,
            IMapper mapper)
        {
            _hirePointRepository = hirePointRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all hire points
        /// </summary>
        /// <returns>List of all hire points</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHirePoints()
        {
            try
            {
                var hirepoints = await _hirePointRepository.FindAll();
                var response = _mapper.Map<IList<HirePointDTO>>(hirepoints);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows hire point by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One hire point</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHirePoint(int id)
        {
            try
            {
                var hirepoint = await _hirePointRepository.FindById(id);
                if (hirepoint == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<HirePointDTO>(hirepoint);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates hire point
        /// </summary>
        /// <param name="hirePointDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] HirePointCreateDTO hirePointDTO)
        {
            try
            {
                if (hirePointDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var hirepoint = _mapper.Map<HirePoint>(hirePointDTO);
                var isSuccess = await _hirePointRepository.Create(hirepoint);
                if (!isSuccess)
                {
                    return InternalError($"Creation failed");
                }
                return Created("Create", new { hirepoint });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates hire point
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hirePointDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] HirePointUpdateDTO hirePointDTO)
        {
            try
            {
                if (id < 1 || hirePointDTO == null || id != hirePointDTO.IDHirePoint)
                {
                    return BadRequest();
                }

                var isExists = await _hirePointRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var hirepoint = _mapper.Map<HirePoint>(hirePointDTO);
                var isSuccess = await _hirePointRepository.Update(hirepoint);
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
        /// Deletes hire point
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

                var isExists = await _hirePointRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var hirepoint = await _hirePointRepository.FindById(id);
                var isSuccess = await _hirePointRepository.Delete(hirepoint);
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