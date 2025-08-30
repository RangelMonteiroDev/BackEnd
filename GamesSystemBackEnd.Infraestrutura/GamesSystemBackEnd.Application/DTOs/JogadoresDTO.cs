using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSystemBackEnd.Application.DTOs
{
    public class JogadoresDTO
    {
        public bool NotFound{ get; }

        public int JogadorID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public JogadoresDTO(string Name, string NickName, string Email, string Senha, bool Ativo)
        {
            this.Name = Name;
            this.NickName = NickName;
            this.Email = Email;
            this.Senha = Senha;
            this.Ativo = Ativo;
        }

        public JogadoresDTO(bool notExists)
        {
            this.NotFound = notExists;
        }

        public JogadoresDTO(string name, string nickName, string email)
        {
            this.Name = name;
            this.NickName = nickName;
            this.Email = email;
        }
    }
}