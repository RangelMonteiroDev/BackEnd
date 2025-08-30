using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Domain.Entitys;


namespace GamesSystemBackEnd.Domain.UseCases.IUseCases
{
    public interface IJogadorUseCase
    {
    Task<int> CreateNewJogadorAsync(Jogadores jogador);
    Task<bool> GetCheckExistAsync(string email);
    Task<Jogadores> GetJogadorAsync(int id, string email);
    Task<List<Jogadores>> GetAllJogadoresAsync(bool ativo);
    Task<bool> UpdateAsync(Jogadores jogador);
    Task<bool> UpdatePassAsync(int id, string senha);
    Task<bool> DeleteAsync(int id);

    }
}