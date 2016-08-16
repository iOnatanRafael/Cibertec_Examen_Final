using System.Collections.Generic;

namespace WebDeveloper.DataAccess
{
    public interface IAccesoDatos<T>
    {
        List<T> ObtenerLista();
        int Adicionar(T entity);
        int Eliminar(T entity);
        int Actualizar(T entity);        
        int Contar();
    }
}
