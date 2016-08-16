using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;
using WebDeveloper.Model.DTO;

namespace WebDeveloper.DataAccess
{
    public class LibroRepository : BaseDataAccess<Libro>
    {
        public IEnumerable<LibroModelView> GetListDto()
        {
            using (var dbContext = new WebContextDb())
            {
                return Automapper.GetGeneric<IEnumerable<Libro>, List<LibroModelView>>(dbContext.Libro.OrderByDescending(x => x.FechaPublicacion));
            }
        }


        public IEnumerable<LibroModelView> GetListDtoPage(int page, int size)
        {
            using (var dbContext = new WebContextDb())
            {
                return Automapper.GetGeneric<IEnumerable<Libro>, List<LibroModelView>>(dbContext.Libro.OrderByDescending(x => x.LibroID).Page(page, size));
            }
        }

        public Libro GetById(int id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Libro.FirstOrDefault(p => p.LibroID == id);
            }
        }

        public int TotalCount()
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Libro.Count();
            }
        }
    }
}