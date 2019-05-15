namespace Rdio.Mvc.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remodelado_banco_de_dados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genero = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Musica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Musica = c.String(nullable: false, maxLength: 1000),
                        TrackNumber = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Favorite = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        ArtistaId = c.Int(nullable: false),
                        GeneroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.AlbumId)
                .ForeignKey("dbo.Artista", t => t.ArtistaId)
                .ForeignKey("dbo.Genero", t => t.GeneroId)
                .Index(t => t.AlbumId)
                .Index(t => t.ArtistaId)
                .Index(t => t.GeneroId);
            
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhotoAlbum = c.Binary(),
                        PhotoAlbumType = c.String(),
                        Artista_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artista", t => t.Artista_Id)
                .Index(t => t.Artista_Id);
            
            CreateTable(
                "dbo.Artista",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musica", "GeneroId", "dbo.Genero");
            DropForeignKey("dbo.Musica", "ArtistaId", "dbo.Artista");
            DropForeignKey("dbo.Musica", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Album", "Artista_Id", "dbo.Artista");
            DropIndex("dbo.Album", new[] { "Artista_Id" });
            DropIndex("dbo.Musica", new[] { "GeneroId" });
            DropIndex("dbo.Musica", new[] { "ArtistaId" });
            DropIndex("dbo.Musica", new[] { "AlbumId" });
            DropTable("dbo.Artista");
            DropTable("dbo.Album");
            DropTable("dbo.Musica");
            DropTable("dbo.Genero");
        }
    }
}
