using CartaoTodos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Data.Config
{
    public class UsuarioPerfilConfig : EntityTypeConfiguration<UsuarioPerfil>
    {
        public UsuarioPerfilConfig()
        {
            ToTable("USUARIO_PERFIL")
                .HasKey(p => new { p.IdPerfil, p.IdUsuario });

            Property(p => p.IdUsuario)
                .HasColumnName("ID_USUARIO")
                .IsRequired();

            Property(p => p.IdPerfil)
                .HasColumnName("ID_PERFIL")
                .IsRequired();

            Property(p=>p.Ativo)
                .HasColumnName("ATIVO");

        }
    }
}
