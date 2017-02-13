namespace CartaoTodos.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OPERACAO_USUARIO",
                c => new
                    {
                        ID_OPERACAO_ACESSO = c.Int(nullable: false, identity: true),
                        DT_LOG = c.DateTime(nullable: false),
                        ID_USUARIO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_OPERACAO_ACESSO)
                .ForeignKey("dbo.USUARIO", t => t.ID_USUARIO)
                .Index(t => t.ID_USUARIO);
            
            CreateTable(
                "dbo.USUARIO",
                c => new
                    {
                        ID_USUARIO = c.Int(nullable: false, identity: true),
                        LOGIN = c.String(nullable: false, maxLength: 50),
                        NOME = c.String(nullable: false, maxLength: 100),
                        EMAIL = c.String(nullable: false, maxLength: 70),
                        SENHA = c.String(nullable: false, maxLength: 256),
                        ATIVO = c.Boolean(nullable: false),
                        DT_INCLUSAO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_USUARIO);
            
            CreateTable(
                "dbo.USUARIO_PERFIL",
                c => new
                    {
                        ID_PERFIL = c.Int(nullable: false),
                        ID_USUARIO = c.Int(nullable: false),
                        ATIVO = c.Boolean(nullable: false),
                        Perfil_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.ID_PERFIL, t.ID_USUARIO })
                .ForeignKey("dbo.PERFIL", t => t.Perfil_Id)
                .ForeignKey("dbo.USUARIO", t => t.ID_USUARIO)
                .Index(t => t.ID_USUARIO)
                .Index(t => t.Perfil_Id);
            
            CreateTable(
                "dbo.PERFIL",
                c => new
                    {
                        ID_PERFIL = c.Int(nullable: false, identity: true),
                        NOME = c.String(nullable: false, maxLength: 50),
                        ATIVO = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_PERFIL);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OPERACAO_USUARIO", "ID_USUARIO", "dbo.USUARIO");
            DropForeignKey("dbo.USUARIO_PERFIL", "ID_USUARIO", "dbo.USUARIO");
            DropForeignKey("dbo.USUARIO_PERFIL", "Perfil_Id", "dbo.PERFIL");
            DropIndex("dbo.USUARIO_PERFIL", new[] { "Perfil_Id" });
            DropIndex("dbo.USUARIO_PERFIL", new[] { "ID_USUARIO" });
            DropIndex("dbo.OPERACAO_USUARIO", new[] { "ID_USUARIO" });
            DropTable("dbo.PERFIL");
            DropTable("dbo.USUARIO_PERFIL");
            DropTable("dbo.USUARIO");
            DropTable("dbo.OPERACAO_USUARIO");
        }
    }
}
