using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GamesSystemBackEnd.Application.Commands;
using GamesSystemBackEnd.Application.DTOs;
using GamesSystemBackEnd.Application.Querys;
using GamesSystemBackEnd.Application.Responses;
using GamesSystemBackEnd.Domain.Entitys;

namespace GamesSystemBackEnd.Application.AutoMapping
{
    public class AutoMappingJogador : Profile
    {
        public AutoMappingJogador()
        {
            CreateMap<Jogadores, JogadoresDTO>();
            CreateMap<JogadoresDTO, Jogadores>();
            CreateMap<List<Jogadores>, List<JogadoresDTO>>();
            CreateMap<JogadorCommandCreate, JogadoresDTO>();
            CreateMap<JogadorCommandUpdate, JogadoresDTO>();
        }
    }
}