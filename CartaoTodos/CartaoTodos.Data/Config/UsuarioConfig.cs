using CartaoTodos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Data.Config
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("USUARIO")
                .HasKey(p => p.Id);

            Property(p => p.Id)
                .HasColumnName("ID_USUARIO")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.Login)
                .HasColumnName("LOGIN")
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("NOME");

            Property(p => p.Email)
                .HasMaxLength(70)
                .IsRequired()
                .HasColumnName("EMAIL");

            Property(p => p.Senha)
                .HasMaxLength(256)
                .IsOptional()
                .HasColumnName("SENHA");

            Property(p => p.Ativo)
                .HasColumnName("ATIVO");

            Property(p => p.DataInclusao)
                .HasColumnName("DT_INCLUSAO")
                .IsRequired();


            HasMany(p => p.Perfis)
                .WithRequired(p => p.Usuario)
                .HasForeignKey(p => p.IdUsuario)
                .WillCascadeOnDelete();

            HasMany(p => p.Operacoes)
                .WithRequired(p => p.Usuario)
                .HasForeignKey(p => p.IdUsuario)
                .WillCascadeOnDelete();
        }
    }
}
