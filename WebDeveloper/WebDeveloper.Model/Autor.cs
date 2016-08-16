using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.Model
{
    public class Autor
    {
        [Key]
        [Column("AutorID")]
        public int AutorID { get;  set; }

        [Required]
        [StringLength(50)]
        [Column("au_lName")]
        public string Nombres { get;  set; }

        [Required]
        [StringLength(50)]
        [Column("au_fName")]
        public string Apellidos { get;  set; }

        [Required]
        [StringLength(15)]
        [Column("au_phone")]
        public string Telefono  { get;  set; }

        [Required]
        [StringLength(20)]
        [Column("au_city")]
        public string Ciudad { get;  set; }

        [Required]
        [StringLength(20)]
        [Column("au_state")]
        public string Estado  { get;  set; }

        [Required]
        [StringLength(10)]
        [Column("au_zip")]
        public string CodigoPostal { get;  set; }

        [Required]
        [StringLength(1)]
        [Column("au_sex")]
        public string Sexo { get;  set; }

        [Required]
        [Column("au_salary")]
        public decimal Salario { get;  set; }

        [Column("au_subject")]
        public bool DerechoAutor  { get;  set; }
    }
}
