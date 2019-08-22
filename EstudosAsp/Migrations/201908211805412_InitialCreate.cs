namespace EstudosAsp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "seguranca.nivel",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descricao = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.pessoa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 40),
                        sobrenome = c.String(maxLength: 40),
                        nome_mae = c.String(maxLength: 40),
                        nome_pai = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.nome, unique: true);
            
            CreateTable(
                "base.produto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descricao = c.String(nullable: false, maxLength: 40),
                        peso = c.Double(nullable: false),
                        _produto_tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("base.produto_tipo", t => t._produto_tipo, cascadeDelete: true)
                .Index(t => t.descricao, unique: true)
                .Index(t => t._produto_tipo);
            
            CreateTable(
                "base.produto_tipo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descricao = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.descricao, unique: true);
            
            CreateTable(
                "seguranca.usuario_nivel",
                c => new
                    {
                        _usuario = c.Int(nullable: false),
                        _nivel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t._usuario, t._nivel })
                .ForeignKey("seguranca.nivel", t => t._nivel, cascadeDelete: true)
                .ForeignKey("seguranca.usuario", t => t._usuario, cascadeDelete: true)
                .Index(t => t._usuario)
                .Index(t => t._nivel);
            
            CreateTable(
                "seguranca.usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 40),
                        login = c.String(nullable: false, maxLength: 40),
                        email = c.String(nullable: false, maxLength: 40),
                        data_ultimo_acesso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.login, unique: true)
                .Index(t => t.email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("seguranca.usuario_nivel", "_usuario", "seguranca.usuario");
            DropForeignKey("seguranca.usuario_nivel", "_nivel", "seguranca.nivel");
            DropForeignKey("base.produto", "_produto_tipo", "base.produto_tipo");
            DropIndex("seguranca.usuario", new[] { "email" });
            DropIndex("seguranca.usuario", new[] { "login" });
            DropIndex("seguranca.usuario_nivel", new[] { "_nivel" });
            DropIndex("seguranca.usuario_nivel", new[] { "_usuario" });
            DropIndex("base.produto_tipo", new[] { "descricao" });
            DropIndex("base.produto", new[] { "_produto_tipo" });
            DropIndex("base.produto", new[] { "descricao" });
            DropIndex("dbo.pessoa", new[] { "nome" });
            DropTable("seguranca.usuario");
            DropTable("seguranca.usuario_nivel");
            DropTable("base.produto_tipo");
            DropTable("base.produto");
            DropTable("dbo.pessoa");
            DropTable("seguranca.nivel");
        }
    }
}
