using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rent_a_car_vehicle_renting_management_solution_webapi.Contracts;
using rent_a_car_vehicle_renting_management_solution_webapi.Data;
using rent_a_car_vehicle_renting_management_solution_webapi.DTOs;
using rent_a_car_vehicle_renting_management_solution_webapiv3._1.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car_vehicle_renting_management_solution_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationRepository reservationRepository,
            IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all reservations
        /// </summary>
        /// <returns>List of all reservations</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReservations()
        {
            try
            {
                var reservations = await _reservationRepository.FindAll();
                var response = _mapper.Map<IList<ReservationDTO>>(reservations);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows resevation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One reservation</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReservation(int id)
        {
            try
            {
                var reservation = await _reservationRepository.FindById(id);
                if (reservation == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<ReservationDTO>(reservation);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a reservation
        /// </summary>
        /// <param name="reservationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ReservationCreateDTO reservationDTO)
        {
            try
            {
                if (reservationDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var reservation = _mapper.Map<Reservation>(reservationDTO);
                var isSuccess = await _reservationRepository.Create(reservation);
                if (!isSuccess)
                {
                    return InternalError($"Creation failed");
                }
                return Created("Create", new { reservation });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates reservation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reservationDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ReservationUpdateDTO reservationDTO)
        {
            try
            {
                if (id < 1 || reservationDTO == null || id != reservationDTO.IDReservation)
                {
                    return BadRequest();
                }

                var isExists = await _reservationRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var reservation = _mapper.Map<Reservation>(reservationDTO);
                var isSuccess = await _reservationRepository.Update(reservation);
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
        /// Deletes reservation
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

                var isExists = await _reservationRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var reservation = await _reservationRepository.FindById(id);
                var isSuccess = await _reservationRepository.Delete(reservation);
                if (!isSuccess)
                {
                    return InternalError($"Deletion failed");
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
