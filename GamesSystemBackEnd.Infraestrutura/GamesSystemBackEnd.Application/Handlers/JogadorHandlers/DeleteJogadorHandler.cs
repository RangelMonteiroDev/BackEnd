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
    public class DeleteJogadorHandler : IRequestHandler<JogadorCommandDelete, JogadorResponseBooleanStatus>
    {
        private readonly IServiceJogador _serviceJogador;

        public DeleteJogadorHandler(IServiceJogador serviceJogador)
        {
            _serviceJogador = serviceJogador;
        }
        public async Task<JogadorResponseBooleanStatus> Handle(JogadorCommandDelete request, CancellationToken cancellationToken)
        {
            var deletes = await _serviceJogador.ServiceDeleteJogadorAsync(request.ID);

            if (deletes)
            {
                return new JogadorResponseBooleanStatus(200, deletes);
            }
            return new JogadorResponseBooleanStatus(500, false);
        }
    }
}