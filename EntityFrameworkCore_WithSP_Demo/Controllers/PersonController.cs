using EntityFrameworkCore_WithSP_Demo.Entities;
using EntityFrameworkCore_WithSP_Demo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EntityFrameworkCore_WithSP_Demo.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService _personService)
        {
            this.personService = _personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonListAsync()
        {
            try
            {
                var personList = await this.personService.GetPersonListAsync();
                return Ok(personList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{idPerson:int}")]
        public async Task<IActionResult> GetPersonByIdAsync(int idPerson)
        {
            try
            {
                var person = await this.personService.GetPersonByIdAsync(idPerson);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonAsync(Person model)
        {
            try
            {
                if (model != null)
                {
                    var response = await this.personService.AddPersonAsync(model);
                    if (!string.IsNullOrEmpty(response))
                    {
                        return BadRequest(response);
                    }
                    else
                    {
                        return Ok(model);
                    }
                }
                else
                {
                    return BadRequest("El objeto no puede ser nulo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonAsync(Person model)
        {
            try
            {
                if (model != null)
                {
                    var response = await this.personService.UpdatePersonAsync(model);
                    if (!string.IsNullOrEmpty(response))
                    {
                        return BadRequest(response);
                    }
                    else
                    {
                        return Ok(model);
                    }
                }
                else
                {
                    return BadRequest("El objeto no puede ser nulo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{personId:int}")]
        public async Task<IActionResult> DeletePersonAsync(int personId)
        {
            try
            {
                var response = await this.personService.DeletePersonAsync(personId);
                if (!string.IsNullOrEmpty(response))
                {
                    return BadRequest(response);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
