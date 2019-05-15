using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rdio.Mvc.Persistence;
using Rdio.Mvc.Core.Domain;
using PagedList;


namespace Rdio.Mvc.Controllers
{
    public class AlbumsController : Controller
    {
        private UnitOfWork _db;

        public AlbumsController()
        {
            _db = new UnitOfWork(new RdioContext());
        }
        // GET: Albums
        //public ActionResult Index()
        //{
        //    //var albums = _db.Albums.GetAllAlbums().ToList();
            
        //    var albums = _db.Albums.GetAllAlbums().ToPagedList(1, 30);

        //    return View(albums);
        //}

        public ActionResult Index(int? page = 1)
        {
            int pageSize = 30;
            int pageNumber = page ?? 1;

            var collections = _db.Albums.GetAllAlbums().ToPagedList(pageNumber, pageSize);

            return View(collections);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            var result = _db.Albums.GetAlbumById(id);

            Album album = result; 
            var musicasDoAlbum = _db.Musics.GetMusicsByAlbum(album.Id);

            if (musicasDoAlbum.Count() > 0)
            {
                album.GeneroAlbum = musicasDoAlbum.FirstOrDefault().Genero.Descricao;
            }
            
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            var album = _db.Albums.GetAlbumById(id);

            return View(album);
        }

        // POST: Albums/Edit/5
        [HttpPost]
        public ActionResult Edit(Album albumForm, FormCollection form, HttpPostedFileBase imageAlbum)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Carrego um album com suas informações completas (Artista e Musicas) e preencho com as informações da Imagem
                    var album = new Album();
                    album = _db.Albums.GetAlbumById(albumForm.Id);

                    if (imageAlbum != null && imageAlbum.ContentLength > 0)
                    {                                                
                        album.PhotoAlbumType = imageAlbum.ContentType;

                        using (var reader = new BinaryReader(imageAlbum.InputStream))
                        {
                            album.PhotoAlbum = reader.ReadBytes(imageAlbum.ContentLength);
                        }
                                                
                        album.Name = albumForm.Name;
                        album.Artista.Name = albumForm.Artista.Name;
                    }

                    _db.Albums.Update(album);
                    _db.Complete();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }                
            }

            return View(albumForm);
        }

        public ActionResult ExibirImagemAlbum(int id)
        {
            var imageAlbum = _db.Albums.GetAlbumById(id);

            return File(imageAlbum.PhotoAlbum, imageAlbum.PhotoAlbumType);
        }        
    }
}
