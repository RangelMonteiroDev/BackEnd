using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GamesSystemBackEnd.Application.DTOs;
using GamesSystemBackEnd.Application.IServices;
using GamesSystemBackEnd.Application.Services;
using GamesSystemBackEnd.Domain.Entitys;
using GamesSystemBackEnd.Domain.UseCases;
using GamesSystemBackEnd.Domain.UseCases.IUseCases;
using Moq;
using Xunit;

namespace UnitTestGameSystem.BackEnd.Application.Services
{
    public class TesteJogadorService
    {
        private readonly Mock<IJogadorUseCase> _mockJogadorUseCase;
        private readonly IServiceJogador _JogadoresService;
        private readonly Mock<IMapper> _mockMapping;

        public TesteJogadorService()
        {
        _mockJogadorUseCase = new Mock<IJogadorUseCase>();
        _mockMapping = new Mock<IMapper>();

        // injeta os mocks no Service
        _JogadoresService = new JogadoresServices(
            _mockJogadorUseCase.Object,
            _mockMapping.Object
        );
        }


        [Fact]
        public async Task Deve_Adicionar_Jogador()
        {
            var jogadorDTO = new JogadoresDTO("Rangel", "PlayerPoweRanger", "rangel@jogadorDTO", "12345678", true);

            var jogador = new Jogadores("Rangel", "PlayerPoweRanger", "rangel@jogadorDTO", "12345678", true);


            _mockMapping.Setup(m => m.Map<Jogadores>(jogadorDTO)).Returns(jogador);

            _mockJogadorUseCase.Setup(j => j.CreateNewJogadorAsync(jogador)).ReturnsAsync(1);


            var resultado = await _JogadoresService.ServiceCreateJogadorAsync(jogadorDTO);

            Assert.Equal(1, resultado);


            _mockJogadorUseCase.Verify(j => j.CreateNewJogadorAsync(jogador), Times.Once);

        }

        [Fact]
        public async Task Deve_Checkar_Se_Jogador_Existe()
        {
            var Email = "rangel@jogadorDTO";


            _mockJogadorUseCase.Setup(j => j.GetCheckExistAsync(Email)).ReturnsAsync(true);


            var resultado = await _JogadoresService.ServiceCheckExistsJogadorAsync(Email);

            Assert.Equal(true, resultado);


            _mockJogadorUseCase.Verify(j => j.GetCheckExistAsync(Email), Times.Once);

        }

        [Fact]
        public async Task Deve_Atualizar_Jogador()
        {
            var jogadorDTO = new JogadoresDTO("Rangel", "PlayerPoweRanger", "rangel@jogadorDTO", "12345678", true);

            var jogador = new Jogadores("Rangel", "PlayerPoweRanger", "rangel@jogador", "12345678", true);


            _mockMapping.Setup(m => m.Map<Jogadores>(jogadorDTO)).Returns(jogador);

            _mockJogadorUseCase.Setup(j => j.UpdateAsync(jogador)).ReturnsAsync(true);


            var updates = await _JogadoresService.ServiceUpdateJogadorAsync(jogadorDTO);


            Assert.True(updates);

            _mockJogadorUseCase.Verify(j => j.UpdateAsync(jogador), Times.Once);

        }

        [Fact]
        public async Task Deve_Atualizar_Senha()
        {
            var ID = 1;
            var novaSenha = "12345678";

            _mockJogadorUseCase.Setup(j => j.UpdatePassAsync(ID, novaSenha)).ReturnsAsync(true);

            var updates = await _JogadoresService.ServiceUpdatePassJogadorAsync(ID, novaSenha);

            Assert.True(updates);

            _mockJogadorUseCase.Verify(j => j.UpdatePassAsync(ID, novaSenha), Times.Once);

        }

        [Fact]
        public async Task Deve_Deletar_Jogador()
        {
            var ID = 1;

            _mockJogadorUseCase.Setup(j => j.DeleteAsync(ID)).ReturnsAsync(true);

            var deletes = await _JogadoresService.ServiceDeleteJogadorAsync(ID);

            Assert.True(deletes);

            _mockJogadorUseCase.Verify(j => j.DeleteAsync(ID), Times.Once);
            
        }
    }
}