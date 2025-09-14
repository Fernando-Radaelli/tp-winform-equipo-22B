namespace TPWinForm_Equipo22B
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.botonAnterior = new System.Windows.Forms.Button();
            this.botonSiguiente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(12, 47);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.Size = new System.Drawing.Size(599, 402);
            this.dgvArticulos.TabIndex = 0;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // pbImagen
            // 
            this.pbImagen.Location = new System.Drawing.Point(617, 75);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(384, 337);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 1;
            this.pbImagen.TabStop = false;
            // 
            // botonAnterior
            // 
            this.botonAnterior.Location = new System.Drawing.Point(617, 234);
            this.botonAnterior.Name = "botonAnterior";
            this.botonAnterior.Size = new System.Drawing.Size(27, 23);
            this.botonAnterior.TabIndex = 2;
            this.botonAnterior.Text = "<";
            this.botonAnterior.UseVisualStyleBackColor = true;
            this.botonAnterior.Click += new System.EventHandler(this.botonAnterior_Click);
            // 
            // botonSiguiente
            // 
            this.botonSiguiente.Location = new System.Drawing.Point(974, 234);
            this.botonSiguiente.Name = "botonSiguiente";
            this.botonSiguiente.Size = new System.Drawing.Size(27, 23);
            this.botonSiguiente.TabIndex = 3;
            this.botonSiguiente.Text = ">";
            this.botonSiguiente.UseVisualStyleBackColor = true;
            this.botonSiguiente.Click += new System.EventHandler(this.botonSiguiente_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 534);
            this.Controls.Add(this.botonSiguiente);
            this.Controls.Add(this.botonAnterior);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.dgvArticulos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Button botonAnterior;
        private System.Windows.Forms.Button botonSiguiente;
    }
}

