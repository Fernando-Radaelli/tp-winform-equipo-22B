namespace TPWinForm_Equipo22B
{
    partial class frmGestionArticulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.nombreNuevoArticulo = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPrecioArticulo = new System.Windows.Forms.TextBox();
            this.lblComboBoxMarca = new System.Windows.Forms.Label();
            this.lblComboBoxCategoria = new System.Windows.Forms.Label();
            this.comboBoxMarca = new System.Windows.Forms.ComboBox();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(39, 73);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(82, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código artículo:";
            // 
            // nombreNuevoArticulo
            // 
            this.nombreNuevoArticulo.AutoSize = true;
            this.nombreNuevoArticulo.Location = new System.Drawing.Point(39, 120);
            this.nombreNuevoArticulo.Name = "nombreNuevoArticulo";
            this.nombreNuevoArticulo.Size = new System.Drawing.Size(86, 13);
            this.nombreNuevoArticulo.TabIndex = 1;
            this.nombreNuevoArticulo.Text = "Nombre artículo:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(39, 189);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(79, 13);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "Precio artículo:";
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(38, 320);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(83, 23);
            this.botonAceptar.TabIndex = 3;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(224, 320);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(83, 23);
            this.botonCancelar.TabIndex = 4;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(127, 73);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(179, 20);
            this.txtCodigo.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(127, 117);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(179, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // txtPrecioArticulo
            // 
            this.txtPrecioArticulo.Location = new System.Drawing.Point(128, 186);
            this.txtPrecioArticulo.Name = "txtPrecioArticulo";
            this.txtPrecioArticulo.Size = new System.Drawing.Size(179, 20);
            this.txtPrecioArticulo.TabIndex = 7;
            // 
            // lblComboBoxMarca
            // 
            this.lblComboBoxMarca.AutoSize = true;
            this.lblComboBoxMarca.Location = new System.Drawing.Point(39, 221);
            this.lblComboBoxMarca.Name = "lblComboBoxMarca";
            this.lblComboBoxMarca.Size = new System.Drawing.Size(96, 13);
            this.lblComboBoxMarca.TabIndex = 8;
            this.lblComboBoxMarca.Text = "Marca del artículo:";
            // 
            // lblComboBoxCategoria
            // 
            this.lblComboBoxCategoria.AutoSize = true;
            this.lblComboBoxCategoria.Location = new System.Drawing.Point(39, 259);
            this.lblComboBoxCategoria.Name = "lblComboBoxCategoria";
            this.lblComboBoxCategoria.Size = new System.Drawing.Size(113, 13);
            this.lblComboBoxCategoria.TabIndex = 9;
            this.lblComboBoxCategoria.Text = "Categoría del artículo:";
            // 
            // comboBoxMarca
            // 
            this.comboBoxMarca.FormattingEnabled = true;
            this.comboBoxMarca.Location = new System.Drawing.Point(159, 218);
            this.comboBoxMarca.Name = "comboBoxMarca";
            this.comboBoxMarca.Size = new System.Drawing.Size(147, 21);
            this.comboBoxMarca.TabIndex = 10;
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(161, 256);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(145, 21);
            this.comboBoxCategoria.TabIndex = 11;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(39, 156);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 12;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(127, 153);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(179, 20);
            this.txtDescripcion.TabIndex = 13;
            // 
            // frmGestionArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 365);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.comboBoxCategoria);
            this.Controls.Add(this.comboBoxMarca);
            this.Controls.Add(this.lblComboBoxCategoria);
            this.Controls.Add(this.lblComboBoxMarca);
            this.Controls.Add(this.txtPrecioArticulo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.nombreNuevoArticulo);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmGestionArticulo";
            this.Text = "Agregar artículo";
            this.Load += new System.EventHandler(this.frmGestionArticulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label nombreNuevoArticulo;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrecioArticulo;
        private System.Windows.Forms.Label lblComboBoxMarca;
        private System.Windows.Forms.Label lblComboBoxCategoria;
        private System.Windows.Forms.ComboBox comboBoxMarca;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}