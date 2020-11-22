using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Pokemons.CustomControls
{
    public partial class TelaPokemonDetalhes : UserControl
    {
        public int Id { get; set; }
        public TelaPokemonDetalhes(IPokemon pokemon)
        {
            InitializeComponent();

            Id = Convert.ToInt32(pokemon.Id);

            this.lblNome.Text = pokemon.Nome;

            foreach (PropertyInfo pi in pokemon.GetType().GetProperties()) {


                if (pi.Name != "Nome" && pi.Name != "Foto") {

                    pnlDetalhes.Controls.Add(new Label()
                    {
                        Text = $"{pi.Name} : {pi.GetValue(pokemon).ToString()}",
                        Location = new Point(20, 30 + ((pnlDetalhes.Controls.Count) * 30)),
                        Font = new Font(lblNome.Font.FontFamily, 10),
                        Size = new Size(pnlDetalhes.Size.Width - 30, 30)
                        
                    });
                
                }

            }

            this.ptbFoto.Load(pokemon.Foto);
        }
    }
}
