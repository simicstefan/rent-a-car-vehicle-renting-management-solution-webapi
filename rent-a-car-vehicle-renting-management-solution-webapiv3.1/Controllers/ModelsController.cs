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
    public class ModelsController : ControllerBase
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public ModelsController(IModelRepository modelRepository,
            IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all models
        /// </summary>
        /// <returns>List of all models</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetModels()
        {
            try
            {
                var models = await _modelRepository.FindAll();
                var response = _mapper.Map<IList<ModelDTO>>(models);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows a model by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One model</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetModel(int id)
        {
            try
            {
                var model = await _modelRepository.FindById(id);
                if (model == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<ModelDTO>(model);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a model
        /// </summary>
        /// <param name="modelDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ModelCreateDTO modelDTO)
        {
            try
            {
                if (modelDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var model = _mapper.Map<Model>(modelDTO);
                var isSuccess = await _modelRepository.Create(model);
                if (!isSuccess)
                {
                    return InternalError($"Creation failed");
                }
                return Created("Create", new { model });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates a model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modelDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ModelUpdateDTO modelDTO)
        {
            try
            {
                if (id < 1 || modelDTO == null || id != modelDTO.IDModel)
                {
                    return BadRequest();
                }

                var isExists = await _modelRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var model = _mapper.Map<Model>(modelDTO);
                var isSuccess = await _modelRepository.Update(model);
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
        /// Deletes a model
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

                var isExists = await _modelRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var model = await _modelRepository.FindById(id);
                var isSuccess = await _modelRepository.Delete(model);
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
