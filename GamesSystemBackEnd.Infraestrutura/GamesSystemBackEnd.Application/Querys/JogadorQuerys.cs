using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Application.Responses;
using MediatR;

namespace GamesSystemBackEnd.Application.Querys
{
    public class jogadorQueryCheckExists : IRequest<JogadorResponseBooleanStatus>
    {
        public string Email;
    }
    public class JogadorQueryGetJogador : IRequest<JogadorResponseGetJogador>
    {
        public int ID;
        public string Email;
    }

    public class JogadorQueryGetAll : IRequest<JogadorResponseGetAll>
    {
        public bool ativos;
    }
}