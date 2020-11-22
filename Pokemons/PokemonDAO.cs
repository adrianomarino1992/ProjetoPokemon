using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Reflection;
using System.Windows.Forms;

namespace Pokemons
{
    public class PokemonDAO : IDAO<IPokemon>
    {
        private HttpClient _client = new HttpClient();

        private List<IPokemon> _pokemons;       

        public static Dictionary<string, object> ResponseAsyncDictionary = null;

        private JavaScriptSerializer js = new JavaScriptSerializer();
        public async Task<object> Get(string url)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string text = await response.Content.ReadAsStringAsync();

                    return js.DeserializeObject(text);

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public object Buscar(object id)
        {
            throw new NotImplementedException();
        }

      

        public async Task<List<IPokemon>> BuscarAsync()
        {

            string url = ConfigurationManager.AppSettings["ApiPokemon"];

            if (url == null)
            {
                System.Windows.Forms.MessageBox.Show("Chave não encontrada no AppSettings");

                _pokemons = new List<IPokemon>();
            }             

            if (_pokemons == null)
            {
                _pokemons = new List<IPokemon>();

                object result = await Get(url);

                if (result.GetType() == typeof(bool))
                {

                    throw new Exception("Nada foi encontrado");
                }

                List<IPokemon> lPokemons = new List<IPokemon>();


                Dictionary<string, object> data = (Dictionary<string, object>)result;

                foreach (object[] pokemons in data.Values)
                {

                    foreach (object pokemon in pokemons)
                    {
                        Dictionary<string, object> pokemonObj = (Dictionary<string, object>)pokemon;

                        Pokemon pk = new Pokemon();

                        foreach (PropertyInfo pi in typeof(Pokemon).GetProperties())
                        {
                            CustomAttr jsonProperty = (CustomAttr)pi.GetCustomAttribute(typeof(CustomAttr));

                            var content = pokemonObj[jsonProperty.JsonPropertieName];

                            if (content.GetType() == typeof(object[]))
                            {

                                object[] enums = (object[])content;

                                pi.SetValue(pk, enums[0].ToString());

                            }
                            else
                            {

                                pi.SetValue(pk, content.ToString());

                            }


                        }

                        _pokemons.Add(pk);

                    }

                }

            }

            return _pokemons;

        }
            

        async Task<object> IDAO<IPokemon>.BuscarAsync(object id)
        {
            Pokemon pokemonresult = null;

            if (_pokemons == null)
                _pokemons = await BuscarAsync();

            pokemonresult =
                   (
                   from Pokemon p in _pokemons
                   where p.Id.ToLower() == id.ToString().ToLower() || p.Nome.ToLower().Contains(id.ToString().ToLower())
                   select p
                   ).First();

            return pokemonresult;
        }

        public List<IPokemon> Buscar()
        {
            throw new NotImplementedException();
        }
    }
}
