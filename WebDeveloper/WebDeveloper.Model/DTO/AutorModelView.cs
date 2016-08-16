using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.Model.DTO
{
    public class AutorModelView
    {
        public int AutorID { get; set; }

        [StringLength(50)]
        public string Nombres { get; set; }

        [StringLength(50)]
        public string Apellidos { get; set; }
    }
}
