using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.Model
{
    public class Libro
    {
        [Key]
        [Column("title_id")]
        public int LibroID {get; set;}

        [Required]
        [StringLength(70)]
        [Column("title")]
        public string Titulo { get;  set; }

        [Required]
        [StringLength(2)]
        [Column("type")]
        public string Tipo { get;  set; }

        [Required]
        [Column("pub_id")]
        public int PublicacionID { get;  set; }

        [Column("advance")]
        public bool Avance { get;  set; }

        [Required]
        [Column("ytd_sales")]
        public int AñoVenta  { get;  set; }

        [StringLength(100)]
        [Column("notes")]
        public string Nota { get;  set; }

        [Column("pubdate")]
        public DateTime FechaPublicacion { get;  set; }

    }
}
