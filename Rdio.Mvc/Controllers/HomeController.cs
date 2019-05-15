using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rdio.Mvc.Core.Domain;
using Rdio.Mvc.Persistence;
using Rdio.Mvc.ViewModels;

namespace Rdio.Mvc.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _db = new UnitOfWork(new RdioContext());

        public ActionResult Index()
        {
            StatusGeralViewModel viewModel = new StatusGeralViewModel
            {
                RapHipHopPercent = RapHipHopPercent(),
                RockPercent = RockPercent(),
                PopPercent = PopPercent(),
                PagodePercent = PagodePercent(),
                ReligiousPercent = ReligiousPercent(),
                InstrumentalsPercent = InstrumentalsPercent(),
                SoundTrackMoviesPercent = SoundTrackMoviesPercent(),

                TotalMusicas = TotalMusicas(),
                TotalArtistas = TotalArtistas(),
                TotalAlbums = TotalAlbums(),
                TotalGeneros = TotalGeneros(),
                TotalFavoritas = TotalFavoritas(),
                TotalCincoEstrelas = TotalCincoEstrelas()
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private int TotalMusicas()
        {
            return _db.Musics.GetAll().Count();
        }
        private int TotalArtistas()
        {
            return _db.Artistas.GetAll().Count();
        }
        private int TotalAlbums()
        {            
            return _db.Albums.GetAll().Count();
        }
        private int TotalGeneros()
        {
            return _db.Generos.GetGenero().ToList().Count;
        }
        private int TotalFavoritas()
        {
            return _db.Musics.GetAllFavorites().Count();
        }
        private int TotalCincoEstrelas()
        {
            return _db.Musics.GetAllCincoEstrelas().Count();
        }

        private int GetPercent(int totalGenero, int totalMusicas)
        {
            return Convert.ToInt32(Math.Round((Convert.ToDecimal(totalGenero) / Convert.ToDecimal(totalMusicas)) * 100, 0));
        }
        private int RapHipHopPercent()
        {
            return GetPercent(_db.Musics.GetMusicsByGenero(Convert.ToInt32(TipoGenero.RapHipHop)).ToList().Count, TotalMusicas());
        }
        private int RockPercent()
        {
            return GetPercent(_db.Musics.GetMusicsByGenero(Convert.ToInt32(TipoGenero.Rock)).ToList().Count, TotalMusicas());
        }
        private int PopPercent()
        {
            return GetPercent(_db.Musics.GetMusicsByGenero(Convert.ToInt32(TipoGenero.Pop)).ToList().Count, TotalMusicas());
        }
        private int PagodePercent()
        {
            return GetPercent(_db.Musics.GetMusicsByGenero(Convert.ToInt32(TipoGenero.Pagode)).ToList().Count, TotalMusicas());
        }
        private int ReligiousPercent()
        {
            return GetPercent(_db.Musics.GetMusicsByGenero(Convert.ToInt32(TipoGenero.Religious)).ToList().Count, TotalMusicas());
        }
        private int InstrumentalsPercent()
        {
            return GetPercent(_db.Musics.GetMusicsByGenero(Convert.ToInt32(TipoGenero.Instrumentals)).ToList().Count, TotalMusicas());
        }
        private int SoundTrackMoviesPercent()
        {
            return GetPercent(_db.Musics.GetMusicsByGenero(Convert.ToInt32(TipoGenero.SoundtrackMovies)).ToList().Count, TotalMusicas());
        }
    }
}
