using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Application.Commands;
using GamesSystemBackEnd.Application.DTOs;
using GamesSystemBackEnd.Application.Handlers.JogadorHandlers;
using GamesSystemBackEnd.Application.Querys;
using GamesSystemBackEnd.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GamesSystemBackEnd.API.Controllers
{

    [ApiController]
    [Route("api/jogadores")]
    public class JogadorController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public JogadorController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }


        [HttpPost]
        public async Task<ActionResult<JogadorResponseCreate>>
        CreateJogador([FromBody] JogadorCommandCreate commandCreate, CancellationToken cancellationToken)
        {
            var response = await _mediatR.Send(commandCreate);

            if (response.ID == 0)
            {
                return BadRequest(new { response.ID, response.HTTPStatusCode });
            }

            return Ok(new { response.ID, response.HTTPStatusCode });
        }

        [HttpGet]
        public async Task<ActionResult<JogadorResponseBooleanStatus>>
        CheckExistsJogadorByID([FromBody] jogadorQueryCheckExists query, CancellationToken cancellationToken)
        {
            var response = await _mediatR.Send(query);

            var exists = response.BooleanStatus;

            if (exists)
            {
                return Ok(new { response.HTTPStatusCode, response.BooleanStatus });
            }

            return NotFound(new { response.HTTPStatusCode, response.BooleanStatus });
        }

        [HttpGet]
        public async Task<ActionResult<JogadorResponseGetJogador>>
        GetJogadorAsync([FromBody] JogadorQueryGetJogador query, CancellationToken cancellationToken)
        {
            var response = await _mediatR.Send(query);

            if (response.HTTPStatusCode == 200)
            {
                return Ok(new { response.HTTPStatusCode, response.jogadorDTO });
            }

            return NotFound(new { response.HTTPStatusCode, response.jogadorDTO.NotFound });
        }

        [HttpGet]
        public async Task<ActionResult<JogadorResponseGetAll>>
        GetAllJogadorAsync([FromBody] JogadorQueryGetAll query, CancellationToken cancellationToken)
        {
            var response = await _mediatR.Send(query);

            if (response.HTTPStatusCode == 404)
            {
                return NotFound(new { response.HTTPStatusCode });
            }

            return Ok(new { response.HTTPStatusCode, response.jogadorLIST });
        }

        [HttpPut]
        public async Task<ActionResult<JogadorResponseBooleanStatus>>
        JogadorUpdateAsync([FromBody] JogadorCommandUpdate commandUpdate, CancellationToken cancellationToken)
        {
            var response = await _mediatR.Send(commandUpdate);

            var updates = response.BooleanStatus;

            if (updates)
            {
                return Ok(new { response.HTTPStatusCode, response.BooleanStatus });
            }

            return BadRequest(new { response.HTTPStatusCode, response.BooleanStatus });
        }

        [HttpPut]
        public async Task<ActionResult<JogadorResponseBooleanStatus>>
        JogadorUpdatePasswordAsync([FromBody] JogadorCommandUpdatePassword commandUpdate, CancellationToken cancellationToken)
        {
            var response = await _mediatR.Send(commandUpdate);

            var updates = response.BooleanStatus;

            if (updates)
            {
                return Ok(new { response.HTTPStatusCode, response.BooleanStatus });
            }

            return BadRequest(new { response.HTTPStatusCode, response.BooleanStatus });
        }

        [HttpDelete]
        public async Task<ActionResult<JogadorResponseBooleanStatus>>
        JogadorDeleteAsync([FromBody] JogadorCommandDelete commandDelete, CancellationToken cancellationToken)
        {
            var response = await _mediatR.Send(commandDelete);

            var deletes = response.BooleanStatus;

            if (deletes)
            {
                return Ok(new { response.HTTPStatusCode, response.BooleanStatus });
            }

            return BadRequest(new {response.HTTPStatusCode, response.BooleanStatus});
        }
    }
}