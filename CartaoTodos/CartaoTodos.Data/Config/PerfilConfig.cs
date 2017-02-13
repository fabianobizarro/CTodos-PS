using CartaoTodos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Data.Config
{
    public class PerfilConfig : EntityTypeConfiguration<Perfil>
    {
        public PerfilConfig()
        {
            ToTable("PERFIL").HasKey(p => p.Id);

            Property(p => p.Id)
                .HasColumnName("ID_PERFIL")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.Nome)
                .HasColumnName("NOME")
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Ativo)
                .HasColumnName("ATIVO");

        }
    }
}
