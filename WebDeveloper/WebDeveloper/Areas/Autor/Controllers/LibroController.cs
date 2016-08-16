using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Areas.Autor.Controllers
{
    public class LibroController : Controller
    {
        // GET: Autor/Address
        private LibroRepository _libro;
        public LibroController(LibroRepository libro)
        {
            _libro = libro;
        }
        public ActionResult Index()
        {
            return View(_libro.GetListDto());
        }
    }
}