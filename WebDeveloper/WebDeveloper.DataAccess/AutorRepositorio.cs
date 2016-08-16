using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;
using WebDeveloper.Model.DTO;

namespace WebDeveloper.DataAccess
{
    public class AutorRepositorio : BaseAccesoDatos<Autor>
    {
        public IEnumerable<AutorModelView> ObtenerListaDto()
        {
            using (var dbContext = new WebContextDb())
            {
                return Automapper.GetGeneric<IEnumerable<Autor>, List<AutorModelView>>(dbContext.Autor.OrderByDescending(x => x.AutorID));
            }
        }

        public IEnumerable<AutorModelView> ObtenerListaDtoPagina(int page, int size)
        {
            using (var dbContext = new WebContextDb())
            {
                return Automapper.GetGeneric<IEnumerable<Autor>, List<AutorModelView>>(dbContext.Autor.OrderByDescending(x => x.AutorID).Page(page, size));
            }
        }
        
        public Autor ObtenerPorId(int id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Autor.FirstOrDefault(p => p.AutorID == id);
            }
        }

        public int TotalCantidad()
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Autor.Count();
            }
        }
    }
}