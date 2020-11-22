using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons
{
    public interface IDAO<T>
    {
        object Buscar(object id);
        List<T> Buscar();
        Task<List<T>> BuscarAsync();
        Task<object> BuscarAsync(object id);

    }
}
