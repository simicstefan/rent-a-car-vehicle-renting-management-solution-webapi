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

namespace rent_a_car_vehicle_renting_management_solution_webapiv3._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepository clientRepository,
            IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all clients
        /// </summary>
        /// <returns>List of all clients</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var clients = await _clientRepository.FindAll();
                var response = _mapper.Map<IList<ClientDTO>>(clients);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows a client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One client</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClient(int id)
        {
            try
            {
                var author = await _clientRepository.FindById(id);
                if (author == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<ClientDTO>(author);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a client
        /// </summary>
        /// <param name="clientDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ClientCreateDTO clientDTO)
        {
            try
            {
                if (clientDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var client = _mapper.Map<Client>(clientDTO);
                var isSuccess = await _clientRepository.Create(client);
                if(!isSuccess)
                {
                    return InternalError($"Client creation failed");
                }
                return Created("Create", new { client });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clientDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ClientUpdateDTO clientDTO)
        {
            try
            {
                if (id < 1 || clientDTO == null || id != clientDTO.IDClient)
                {
                    return BadRequest();
                }

                var isExists = await _clientRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var client = _mapper.Map<Client>(clientDTO);
                var isSuccess = await _clientRepository.Update(client);
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
        /// Deletes a client
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

                var isExists = await _clientRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var client = await _clientRepository.FindById(id);
                var isSuccess = await _clientRepository.Delete(client);
                if (!isSuccess)
                {
                    return InternalError($"Author delete failed");
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
