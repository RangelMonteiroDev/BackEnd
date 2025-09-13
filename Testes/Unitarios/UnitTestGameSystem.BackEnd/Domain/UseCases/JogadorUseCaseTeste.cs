using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using GamesSystemBackEnd.Application.IServices;
using GamesSystemBackEnd.Domain.Entitys;
using GamesSystemBackEnd.Domain.Interfaces;
using GamesSystemBackEnd.Domain.UseCases;
using GamesSystemBackEnd.Domain.UseCases.IUseCases;
using Moq;
using Xunit;

namespace UnitTestGameSystem.BackEnd.Domain.UseCases
{
    public class JogadorUseCaseTeste
    {
        private readonly Mock<IJogadores> _mockJogador;
        private readonly IJogadorUseCase _jogadorUseCase;

        public JogadorUseCaseTeste()
        {
            _mockJogador = new Mock<IJogadores>();

            _jogadorUseCase = new JogadorUseCase(

                _mockJogador.Object
            );
        }

        [Fact]
        public async Task Deve_Cadastrar_Novo_Jogador()
        {

            var jogador = new Jogadores("Rangel", "PlayerPoweRanger", "rangel@jogador", "12345678", true);

            _mockJogador.Setup(j => j.AddNewJogadorAsync(jogador)).ReturnsAsync(1);


            var resultado = await _jogadorUseCase.CreateNewJogadorAsync(jogador);

            Assert.Equal(1, resultado);


            _mockJogador.Verify(j => j.AddNewJogadorAsync(jogador), Times.Once);

        }

        [Fact]
        public async Task Deve_Checkar_Se_Existe_Jogador()
        {
            var Email = "rangel@jogador";

            _mockJogador.Setup(j => j.CheckExistsJogadorAsync(Email)).ReturnsAsync(true);


            var exists = await _jogadorUseCase.GetCheckExistAsync(Email);

            Assert.True(exists);


            _mockJogador.Verify(j => j.CheckExistsJogadorAsync(Email), Times.Once);
        }

        [Fact]
        public async Task Deve_Atualizar_Jogador()
        {
            var jogador = new Jogadores("Rangel", "PlayerPoweRanger", "rangel@jogador", "12345678", true);

            _mockJogador.Setup(j => j.UpdateJogadorAsync(jogador)).ReturnsAsync(true);


            var updates = await _jogadorUseCase.UpdateAsync(jogador);
            Assert.True(updates);

            _mockJogador.Verify(j => j.UpdateJogadorAsync(jogador), Times.Once);
        }

        [Fact]
        public async Task Deve_Atualizar_Senha()
        {
            var ID = 1;
            var NovaSenha = "12345678";

            _mockJogador.Setup(j => j.UpdatePasswordAsync(ID, NovaSenha)).ReturnsAsync(true);

            var updates = await _jogadorUseCase.UpdatePassAsync(ID, NovaSenha);
            Assert.True(updates);

            _mockJogador.Verify(j => j.UpdatePasswordAsync(ID, NovaSenha), Times.Once);
        }

        [Fact]
        public async Task Deve_Desativar_Jogador()
        {
            var ID = 1;
            _mockJogador.Setup(j => j.DeleteJogadorAsync(ID)).ReturnsAsync(true);

            var deletes = await _jogadorUseCase.DeleteAsync(ID);
            Assert.True(deletes);

            _mockJogador.Verify(j => j.DeleteJogadorAsync(ID), Times.Once);

        }
    }
}