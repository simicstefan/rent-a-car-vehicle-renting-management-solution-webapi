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
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;

        public DocumentsController(IDocumentRepository documentRepository,
            IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        private ObjectResult InternalError(string message)
        {
            return StatusCode(500, "Something went wrong. Please contact the administrator");
        }

        /// <summary>
        /// Shows all documents
        /// </summary>
        /// <returns>List of all documents</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocuments()
        {
            try
            {
                var documents = await _documentRepository.FindAll();
                var response = _mapper.Map<IList<DocumentDTO>>(documents);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Shows a document by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One document</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocument(int id)
        {
            try
            {
                var document = await _documentRepository.FindById(id);
                if (document == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<DocumentDTO>(document);
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a document
        /// </summary>
        /// <param name="documentDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] DocumentCreateDTO documentDTO)
        {
            try
            {
                if (documentDTO == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var document = _mapper.Map<Document>(documentDTO);
                var isSuccess = await _documentRepository.Create(document);
                if (!isSuccess)
                {
                    return InternalError($"Creation failed");
                }
                return Created("Create", new { document });
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Updates a document
        /// </summary>
        /// <param name="id"></param>
        /// <param name="documentDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] DocumentUpdateDTO documentDTO)
        {
            try
            {
                if (id < 1 || documentDTO == null || id != documentDTO.IDDocument)
                {
                    return BadRequest();
                }

                var isExists = await _documentRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var document = _mapper.Map<Document>(documentDTO);
                var isSuccess = await _documentRepository.Update(document);
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
        /// Deletes a document
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

                var isExists = await _documentRepository.isExists(id);
                if (!isExists)
                {
                    return NotFound();
                }

                var document = await _documentRepository.FindById(id);
                var isSuccess = await _documentRepository.Delete(document);
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
