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


namespace WebDeveloper.Areas.Autor.Controllers
{
    [Authorize]
    public class AutorController : Controller
    {
        private readonly AutorRepositorio _AutorRepository;
        public AutorController(AutorRepositorio AutorRepository)
        {
            _AutorRepository = AutorRepository;
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
            return PartialView("_Lista", _AutorRepository.ObtenerListaDto().Page(page.Value, size.Value));
        }

        public PartialViewResult Crear()
        {
            return PartialView("_Crear");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(WebDeveloper.Model.Autor Autor)
        {
            if (!ModelState.IsValid) return PartialView("_Crear", Autor);
            _AutorRepository.Adicionar(Autor);
            return new HttpStatusCodeResult(HttpStatusCode.OK); //RedirectToAction("Index");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Editar(int id)
        {
            var Autor = _AutorRepository.ObtenerPorId(id);
            if (Autor == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Editar", Autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 0)]
        public ActionResult Editar(WebDeveloper.Model.Autor Autor)
        {
            if (!ModelState.IsValid) return PartialView("_Editar", Autor);
            _AutorRepository.Actualizar(Autor);
            return RedirectToRoute("Autor_defecto");
        }
        
        [OutputCache(Duration = 0)]
        public ActionResult Eliminar(int id)
        {
            var Autor = _AutorRepository.ObtenerPorId(id);
            if (Autor == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Eliminar", Autor);
        }
        
        #region Common Methods
        private int TotalPaginas(int? size)
        {
            var rows = _AutorRepository.TotalCantidad();
            var totalPages = rows / size.Value;
            return totalPages;
        }
        #endregion 
    }
}