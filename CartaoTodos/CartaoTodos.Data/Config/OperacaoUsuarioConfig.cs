using CartaoTodos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Data.Config
{
    public class OperacaoUsuarioConfig : EntityTypeConfiguration<OperacaoUsuario>
    {
        public OperacaoUsuarioConfig()
        {
            ToTable("OPERACAO_USUARIO")
                .HasKey(p => p.IdOperacao);

            Property(p => p.IdOperacao)
                .HasColumnName("ID_OPERACAO_ACESSO");

            Property(p => p.DataLog)
                .HasColumnName("DT_LOG")
                .IsRequired();

            Property(p => p.IdUsuario)
                .HasColumnName("ID_USUARIO")
                .IsRequired();


            HasRequired(p => p.Usuario)
                .WithMany(p => p.Operacoes)
                .HasForeignKey(p => p.IdUsuario);

        }
    }
}
