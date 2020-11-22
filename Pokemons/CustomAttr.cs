using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomAttr : Attribute
    {
        public string JsonPropertieName { get; set; }
    }
}
