using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Domain.Entitys;
using GamesSystemBackEnd.Domain.Interfaces;
using GamesSystemBackEnd.Infraestrutura.Data;
using GamesSystemBackEnd.Infraestrutura.Transactions;
using Microsoft.EntityFrameworkCore;


namespace GamesSystemBackEnd.Infraestrutura.Respositorys
{
    public class JogadoresRepository : IJogadores
    {
        private Jogadores Jogador;

        private readonly AppDataSqlServerContext _context;
        private readonly IUnitOfWork _unityOfWork;

        public JogadoresRepository(AppDataSqlServerContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unityOfWork = unitOfWork;
        }

        public async Task<int> AddNewJogadorAsync (Jogadores jogador)
        {
            try
            {
                await _unityOfWork.BeginTransactionAsync();
                var existsJogador = await CheckExistsJogadorAsync(jogador.Email);

                if (existsJogador)
                {
                    await _unityOfWork.RollBackAsync();
                    return 0;
                }
                else
                {
                    await _context.Jogadores.AddAsync(jogador);
                    await _context.SaveChangesAsync();
                    await _unityOfWork.CommitAsync();
                }

                var results = await _context.Jogadores.FirstOrDefaultAsync(j => j.Email == jogador.Email);
                return results.JogadorID;
            }

            catch (System.Exception)
            {
                await _unityOfWork.RollBackAsync();
                throw;
            }
        }

        public async Task<bool> CheckExistsJogadorAsync (string Email)
        {
            try
            {
                var results = await _context.Jogadores.FirstOrDefaultAsync(j => j.Email == Email);

                if (results.JogadorID > 0)
                {
                    return true;
                }
                return false;
            }

            catch (System.Exception)
            {
                throw;
            }
        }
        
        public async Task<Jogadores> GetJogadorAsync(string Email)
        {
            var exists = await CheckExistsJogadorAsync(Email);
            if (exists)
            {
                return await _context.Jogadores.FindAsync(Email);
            }
            else
            {
                bool notExists = true;
                Jogador = new Jogadores(notExists);
                return Jogador;
            }
        }

        public async Task<List<Jogadores>> GetAllJogadoresAsync(bool ativos)
        {
            return await _context.Jogadores.Where(j => j.Ativo == ativos).ToListAsync();
        }

        public async Task<bool> UpdateJogadorAsync (Jogadores jogadores)
        {
            try
            {
                await _unityOfWork.BeginTransactionAsync();

                var ID = jogadores.JogadorID;
                var results = await _context.Jogadores.FindAsync(ID);

                Jogador = new Jogadores(results.Name, results.NickName, results.Email, results.Senha, results.Ativo);
                Jogador.UpdateJogador(jogadores.Name, jogadores.NickName, jogadores.Email);

                await _context.SaveChangesAsync();
                await _unityOfWork.CommitAsync();

                return true;
            }

            catch (System.Exception)
            {
                await _unityOfWork.RollBackAsync();
                throw;
            }
        }

        public async Task<bool> UpdatePasswordAsync (int ID, string NovaSenha)
        {
            try
            {
                await _unityOfWork.BeginTransactionAsync();
                var results = await _context.Jogadores.FindAsync(ID);
                Jogador = new Jogadores(results.Name, results.NickName, results.Email, results.Senha, results.Ativo);

                Jogador.UpdatePassJogador(NovaSenha);
                await _context.SaveChangesAsync();
                await _unityOfWork.CommitAsync();

                return true;
            }

            catch (System.Exception)
            {
                await _unityOfWork.RollBackAsync();
                throw;
            }
        }
        
        public async Task<bool> DeleteJogadorAsync (int ID)
        {
            try
            {
                await _unityOfWork.BeginTransactionAsync();
                var results = await _context.Jogadores.FindAsync(ID);
                Jogador = new Jogadores(results.Name, results.NickName, results.Email, results.Senha, results.Ativo);
                Jogador.DeactivateJogador(false);

                await _context.SaveChangesAsync();
                await _unityOfWork.CommitAsync();

                return true;    

            }

            catch (System.Exception)
            {
                await _unityOfWork.RollBackAsync();
                throw;
            }
        }
    }
}