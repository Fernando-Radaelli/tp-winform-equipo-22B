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
            this.pbNuevoArticulo = new System.Windows.Forms.PictureBox();
            this.lblImagenNuevo = new System.Windows.Forms.Label();
            this.txtUrlNueva = new System.Windows.Forms.TextBox();
            this.botonModificarAnterior = new System.Windows.Forms.Button();
            this.botonModificarSiguiente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbNuevoArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(59, 61);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(118, 20);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código artículo:";
            // 
            // nombreNuevoArticulo
            // 
            this.nombreNuevoArticulo.AutoSize = true;
            this.nombreNuevoArticulo.Location = new System.Drawing.Point(59, 134);
            this.nombreNuevoArticulo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.nombreNuevoArticulo.Name = "nombreNuevoArticulo";
            this.nombreNuevoArticulo.Size = new System.Drawing.Size(124, 20);
            this.nombreNuevoArticulo.TabIndex = 1;
            this.nombreNuevoArticulo.Text = "Nombre artículo:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(59, 239);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(112, 20);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "Precio artículo:";
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(57, 492);
            this.botonAceptar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(125, 35);
            this.botonAceptar.TabIndex = 7;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(336, 492);
            this.botonCancelar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(125, 35);
            this.botonCancelar.TabIndex = 8;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(190, 61);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(266, 26);
            this.txtCodigo.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(190, 129);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(266, 26);
            this.txtNombre.TabIndex = 1;
            // 
            // txtPrecioArticulo
            // 
            this.txtPrecioArticulo.Location = new System.Drawing.Point(192, 235);
            this.txtPrecioArticulo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtPrecioArticulo.Name = "txtPrecioArticulo";
            this.txtPrecioArticulo.Size = new System.Drawing.Size(266, 26);
            this.txtPrecioArticulo.TabIndex = 3;
            // 
            // lblComboBoxMarca
            // 
            this.lblComboBoxMarca.AutoSize = true;
            this.lblComboBoxMarca.Location = new System.Drawing.Point(59, 340);
            this.lblComboBoxMarca.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblComboBoxMarca.Name = "lblComboBoxMarca";
            this.lblComboBoxMarca.Size = new System.Drawing.Size(137, 20);
            this.lblComboBoxMarca.TabIndex = 8;
            this.lblComboBoxMarca.Text = "Marca del artículo:";
            // 
            // lblComboBoxCategoria
            // 
            this.lblComboBoxCategoria.AutoSize = true;
            this.lblComboBoxCategoria.Location = new System.Drawing.Point(59, 398);
            this.lblComboBoxCategoria.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblComboBoxCategoria.Name = "lblComboBoxCategoria";
            this.lblComboBoxCategoria.Size = new System.Drawing.Size(162, 20);
            this.lblComboBoxCategoria.TabIndex = 9;
            this.lblComboBoxCategoria.Text = "Categoría del artículo:";
            // 
            // comboBoxMarca
            // 
            this.comboBoxMarca.FormattingEnabled = true;
            this.comboBoxMarca.Location = new System.Drawing.Point(239, 335);
            this.comboBoxMarca.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBoxMarca.Name = "comboBoxMarca";
            this.comboBoxMarca.Size = new System.Drawing.Size(219, 28);
            this.comboBoxMarca.TabIndex = 5;
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(242, 394);
            this.comboBoxCategoria.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(215, 28);
            this.comboBoxCategoria.TabIndex = 6;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(59, 189);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(96, 20);
            this.lblDescripcion.TabIndex = 12;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(190, 184);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(266, 26);
            this.txtDescripcion.TabIndex = 2;
            // 
            // pbNuevoArticulo
            // 
            this.pbNuevoArticulo.Location = new System.Drawing.Point(517, 112);
            this.pbNuevoArticulo.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pbNuevoArticulo.Name = "pbNuevoArticulo";
            this.pbNuevoArticulo.Size = new System.Drawing.Size(345, 306);
            this.pbNuevoArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNuevoArticulo.TabIndex = 14;
            this.pbNuevoArticulo.TabStop = false;
            // 
            // lblImagenNuevo
            // 
            this.lblImagenNuevo.AutoSize = true;
            this.lblImagenNuevo.Location = new System.Drawing.Point(62, 286);
            this.lblImagenNuevo.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblImagenNuevo.Name = "lblImagenNuevo";
            this.lblImagenNuevo.Size = new System.Drawing.Size(111, 20);
            this.lblImagenNuevo.TabIndex = 15;
            this.lblImagenNuevo.Text = "Url de imagen:";
            // 
            // txtUrlNueva
            // 
            this.txtUrlNueva.Location = new System.Drawing.Point(189, 286);
            this.txtUrlNueva.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtUrlNueva.Name = "txtUrlNueva";
            this.txtUrlNueva.Size = new System.Drawing.Size(268, 26);
            this.txtUrlNueva.TabIndex = 4;
            this.txtUrlNueva.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // botonModificarAnterior
            // 
            this.botonModificarAnterior.Location = new System.Drawing.Point(517, 249);
            this.botonModificarAnterior.Name = "botonModificarAnterior";
            this.botonModificarAnterior.Size = new System.Drawing.Size(36, 36);
            this.botonModificarAnterior.TabIndex = 16;
            this.botonModificarAnterior.Text = "<";
            this.botonModificarAnterior.UseVisualStyleBackColor = true;
            this.botonModificarAnterior.Click += new System.EventHandler(this.botonModificarAnterior_Click);
            // 
            // botonModificarSiguiente
            // 
            this.botonModificarSiguiente.Location = new System.Drawing.Point(827, 249);
            this.botonModificarSiguiente.Name = "botonModificarSiguiente";
            this.botonModificarSiguiente.Size = new System.Drawing.Size(35, 36);
            this.botonModificarSiguiente.TabIndex = 17;
            this.botonModificarSiguiente.Text = ">";
            this.botonModificarSiguiente.UseVisualStyleBackColor = true;
            this.botonModificarSiguiente.Click += new System.EventHandler(this.botonModificarSiguiente_Click);
            // 
            // frmGestionArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 562);
            this.Controls.Add(this.botonModificarSiguiente);
            this.Controls.Add(this.botonModificarAnterior);
            this.Controls.Add(this.txtUrlNueva);
            this.Controls.Add(this.lblImagenNuevo);
            this.Controls.Add(this.pbNuevoArticulo);
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
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmGestionArticulo";
            this.Text = "Agregar artículo";
            this.Load += new System.EventHandler(this.frmGestionArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNuevoArticulo)).EndInit();
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
        private System.Windows.Forms.PictureBox pbNuevoArticulo;
        private System.Windows.Forms.Label lblImagenNuevo;
        private System.Windows.Forms.TextBox txtUrlNueva;
        private System.Windows.Forms.Button botonModificarAnterior;
        private System.Windows.Forms.Button botonModificarSiguiente;
    }
}