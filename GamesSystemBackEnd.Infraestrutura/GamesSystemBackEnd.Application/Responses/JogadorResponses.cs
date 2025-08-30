using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GamesSystemBackEnd.Application.DTOs;

namespace GamesSystemBackEnd.Application.Responses
{
    public class JogadorResponseGetJogador
    {
        public int HTTPStatusCode { get; set; }
        public JogadoresDTO jogadorDTO { get; set; }

        private JogadoresDTO CheckResponse(JogadoresDTO jogadorDTO)
        {
            if (jogadorDTO.NotFound)
            {
                return new JogadoresDTO(true);
            }

            return new JogadoresDTO(jogadorDTO.Name, jogadorDTO.NickName, jogadorDTO.Email);
        }

        public JogadorResponseGetJogador(int HTTPStatusCode, JogadoresDTO jogadorDTO)
        {
            this.HTTPStatusCode = HTTPStatusCode;
            this.jogadorDTO = CheckResponse(jogadorDTO);
        }

    }

    public class JogadorResponseGetAll
    {
        public int HTTPStatusCode { get; set; }
        public List<JogadoresDTO> jogadorLIST { get; set; }

        private List<JogadoresDTO> TratamentoDeDados(List<JogadoresDTO> jogadorLIST)
        {
            if (jogadorLIST[0] == null)
            {
                HTTPStatusCode = 404;
            }
            else
            {
                HTTPStatusCode = 200;
            }


            List<JogadoresDTO> jogadoresDTOsLista = new();

            foreach (var jogador in jogadorLIST)
            {
                var data = new JogadoresDTO(jogador.Name, jogador.NickName, jogador.Email);
                jogadoresDTOsLista.Add(data);
            }

            return jogadoresDTOsLista;
        }

        public JogadorResponseGetAll(int HTTPStatusCode, List<JogadoresDTO> jogadoresLIST)
        {
            this.HTTPStatusCode = HTTPStatusCode;
            this.jogadorLIST = TratamentoDeDados(jogadoresLIST);
        }

    }

    public class JogadorResponseBooleanStatus
    {
        public int HTTPStatusCode { get; set; }
        public bool BooleanStatus { get; set; }

        public JogadorResponseBooleanStatus(int HTTPStatusCode, bool BooleanStatus)
        {
            this.HTTPStatusCode = HTTPStatusCode;
            this.BooleanStatus = BooleanStatus;
        }
    }

    public class JogadorResponseCreate
    {
        public int HTTPStatusCode { get; set; }
        public int ID { get; set; }

        public JogadorResponseCreate(int HTTPStatusCode, int ID)
        {
            this.HTTPStatusCode = HTTPStatusCode;
            this.ID = ID;
        }
    }
}