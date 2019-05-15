namespace Rdio.Mvc.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste_01 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Album", new[] { "Artista_Id" });
            RenameColumn(table: "dbo.Album", name: "Name", newName: "Album");
            RenameColumn(table: "dbo.Artista", name: "Name", newName: "Artista");
            RenameColumn(table: "dbo.Album", name: "Artista_Id", newName: "ArtistaId");
            AlterColumn("dbo.Album", "Album", c => c.String(nullable: false));
            AlterColumn("dbo.Album", "PhotoAlbumType", c => c.String(maxLength: 20));
            AlterColumn("dbo.Album", "ArtistaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Artista", "Artista", c => c.String(maxLength: 100));
            CreateIndex("dbo.Album", "ArtistaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Album", new[] { "ArtistaId" });
            AlterColumn("dbo.Artista", "Artista", c => c.String());
            AlterColumn("dbo.Album", "ArtistaId", c => c.Int());
            AlterColumn("dbo.Album", "PhotoAlbumType", c => c.String());
            AlterColumn("dbo.Album", "Album", c => c.String());
            RenameColumn(table: "dbo.Album", name: "ArtistaId", newName: "Artista_Id");
            RenameColumn(table: "dbo.Artista", name: "Artista", newName: "Name");
            RenameColumn(table: "dbo.Album", name: "Album", newName: "Name");
            CreateIndex("dbo.Album", "Artista_Id");
        }
    }
}
