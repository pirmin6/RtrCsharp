namespace Vue
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChefRang);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MaitreHotel);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Client);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Serveur);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Table);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Table2);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Table3);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

