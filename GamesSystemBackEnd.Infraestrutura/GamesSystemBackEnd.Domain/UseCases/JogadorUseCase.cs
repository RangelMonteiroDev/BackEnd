using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Domain.Entitys;
using GamesSystemBackEnd.Domain.Interfaces;
using GamesSystemBackEnd.Domain.UseCases.IUseCases;

namespace GamesSystemBackEnd.Domain.UseCases
{
    public class JogadorUseCase : IJogadorUseCase
    {
        private readonly IJogadores _jogador;

        public JogadorUseCase(IJogadores jogador)
        {
            _jogador = jogador;
        }

        public async Task<int> CreateNewJogadorAsync(Jogadores jogador)
        {
            return await _jogador.AddNewJogadorAsync(jogador);
        }

        public async Task<bool> GetCheckExistAsync(string Email)
        {
            return await _jogador.CheckExistsJogadorAsync(Email);
        }

        public async Task<Jogadores> GetJogadorAsync(int ID, string Email)
        {
            return await _jogador.GetJogadorAsync(Email);
        }

        public async Task<List<Jogadores>> GetAllJogadoresAsync(bool Ativos)
        {
            return await _jogador.GetAllJogadoresAsync(Ativos);
        }

        public async Task<bool> UpdateAsync(Jogadores jogador)
        {
            return await _jogador.UpdateJogadorAsync(jogador);
        }

        public async Task<bool> UpdatePassAsync(int ID,string NovaSenha)
        {
            return await _jogador.UpdatePasswordAsync(ID, NovaSenha);
        }
        
        public async Task<bool> DeleteAsync(int ID)
        {
            return await _jogador.DeleteJogadorAsync(ID);
        }
    }
}