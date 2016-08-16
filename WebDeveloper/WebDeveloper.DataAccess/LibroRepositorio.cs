using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;
using WebDeveloper.Model.DTO;

namespace WebDeveloper.DataAccess
{
    public class LibroRepositorio : BaseAccesoDatos<Libro>
    {
        public IEnumerable<LibroModelView> ObtenerListaDto()
        {
            using (var dbContext = new WebContextDb())
            {
                return Automapper.GetGeneric<IEnumerable<Libro>, List<LibroModelView>>(dbContext.Libro.OrderByDescending(x => x.LibroID));
            }
        }

        public IEnumerable<LibroModelView> ObtenerListaDtoPagina(int page, int size)
        {
            using (var dbContext = new WebContextDb())
            {
                return Automapper.GetGeneric<IEnumerable<Libro>, List<LibroModelView>>(dbContext.Libro.OrderByDescending(x => x.LibroID).Page(page, size));
            }
        }
        
        public Libro ObtenerPorId(int id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Libro.FirstOrDefault(p => p.LibroID == id);
            }
        }

        public int TotalCantidad()
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Libro.Count();
            }
        }
    }
}