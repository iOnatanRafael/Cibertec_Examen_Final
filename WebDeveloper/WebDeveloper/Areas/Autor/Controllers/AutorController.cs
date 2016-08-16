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
        private readonly AutorRepository _AutorRepository;
        public AutorController(AutorRepository AutorRepository)
        {
            _AutorRepository = AutorRepository;
        }

        [OutputCache(Duration = 0)]
        public ActionResult Index()
        {
            ViewBag.Count = TotalPages(10);
            return View();
        }

        [OutputCache(Duration = 0)]
        public ActionResult List(int? page, int? size)
        {
            if (!page.HasValue || !size.HasValue)
            {
                page = 1;
                size = 10;
            }            
            return PartialView("_List",_AutorRepository.GetListDto().Page(page.Value, size.Value));
        }

        public PartialViewResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WebDeveloper.Model.Autor Autor)
        {
            if (!ModelState.IsValid) return PartialView("_Create", Autor);
            _AutorRepository.Add(Autor);
            return new HttpStatusCodeResult(HttpStatusCode.OK); //RedirectToAction("Index");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Edit(int id)
        {
            var Autor = _AutorRepository.GetById(id);
            if (Autor == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Edit", Autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 0)]
        public ActionResult Edit(WebDeveloper.Model.Autor Autor)
        {
            if (!ModelState.IsValid) return PartialView("_Edit", Autor);
            _AutorRepository.Update(Autor);
            return RedirectToRoute("Autor_default");
        }


        [OutputCache(Duration = 0)]
        public ActionResult Delete(int id)
        {
            var Autor = _AutorRepository.GetById(id);
            if (Autor == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Delete", Autor);
        }

        public ActionResult Upload()
        {
            return PartialView("_FileUpload");
        }

        [HttpPost]
        [OutputCache(Duration = 0)]
        public ActionResult UploadFile()
        {
            if (Request.Files.Count == 0) return PartialView("_FileUpload");
            var file = Request.Files[0];
            try
            {
                var folder = Server.MapPath("~/Files");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                string path = Path.Combine(folder, Path.GetFileName(file.FileName));
                file.SaveAs(path);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        #region Common Methods
        private int TotalPages(int? size)
        {
            var rows = _AutorRepository.TotalCount();
            var totalPages = rows / size.Value;
            return totalPages;
        }
        #endregion 
    }
}