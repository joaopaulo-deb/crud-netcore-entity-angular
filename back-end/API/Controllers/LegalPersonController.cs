using System;
using Application.interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LegalPersonController : ControllerBase
    {
        private readonly ILegalPersonService _legalPersonService;

        public LegalPersonController(ILegalPersonService legalPersonService)
        {
            _legalPersonService = legalPersonService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var legalPersons = _legalPersonService.GetAllLegalPersons();
                if (legalPersons == null) return NotFound("Not found");

                return Ok(legalPersons);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var legalPerson = _legalPersonService.GetLegalPersonById(id);
                if (legalPerson == null) return NotFound("Not found");

                return Ok(legalPerson);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post(LegalPerson legalPerson)
        {
            try
            {
                var newLegalPerson = _legalPersonService.AddLegalPerson(legalPerson);
                if (newLegalPerson == null) return BadRequest("Error");

                return Ok(newLegalPerson);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }
        }

         [HttpPut("{id}")]
        public IActionResult Put(int id, LegalPerson legalPerson)
        {
            try
            {
                var newLegalPerson = _legalPersonService.UpdateLegalPerson(id, legalPerson);
                if (newLegalPerson == null) return BadRequest("Error");

                return Ok(newLegalPerson);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return _legalPersonService.DeleteLegalPerson(id) ?
                        Ok("Deleted") :
                        BadRequest("Error");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }
        }
    }
}
