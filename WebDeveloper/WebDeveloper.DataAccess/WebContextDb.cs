using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class WebContextDb : DbContext
    {
        public WebContextDb() : base("WebDeveloperConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<LibroAutor> LibroAutor { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
