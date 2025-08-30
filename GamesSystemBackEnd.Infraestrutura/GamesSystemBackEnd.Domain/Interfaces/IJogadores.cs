using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Domain.Entitys;

namespace GamesSystemBackEnd.Domain.Interfaces
{
    public interface IJogadores
    {
        Task<int> AddNewJogadorAsync (Jogadores jogadores);
        Task<bool> CheckExistsJogadorAsync (string Email);
        Task<Jogadores> GetJogadorAsync (string Email);
        Task<List<Jogadores>> GetAllJogadoresAsync (bool ativos);
        Task<bool> UpdateJogadorAsync (Jogadores jogador);
        Task<bool> UpdatePasswordAsync (int ID, string NovaSenha);
        Task<bool> DeleteJogadorAsync (int ID);

    }
}