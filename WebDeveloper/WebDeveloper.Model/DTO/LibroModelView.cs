using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.Model.DTO
{
    public class LibroModelView
    {
        public int LibroID { get; set; }

        [StringLength(70)]
        public string Titulo { get; set; }
    }
}
