using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rdio.Mvc.Core.Domain;
using Rdio.Mvc.Persistence;

namespace Rdio.Mvc.Controllers
{
    public class MusicasController : Controller
    {
        UnitOfWork db = new UnitOfWork(new RdioContext());

        // GET: Musicas
        public ActionResult Index()
        {
            var musics = db.Musics.GetAllMusicsWithGeneros();

            return View(musics);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Music music = db.Musics.Get(id.Value);

            if (music == null)
            {
                return HttpNotFound();
            }

            return View(music);            
        }

        [HttpPost]
        public ActionResult Edit(Music music)
        {
            if (ModelState.IsValid)
            {
                db.Musics.Update(music);
                db.Complete();

                return RedirectToAction("Index");
            }

            return View(music);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Music music = db.Musics.GetMusic(id.Value);

            if (music == null)
            {
                return HttpNotFound();
            }

            return View(music);
        }        
    }
}