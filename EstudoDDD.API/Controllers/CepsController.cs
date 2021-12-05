using EstudoDDD.Domain.DTO.CEP;
using EstudoDDD.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EstudoDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepsController : ControllerBase
    {
        private ICepService _service;
        public CepsController(ICepService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetCepWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Get(id);
                if (result == null)
                    return NotFound();

                else
                    return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("byCep/{cep}")]
        public async Task<ActionResult> GetByCep(string cep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Get(cep);
                if (result == null)
                    return NotFound();

                else
                    return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CepDtoCreate cep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Post(cep);
                if (result == null)
                    return BadRequest();

                else
                    return Created(new Uri(Url.Link("GetCepWithId", new { id = result.Id })), result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CepDtoUpdate cep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Put(cep);
                if (result == null)
                    return BadRequest();

                else
                    return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}