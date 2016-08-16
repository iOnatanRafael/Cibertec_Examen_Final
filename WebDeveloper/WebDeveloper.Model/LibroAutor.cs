using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.Model
{
    public class LibroAutor
    {
        [Key]
        [Column("title_id", Order = 1)]
        public int LibroID { get; set; }

        [Key]
        [Column("au_id", Order = 2)]
        public int AutorID { get; set; }
   
        [StringLength(2)]
        [Column("au_ord")]
        public string AutorOrden { get; set; }

        [StringLength(2)]
        [Column("royaltyper")]
        public string TipoReal { get; set; }

    }
}
