using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemons
{
    public partial class TelaPrincipal : Form
    {

        private IDAO<IPokemon> _pokemonDAO;

        public List<IPokemon> Pokemons { get; set; }

        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MoveForm(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.Size == Screen.PrimaryScreen.WorkingArea.Size)
            {

                this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width / 3, Screen.PrimaryScreen.WorkingArea.Height / 2);
            }


            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();

                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Gradient(object sender, PaintEventArgs e)
        {
           
                using (LinearGradientBrush brush = new LinearGradientBrush(((Control)sender).ClientRectangle,
                                                                   ((Control)sender).BackColor,
                                                                   Color.MidnightBlue,
                                                                   90F))
                {
                    e.Graphics.FillRectangle(brush, ((Control)sender).ClientRectangle);
                }
            
        }

        private void FormResize(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Panel))
            {
                ((Panel)sender).Invalidate();
            }

        }

        private void CloseForm(Object sender, EventArgs e)
        {

            this.Close();
        }
      
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(500);

                this.txtName.Invoke(new MethodInvoker(() =>
                {
                    if (txtName.Text.Length > 0)
                    {
                        if (!(txtName.Text == "Pesquisar ..."))
                            txtName.ForeColor = Color.Black;
                    }
                    else
                    {
                        if (txtName.Text.Trim() == "")
                            txtName.Text = "Pesquisar ...";
                            txtName.ForeColor = Color.WhiteSmoke;
                    }

                }));

            });
        }

        private void txtName_Click(object sender, EventArgs e)
        {

            txtName.Text = "";

        }

        private void txtName_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                if ((txtName.Text.Length - 1) == 0)
                {

                    txtName.Text = "Pesquisar ...";
                    txtName.ForeColor = Color.LightGray;
                }
            }
            else if (e.KeyCode == Keys.Enter) {

                pictureBox3_Click(new object(), new EventArgs());
            }
            else
            {
                if (txtName.Text.Length == 0)
                {

                    txtName.Text = "";
                    txtName.ForeColor = Color.Black;
                }
                else
                {

                    txtName.Text = txtName.Text.Replace("Pesquisar ...", "");

                }


            }
            
        }


        private async Task BuscarPokemos(string param = "1", bool show = true)
        {
            try
            {
                

                if (show)
                {
                    Pokemon pokemon = (Pokemon)await _pokemonDAO.BuscarAsync(param);

                    if (pokemon == null)
                    {
                        MessageBox.Show("Nada foi encontrado");
                    }
                    else
                    {
                        CarregarPokemon(pokemon);
                    }
                }
                else {

                    Pokemons = await _pokemonDAO.BuscarAsync();

                    if (Pokemons.Count > 0)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            label1.Text = $"Total : {Pokemons.Count} Pokemons";

                            label1.Visible = true;

                            CarregarPokemon(Pokemons[0]);
                        }));
                    }
                    else {

                        MessageBox.Show("Nenhum pokemon encontrado");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nennum pokemon encontrado");
            }
            
            
        }

        public void CarregarPokemon(IPokemon pokemon) {

            pnlContainer.Visible = true;

            dataGridView1.Visible = false;

            int idx = Pokemons.IndexOf(pokemon) + 1;

            lblLocation.Text = idx.ToString();            

            this.pnlContainer.Controls.Clear();

            lblLocation.Location = new Point((this.pnlControles.Width / 2) - (lblLocation.Width / 2), lblLocation.Location.Y);

            pnlContainer.Controls.Add(new CustomControls.TelaPokemonDetalhes(pokemon)
            {
                Dock = DockStyle.Fill
            });

        }

      
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "" && txtName.Text.Trim() != "Pesquisar ...")
            {

                _ = BuscarPokemos(txtName.Text, true);

            }
            else {
                MessageBox.Show("Informe um parametro de busca");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pnlContainer.Controls.Count > 0) {

                int atual = ((CustomControls.TelaPokemonDetalhes)pnlContainer.Controls[0]).Id;

                if (atual > Pokemons.Count) {
                    return;
                }

                CarregarPokemon(Pokemons[atual]);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pnlContainer.Controls.Count > 0)
            {

                int atual = ((CustomControls.TelaPokemonDetalhes)pnlContainer.Controls[0]).Id;

                if (atual == 1)
                {
                    return;
                }

                CarregarPokemon(Pokemons[atual - 2]);

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (!dataGridView1.Visible)
            {
                pnlContainer.Visible = false;
                dataGridView1.Visible = true;
                dataGridView1.BringToFront();
                dataGridView1.DataSource = Pokemons;
              
            }
            else {

                pnlContainer.Visible = true;
                dataGridView1.Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                IPokemon pk = (IPokemon)dataGridView1.SelectedRows[0].DataBoundItem;

                CarregarPokemon(pk);
            }
        }

        public TelaPrincipal()
        {
            InitializeComponent();

            _pokemonDAO = new PokemonDAO();

            _ = BuscarPokemos(show: false);

        }

    }
}
