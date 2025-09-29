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
        private Articulo articulo = null;
        private int indiceImagenActual = 0;

        public frmGestionArticulo()
        {
            InitializeComponent();
            ConfigurarEstilos();
        }

        public frmGestionArticulo(Articulo articuloSeleccionado)
        {
            InitializeComponent();
            this.articulo = articuloSeleccionado;
            Text = "Modificar Artículo";
            ConfigurarEstilos();
        }

        private void ConfigurarEstilos()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);

            txtCodigo.Font = new Font("Segoe UI", 9);
            txtNombre.Font = new Font("Segoe UI", 9);

            botonAceptar.BackColor = Color.FromArgb(76, 175, 80); 
            botonAceptar.ForeColor = Color.White;
            botonAceptar.FlatStyle = FlatStyle.Flat;
            botonAceptar.FlatAppearance.BorderSize = 0;

        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            Metodo metodo = new Metodo();

            try
            {
                if (articulo == null)
                {
                    articulo = new Articulo();
                }

                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("El campo Código es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El campo Nombre es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (!string.IsNullOrWhiteSpace(txtPrecioArticulo.Text))
                {
                    if (!decimal.TryParse(txtPrecioArticulo.Text, out decimal precio))
                    {
                        MessageBox.Show("El Precio debe ser un valor numérico válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (precio < 0)
                    {
                        MessageBox.Show("El Precio no puede ser negativo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                 
                    if (precio == 0)
                    {
                        MessageBox.Show("El Precio debe ser mayor a $0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    articulo.Precio = precio;
                }
                else
                {

                    MessageBox.Show("El campo Precio es obligatorio y debe ser mayor a $0.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idArticulo = articulo.Id; 

                if (metodo.VerificarCodigoExistente(txtCodigo.Text, idArticulo))
                {
                    MessageBox.Show("El Código ingresado ya pertenece a otro artículo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;


                articulo.Marca = new Marca();
                articulo.Marca.Id = (int)comboBoxMarca.SelectedValue;

                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = (int)comboBoxCategoria.SelectedValue;


                if (articulo.Id != 0)
                {

                    metodo.Modificar(articulo);
                }
                else
                {

                    int idNuevoArticulo = metodo.Agregar(articulo);
                    articulo.Id = idNuevoArticulo;
                }


                foreach (string url in lsbImagenes.Items)
                {
                    Imagen imagen = new Imagen();
                    imagen.IdArticulo = articulo.Id;
                    imagen.ImagenURL = url.ToString(); 
                    metodo.agregarImagen(imagen);
                }

                MessageBox.Show("Operación realizada con éxito.");
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

            if (articulo != null)
            {
                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtPrecioArticulo.Text = articulo.Precio.ToString();

                comboBoxMarca.SelectedValue = articulo.Marca.Id;
                comboBoxCategoria.SelectedValue = articulo.Categoria.Id;

                if (articulo.ListaImagenes != null && articulo.ListaImagenes.Count > 0)
                {
                    lsbImagenes.Items.Clear();
                    foreach (var imagen in articulo.ListaImagenes)
                    {
                        lsbImagenes.Items.Add(imagen.ImagenURL);
                    }

                    cargarImagen(articulo.ListaImagenes[0].ImagenURL);
                }
            }


        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlNueva.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbNuevoArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbNuevoArticulo.Load("https://cdn-icons-png.flaticon.com/512/13434/13434972.png");


            }
        }

        private void botonModificarAnterior_Click(object sender, EventArgs e)
        {
            if (articulo.ListaImagenes.Count > 1)
            {
                indiceImagenActual--;
                if (indiceImagenActual < 0)
                {
                    indiceImagenActual = articulo.ListaImagenes.Count - 1; 
                }
                cargarImagen(articulo.ListaImagenes[indiceImagenActual].ImagenURL);
                txtUrlNueva.Text = articulo.ListaImagenes[indiceImagenActual].ImagenURL;
            }
        }

        private void botonModificarSiguiente_Click(object sender, EventArgs e)
        {
            if (articulo.ListaImagenes.Count > 1)
            {
                indiceImagenActual++;
                if (indiceImagenActual >= articulo.ListaImagenes.Count)
                {
                    indiceImagenActual = 0; 
                }
                cargarImagen(articulo.ListaImagenes[indiceImagenActual].ImagenURL);
                txtUrlNueva.Text = articulo.ListaImagenes[indiceImagenActual].ImagenURL;
            }
        }

        private void btnAgregarUrl_Click(object sender, EventArgs e)
        {
            string url = txtUrlNueva.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Por favor, ingrese una URL válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lsbImagenes.Items.Add(url);
            txtUrlNueva.Clear(); 


            cargarImagen(url);
        }

        private void btnEliminarUrl_Click(object sender, EventArgs e)
        {
            if (lsbImagenes.SelectedItem != null)
            {

                lsbImagenes.Items.Remove(lsbImagenes.SelectedItem);


                if (lsbImagenes.Items.Count > 0)
                {
                    cargarImagen(lsbImagenes.Items[0].ToString());
                }
                else
                {

                    cargarImagen("");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una URL de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lsbImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbImagenes.SelectedItem != null)
            {
                string urlSeleccionada = lsbImagenes.SelectedItem.ToString();
                cargarImagen(urlSeleccionada);
            }
        }
    }
}
