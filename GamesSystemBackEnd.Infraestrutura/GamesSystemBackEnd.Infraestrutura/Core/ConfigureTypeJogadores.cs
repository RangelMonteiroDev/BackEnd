using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSystemBackEnd.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesSystemBackEnd.Infraestrutura.Core
{
    public class ConfigureTypeJogadores : IEntityTypeConfiguration<Jogadores>
    {
        public void Configure(EntityTypeBuilder<Jogadores> builder)
        {
            builder.Property(j => j.JogadorID).HasMaxLength(9999);
            builder.Property(j => j.Name).HasMaxLength(40).IsRequired();
            builder.Property(j => j.NickName).HasMaxLength(40).IsRequired();
            builder.Property(j => j.Email).HasMaxLength(40).IsRequired();
            builder.Property(j => j.Senha).HasMaxLength(8).IsRequired();
            builder.Property(j => j.Ativo).IsRequired();
        }
    }
}