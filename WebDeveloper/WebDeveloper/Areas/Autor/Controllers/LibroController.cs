using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;


namespace WebDeveloper.Areas.Libro.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        private readonly LibroRepositorio _LibroRepository;
        public LibroController(LibroRepositorio LibroRepository)
        {
            _LibroRepository = LibroRepository;
        }

        [OutputCache(Duration = 0)]
        public ActionResult Index()
        {
            ViewBag.Count = TotalPaginas(10);
            return View();
        }

        [OutputCache(Duration = 0)]
        public ActionResult Lista(int? page, int? size)
        {
            if (!page.HasValue || !size.HasValue)
            {
                page = 1;
                size = 10;
            }            
            return PartialView("_Lista", _LibroRepository.ObtenerListaDto().Page(page.Value, size.Value));
        }

        public PartialViewResult Crear()
        {
            return PartialView("_Crear");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(WebDeveloper.Model.Libro Libro)
        {
            if (!ModelState.IsValid) return PartialView("_Crear", Libro);
            _LibroRepository.Adicionar(Libro);
            return new HttpStatusCodeResult(HttpStatusCode.OK); //RedirectToAction("Index");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Editar(int id)
        {
            var Libro = _LibroRepository.ObtenerPorId(id);
            if (Libro == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Editar", Libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 0)]
        public ActionResult Editar(WebDeveloper.Model.Libro Libro)
        {
            if (!ModelState.IsValid) return PartialView("_Editar", Libro);
            _LibroRepository.Actualizar(Libro);
            return RedirectToRoute("Libro_defecto");
        }
        
        [OutputCache(Duration = 0)]
        public ActionResult Eliminar(int id)
        {
            var Libro = _LibroRepository.ObtenerPorId(id);
            if (Libro == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Eliminar", Libro);
        }
        
        #region Common Methods
        private int TotalPaginas(int? size)
        {
            var rows = _LibroRepository.TotalCantidad();
            var totalPages = rows / size.Value;
            return totalPages;
        }
        #endregion 
    }
}