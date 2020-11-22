using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons
{
    public class Pokemon : IPokemon
    {
        [CustomAttr(JsonPropertieName = "id")]
        public string Id { get; set; }

        [CustomAttr(JsonPropertieName = "name")]
        public string Nome { get; set; }

        [CustomAttr(JsonPropertieName = "type")]
        public string Tipo { get; set; }

        [CustomAttr(JsonPropertieName = "img")]
        public string Foto { get; set; }

        [CustomAttr(JsonPropertieName = "height")]
        public string Tamanho { get; set; }

        [CustomAttr(JsonPropertieName = "weight")]
        public string Peso { get; set; }

        [CustomAttr(JsonPropertieName = "num")]
        public string Numero { get; set; }
    }
}
