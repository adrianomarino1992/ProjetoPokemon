using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons
{
    public interface IPokemon
    {
        string Id { get; set; }
        string Nome { get; set; }
        string Tipo { get; set; }
        string Foto { get; set; }        
    }
}
