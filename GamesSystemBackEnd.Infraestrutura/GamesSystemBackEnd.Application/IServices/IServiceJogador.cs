using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Application.DTOs;

namespace GamesSystemBackEnd.Application.IServices
{
    public interface IServiceJogador
    {
        Task<int> ServiceCreateJogadorAsync(JogadoresDTO jogadorDTO);
        Task<bool> ServiceCheckExistsJogadorAsync(string Email);
        Task<JogadoresDTO> ServiceGetJogadorAsync(int ID, string Email);
        Task<List<JogadoresDTO>> ServiceGetAllJogadorAsync(bool ativos);
        Task<bool> ServiceUpdateJogadorAsync(JogadoresDTO jogadoresDTO);
        Task<bool> ServiceUpdatePassJogadorAsync(int ID, string NovaSenha);
        Task<bool> ServiceDeleteJogadorAsync(int ID);
    }
}