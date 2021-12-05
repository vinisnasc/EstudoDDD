using EstudoDDD.Domain.DTO.Municipio;
using EstudoDDD.Domain.Interfaces.Services.Municipio;
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
    public class MunicipiosController : ControllerBase
    {
        private IMunicipioService _service;

        public MunicipiosController(IMunicipioService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetAll());
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetMunicipioWithId")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Get(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{idMunicipio}")]
        public async Task<IActionResult> GetCompleteById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.GetCompleteById(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{ibgeMunicipio}")]
        public async Task<IActionResult> GetCompleteByIBGE(int ibge)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.GetCompleteByIBGE(ibge);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MunicipioDtoCreate municipio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Post(municipio);
                if (result != null)
                    return Created(new Uri(Url.Link("GetMunicipiowithId", new { id = result.Id })), result);

                else
                    return BadRequest();
            }
            catch(Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] MunicipioDtoUpdate municipio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Put(municipio);
                if (result != null)
                    return Ok(result);

                else
                    return BadRequest();
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
