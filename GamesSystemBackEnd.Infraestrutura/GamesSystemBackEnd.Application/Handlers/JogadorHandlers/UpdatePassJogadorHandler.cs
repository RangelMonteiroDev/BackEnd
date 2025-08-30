using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Application.Commands;
using GamesSystemBackEnd.Application.IServices;
using GamesSystemBackEnd.Application.Responses;
using MediatR;

namespace GamesSystemBackEnd.Application.Handlers.JogadorHandlers
{
    public class UpdatePassJogadorHandler : IRequestHandler<JogadorCommandUpdatePassword, JogadorResponseBooleanStatus>
    {
        private readonly IServiceJogador _serviceJogador;
        
        public UpdatePassJogadorHandler(IServiceJogador serviceJogador)
        {
            _serviceJogador = serviceJogador;
        }
        public async Task<JogadorResponseBooleanStatus> Handle(JogadorCommandUpdatePassword request, CancellationToken cancellationToken)
        {
            var updates = await _serviceJogador.ServiceUpdatePassJogadorAsync(request.ID, request.NovaSenha);

            if (updates)
            {
                return new JogadorResponseBooleanStatus(200, updates);
            }
            
            return new JogadorResponseBooleanStatus(404, false);
        }
    }
}