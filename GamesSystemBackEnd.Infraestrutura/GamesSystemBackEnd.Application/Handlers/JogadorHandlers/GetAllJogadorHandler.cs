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
    public class GetAllJogadorHandler : IRequestHandler<JogadorQueryGetAll, JogadorResponseGetAll>
    {
        private readonly IServiceJogador _serviceJogador;

        public GetAllJogadorHandler(IServiceJogador serviceJogador)
        {
            _serviceJogador = serviceJogador;
        }

        public async Task<JogadorResponseGetAll> Handle(JogadorQueryGetAll request, CancellationToken cancellationToken)
        {
            var result = await _serviceJogador.ServiceGetAllJogadorAsync(request.ativos);

            return new JogadorResponseGetAll(200, result);
        }
    }
}