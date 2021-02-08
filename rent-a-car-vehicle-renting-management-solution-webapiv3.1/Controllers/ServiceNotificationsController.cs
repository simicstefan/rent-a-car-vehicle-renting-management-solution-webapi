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
    public class ServiceNotificationsController : ControllerBase
    {
        private readonly IServiceNotificationRepository _serviceNotificationRepository;
        private readonly IMapper _mapper;

        public ServiceNotificationsController(IServiceNotificationRepository serviceNotificationRepository,
            IMapper mapper)
        {
            _serviceNotificationRepository = serviceNotificationRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all service notifications
        /// </summary>
        /// <returns>List of all service notifications</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetServiceNotifications()
        {
            try
            {
                var serviceNotifications = await _serviceNotificationRepository.FindAll();
                var response = _mapper.Map<IList<ServiceNotificationDTO>>(serviceNotifications);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows a service notification by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One service notification</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetServiceNotification(int id)
        {
            try
            {
                var serviceNotification = await _serviceNotificationRepository.FindById(id);
                if (serviceNotification == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<ServiceNotificationDTO>(serviceNotification);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a service notification
        /// </summary>
        /// <param name="serviceNotificationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ServiceNotificationCreateDTO serviceNotificationDTO)
        {
            try
            {
                if (serviceNotificationDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var serviceNotification = _mapper.Map<ServiceNotification>(serviceNotificationDTO);
                var isSuccess = await _serviceNotificationRepository.Create(serviceNotification);
                if (!isSuccess)
                {
                    return InternalError($"Creation failed");
                }
                return Created("Create", new { serviceNotification });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates a service notification
        /// </summary>
        /// <param name="id"></param>
        /// <param name="serviceNotificationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceNotificationUpdateDTO serviceNotificationDTO)
        {
            try
            {
                if (id < 1 || serviceNotificationDTO == null || id != serviceNotificationDTO.IDServiceNotification)
                {
                    return BadRequest();
                }

                var isExists = await _serviceNotificationRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var serviceNotification = _mapper.Map<ServiceNotification>(serviceNotificationDTO);
                var isSuccess = await _serviceNotificationRepository.Update(serviceNotification);
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
        /// Deletes a service notification
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

                var isExists = await _serviceNotificationRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var serviceNotification = await _serviceNotificationRepository.FindById(id);
                var isSuccess = await _serviceNotificationRepository.Delete(serviceNotification);
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