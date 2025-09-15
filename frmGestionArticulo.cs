using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm_Equipo22B
{
    public partial class frmGestionArticulo : Form
    {
        public frmGestionArticulo()
        {
            InitializeComponent();
        }



        private void botonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            Metodo metodo = new Metodo();
            try
            {
                nuevo.Codigo=txtCodigo.Text;    
                nuevo.Nombre=txtNombre.Text;
                nuevo.Descripcion=txtDescripcion.Text;
                if (!string.IsNullOrEmpty(txtPrecioArticulo.Text))
                {
                    nuevo.Precio = decimal.Parse(txtPrecioArticulo.Text);
                }
                else
                {
                    nuevo.Precio = 0; 
                }
                nuevo.Marca=(Marca)comboBoxMarca.SelectedItem;
                nuevo.Categoria = (Categoria)comboBoxCategoria.SelectedItem;

                metodo.Agregar(nuevo);

                MessageBox.Show("Artículo agregado exitosamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmGestionArticulo_Load(object sender, EventArgs e)
        {
            Metodo metodo = new Metodo();

            // Aca cargo las marcas en el combobox
            try
            {
                comboBoxMarca.DataSource = metodo.ListarMarcas();
                comboBoxMarca.ValueMember = "Id";
                comboBoxMarca.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // Y aca las categorias 
            try
            {
                comboBoxCategoria.DataSource = metodo.ListarCategorias();
                comboBoxCategoria.ValueMember = "Id";
                comboBoxCategoria.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
