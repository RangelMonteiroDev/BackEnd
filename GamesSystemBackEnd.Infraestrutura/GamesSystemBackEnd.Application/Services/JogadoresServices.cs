using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GamesSystemBackEnd.Application.DTOs;
using GamesSystemBackEnd.Application.IServices;
using GamesSystemBackEnd.Domain.Entitys;
using GamesSystemBackEnd.Domain.UseCases;
using GamesSystemBackEnd.Domain.UseCases.IUseCases;

namespace GamesSystemBackEnd.Application.Services
{
    public class JogadoresServices : IServiceJogador
    {
        private readonly IJogadorUseCase _jogadorUseCase;
        private readonly IMapper _mapper;

        public JogadoresServices(IJogadorUseCase jogadorUseCase, IMapper mapper)
        {
            _jogadorUseCase = jogadorUseCase;
            _mapper = mapper;
        }

        public async Task<int> ServiceCreateJogadorAsync(JogadoresDTO jogadorDTO)
        {
            var jogador = _mapper.Map<Jogadores>(jogadorDTO);
            return await _jogadorUseCase.CreateNewJogadorAsync(jogador);
        }

        public async Task<bool> ServiceCheckExistsJogadorAsync(string Email)
        {
            return await _jogadorUseCase.GetCheckExistAsync(Email);
        }

        public async Task<JogadoresDTO> ServiceGetJogadorAsync(int ID, string Email)
        {
            var jogador = await _jogadorUseCase.GetJogadorAsync(ID, Email);
            return _mapper.Map<JogadoresDTO>(jogador);
        }

        public async Task<List<JogadoresDTO>> ServiceGetAllJogadorAsync(bool ativos)
        {
            var jogadores = await _jogadorUseCase.GetAllJogadoresAsync(ativos);
            return _mapper.Map<List<JogadoresDTO>>(jogadores);
        }

        public async Task<bool> ServiceUpdateJogadorAsync(JogadoresDTO jogadoresDTO)
        {
            var jogador = _mapper.Map<Jogadores>(jogadoresDTO);
            return await _jogadorUseCase.UpdateAsync(jogador);
        }

        public async Task<bool> ServiceUpdatePassJogadorAsync(int ID, string NovaSenha)
        {
            return await _jogadorUseCase.UpdatePassAsync(ID, NovaSenha);
        }

        public async Task<bool> ServiceDeleteJogadorAsync(int ID)
        {
            return await _jogadorUseCase.DeleteAsync(ID);
        }
    }
}