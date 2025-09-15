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
            Metodo carga = new Metodo();
            listaArticulo = carga.Listar();
            dgvArticulos.DataSource = listaArticulo;    
            dgvArticulos.Columns["Marca"].Visible = false;
            dgvArticulos.Columns["Categoria"].Visible = false;
            cargarDatos();
        }

        

        private void cargarImagen(string imagen) // carga imagen o coloca una por default..
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

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e) // funcion al momento de cambiar de fila en el DataGridView
        {
            if (dgvArticulos.CurrentRow != null)
            {
                indiceImagenActual = 0; // Reinicia el índice al cambiar de artículo
                Articulo seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                if (seleccion.ListaImagenes.Count > 0)
                {
                    cargarImagen(seleccion.ListaImagenes[indiceImagenActual].ImagenURL);
                }
                else
                {
                    // Cargar imagen por defecto si no hay imágenes asociadas
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
                    indiceImagenActual = seleccion.ListaImagenes.Count - 1; // Vuelve al final si llega al principio
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
                    indiceImagenActual = 0; // Vuelve al principio si llega al final
                }
                cargarImagen(seleccion.ListaImagenes[indiceImagenActual].ImagenURL);
            }
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            frmGestionArticulo altaArticulo = new frmGestionArticulo();
            altaArticulo.ShowDialog();
        }

        private void cargarDatos()
        {
            Metodo carga = new Metodo();
            listaArticulo = carga.Listar();
            dgvArticulos.DataSource = listaArticulo;
            dgvArticulos.Columns["Marca"].Visible = false;
            dgvArticulos.Columns["Categoria"].Visible = false;
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


    }
   
}
