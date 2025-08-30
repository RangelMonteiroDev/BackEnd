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
    public class CreateJogadorHandler : IRequestHandler<JogadorCommandCreate, JogadorResponseCreate>
    {
        private readonly IServiceJogador _serviceJogador;
        private readonly IMapper _mapper;

        public CreateJogadorHandler(IServiceJogador serviceJogador, IMapper mapper)
        {
            _serviceJogador = serviceJogador;
            _mapper = mapper; 
        }
        public async Task<JogadorResponseCreate> Handle(JogadorCommandCreate request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<JogadoresDTO>(request);
            var ID = await _serviceJogador.ServiceCreateJogadorAsync(data);

            if (ID > 0)
            {
                return new JogadorResponseCreate(200, ID);
            }
            
            return new JogadorResponseCreate(500, ID);
        }
    }
}