namespace CartaoTodos.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CartaoTodos.Data.Context.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CartaoTodos.Data.Context.AppContext context)
        {
            if (!context.Perfis.Any(p=>p.Nome == "Administrador"))
            {
                context.Perfis.Add(new Domain.Entities.Perfil()
                {
                    Nome = "Administrador",
                    Ativo = true
                });
            }

            if (!context.Perfis.Any(p => p.Nome == "Moderador"))
            {
                context.Perfis.Add(new Domain.Entities.Perfil()
                {
                    Nome = "Moderador",
                    Ativo = true
                });
            }

            if (!context.Perfis.Any(p => p.Nome == "Diretor"))
            {
                context.Perfis.Add(new Domain.Entities.Perfil()
                {
                    Nome = "Diretor",
                    Ativo = true
                });
            }

            if (!context.Perfis.Any(p => p.Nome == "Operacional"))
            {
                context.Perfis.Add(new Domain.Entities.Perfil()
                {
                    Nome = "Operacional",
                    Ativo = true
                });
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
