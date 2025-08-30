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
    public class GetJogadorHandler : IRequestHandler<JogadorQueryGetJogador, JogadorResponseGetJogador>
    {
        private readonly IServiceJogador _serviceJogador;
        public async Task<JogadorResponseGetJogador> Handle(JogadorQueryGetJogador request, CancellationToken cancellationToken)
        {
            var results = await _serviceJogador.ServiceGetJogadorAsync(request.ID, request.Email);

            if (results.NotFound)
            {
                return new JogadorResponseGetJogador(404, results);
            }

            return new JogadorResponseGetJogador( 200, results);
        }
    }
}