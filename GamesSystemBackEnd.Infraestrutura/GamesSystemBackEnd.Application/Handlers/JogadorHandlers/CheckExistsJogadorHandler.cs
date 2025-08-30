using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GamesSystemBackEnd.Application.IServices;
using GamesSystemBackEnd.Application.Querys;
using GamesSystemBackEnd.Application.Responses;
using MediatR;

namespace GamesSystemBackEnd.Application.Handlers.JogadorHandlers
{
    public class CheckExistsJogadorHandler : IRequestHandler<jogadorQueryCheckExists, JogadorResponseBooleanStatus>
    {
        private readonly IServiceJogador _serviceJogador;

        public CheckExistsJogadorHandler(IServiceJogador serviceJogador, IMapper mapper)
        {
            _serviceJogador = serviceJogador;
        }

        public async Task<JogadorResponseBooleanStatus> Handle(jogadorQueryCheckExists request, CancellationToken cancellationToken)
        {
            var exists = await _serviceJogador.ServiceCheckExistsJogadorAsync(request.Email);

            if (exists)
            {
                return new JogadorResponseBooleanStatus(200, exists);
            }

            return new JogadorResponseBooleanStatus(404, false);
        }
    }
}