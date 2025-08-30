using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GamesSystemBackEnd.Application.Commands;
using GamesSystemBackEnd.Application.DTOs;
using GamesSystemBackEnd.Application.IServices;
using GamesSystemBackEnd.Application.Responses;
using MediatR;

namespace GamesSystemBackEnd.Application.Handlers.JogadorHandlers
{ 
    public class UpdateJogadorHandler : IRequestHandler<JogadorCommandUpdate,JogadorResponseBooleanStatus>
    {
        private readonly IServiceJogador _serviceJogador;
        private readonly IMapper _mapper;

        public UpdateJogadorHandler(IServiceJogador serviceJogador, IMapper mapper)
        {
            _serviceJogador = serviceJogador;
            _mapper = mapper;
        }

        public async Task<JogadorResponseBooleanStatus> Handle(JogadorCommandUpdate request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<JogadoresDTO>(request);
            var updates = await _serviceJogador.ServiceUpdateJogadorAsync(data);

            if (updates)
            {
                return new JogadorResponseBooleanStatus(200, updates);
            }

            return new JogadorResponseBooleanStatus(404, false);
        }
    }
}