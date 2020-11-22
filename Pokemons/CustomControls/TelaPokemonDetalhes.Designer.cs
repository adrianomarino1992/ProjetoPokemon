namespace Pokemons.CustomControls
{
    partial class TelaPokemonDetalhes
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptbFoto = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDetalhes = new System.Windows.Forms.Panel();
            this.lblNome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFoto)).BeginInit();
            this.pnlDetalhes.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbFoto
            // 
            this.ptbFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbFoto.Location = new System.Drawing.Point(25, 28);
            this.ptbFoto.Name = "ptbFoto";
            this.ptbFoto.Size = new System.Drawing.Size(330, 289);
            this.ptbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbFoto.TabIndex = 0;
            this.ptbFoto.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(355, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 289);
            this.panel1.TabIndex = 1;
            // 
            // pnlDetalhes
            // 
            this.pnlDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalhes.AutoScroll = true;
            this.pnlDetalhes.Controls.Add(this.lblNome);
            this.pnlDetalhes.Location = new System.Drawing.Point(363, 28);
            this.pnlDetalhes.Name = "pnlDetalhes";
            this.pnlDetalhes.Size = new System.Drawing.Size(327, 289);
            this.pnlDetalhes.TabIndex = 2;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(121, 15);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(96, 30);
            this.lblNome.TabIndex = 7;
            this.lblNome.Text = "Pokemon";
            // 
            // TelaPokemonDetalhes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pnlDetalhes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ptbFoto);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "TelaPokemonDetalhes";
            this.Size = new System.Drawing.Size(715, 344);
            ((System.ComponentModel.ISupportInitialize)(this.ptbFoto)).EndInit();
            this.pnlDetalhes.ResumeLayout(false);
            this.pnlDetalhes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbFoto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDetalhes;
        private System.Windows.Forms.Label lblNome;
    }
}
