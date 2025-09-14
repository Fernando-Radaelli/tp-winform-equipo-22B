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
        private List<Articulo> listaArticulos;
        private Articulo articuloSeleccionado;
        private int indiceImagenActual = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Metodo carga = new Metodo();
            listaArticulos = carga.Listar();
            dgvArticulos.DataSource = listaArticulos;
            if (listaArticulos != null && listaArticulos.Count > 0)
            {
                articuloSeleccionado = listaArticulos[0];
                MostrarImagen();
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                articuloSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                indiceImagenActual = 0; // resetear índice
                MostrarImagen();
            }
        }

        private void MostrarImagen()
        {
            if (articuloSeleccionado != null &&
                articuloSeleccionado.Imagenes != null &&
                articuloSeleccionado.Imagenes.Count > 0)
            {
                try
                {
                    string url = articuloSeleccionado.Imagenes[indiceImagenActual].ImagenUrl;
                    pbArticulos.Load(url);
                }
                catch
                {
                    pbArticulos.Image = null;
                }
            }
            else
            {
                pbArticulos.Image = null;
            }
        }
    }
}
