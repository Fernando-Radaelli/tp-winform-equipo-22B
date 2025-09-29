using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace TPWinForm_Equipo22B
{
    public partial class Form1 : Form
    {

        private List<Articulo> listaArticulo;
        private int indiceImagenActual = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
            dgvArticulos.BackgroundColor = Color.White;
            dgvArticulos.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvArticulos.EnableHeadersVisualStyles = false;
            dgvArticulos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            Metodo carga = new Metodo();
            listaArticulo = carga.Listar();
            dgvArticulos.DataSource = listaArticulo; 
            dgvArticulos.Columns["id"].Visible = false; 
            dgvArticulos.Columns["Marca"].Visible = false;
            dgvArticulos.Columns["Categoria"].Visible = false;

            dgvArticulos.Columns["nombreMarca"].HeaderText = "Marca";
            dgvArticulos.Columns["nombreCategoria"].HeaderText = "Categoría";

            cargarDatos();
            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");
            cboCampo.Items.Add("Precio");
        }



        private void cargarImagen(string imagen)
        {
            try
            {
                pbImagen.Load(imagen);
            }
            catch (Exception ex)
            {

                pbImagen.Load("https://cdn-icons-png.flaticon.com/512/13434/13434972.png");


            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            // Acá verifico si hay una fiula seleccionada
            if (dgvArticulos.CurrentRow != null)
            {
                try
                {
                    indiceImagenActual = 0;

                    Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                    if (seleccionado.ListaImagenes != null && seleccionado.ListaImagenes.Count > 0)
                    {
                        cargarImagen(seleccionado.ListaImagenes[indiceImagenActual].ImagenURL);
                    }
                    else
                    {

                        cargarImagen("https://cdn-icons-png.flaticon.com/512/13434/13434972.png");
                    }
                }
                catch (Exception)
                {
                    cargarImagen("https://cdn-icons-png.flaticon.com/512/13434/13434972.png");
                }
            }
        }

        private void botonAnterior_Click(object sender, EventArgs e)
        {
            Articulo seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            if (seleccion.ListaImagenes.Count > 1)
            {
                indiceImagenActual--;
                if (indiceImagenActual < 0)
                {
                    indiceImagenActual = seleccion.ListaImagenes.Count - 1;
                }
                cargarImagen(seleccion.ListaImagenes[indiceImagenActual].ImagenURL);
            }
        }

        private void botonSiguiente_Click(object sender, EventArgs e)
        {
            Articulo seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            if (seleccion.ListaImagenes.Count > 1)
            {
                indiceImagenActual++;
                if (indiceImagenActual >= seleccion.ListaImagenes.Count)
                {
                    indiceImagenActual = 0;
                }
                cargarImagen(seleccion.ListaImagenes[indiceImagenActual].ImagenURL);
            }
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            frmGestionArticulo altaArticulo = new frmGestionArticulo();
            altaArticulo.ShowDialog();
            cargarDatos();
        }

        private void cargarDatos()
        {
            Metodo carga = new Metodo();
            listaArticulo = carga.Listar();
            dgvArticulos.DataSource = listaArticulo;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas eliminar este artículo de forma permanente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {

                    Articulo articuloAEliminar = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                    Metodo metodo = new Metodo();
                    try
                    {
                        metodo.Eliminar(articuloAEliminar.Id);
                        MessageBox.Show("Artículo eliminado exitosamente.");
                        cargarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al intentar eliminar el artículo: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un artículo de la lista para eliminarlo.");
            }
        }


        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listafiltrada;
            string filtro = txtFiltro.Text;

            if (filtro != "")
            {

                listafiltrada = listaArticulo.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()));

            }
            else
            {
                listafiltrada = listaArticulo;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listafiltrada;

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
            cboCriterio.SelectedIndex = 0;
        }

        private void botonFiltro_Click(object sender, EventArgs e)
        {
            Metodo metodo = new Metodo();



            if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
            {
                cargarDatos();
                return;
            }

            try
            {
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtroAvanzado = txtFiltroAvanzado.Text;
                listaArticulo = metodo.filtrar(campo, criterio, filtroAvanzado);
                dgvArticulos.DataSource = listaArticulo;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            
            try
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmGestionArticulo modificar = new frmGestionArticulo(seleccionado);
                modificar.Text = "Modificar Artículo";
                modificar.ShowDialog();
                cargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar modificar el artículo: " + ex.Message);

            }

        }
    
    }
}
    
   

