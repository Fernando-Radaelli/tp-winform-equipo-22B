using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace TPWinForm_Equipo22B
{
    internal class Metodo
    {   
        public List<Articulo> Listar()
        {
            List<Articulo> Lista = new List<Articulo>();
            List<Imagen> todasImagenes = ListarTodasImagenes();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando= new SqlCommand();
            SqlDataReader lectura;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id, Codigo, Nombre, Descripcion, idMarca, Precio FROM ARTICULOS"; 
                comando.Connection=conexion;

                conexion.Open();
                lectura = comando.ExecuteReader();

                while (lectura.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lectura["Id"];
                    aux.Codigo = (string)lectura["Codigo"];
                    aux.Nombre = (string)lectura["Nombre"];
                    aux.Descripcion = (string)lectura["Descripcion"];
                    aux.Marca = new Marca { Idmarca = (int)lectura["idMarca"] };
                    aux.Precio = (decimal)lectura["Precio"];

                    // Asignar imágenes desde la lista precargada
                    aux.Imagenes = todasImagenes.FindAll(img => img.IdArticulo == aux.Id);


                    Lista.Add(aux);
                }
                conexion.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Imagen> ListarTodasImagenes()
        {
            List<Imagen> lista = new List<Imagen>();
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
            using (SqlCommand comando = new SqlCommand("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES", conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Imagen img = new Imagen();
                        img.Id = (int)lector["Id"];
                        img.IdArticulo = (int)lector["IdArticulo"];
                        img.ImagenUrl = (string)lector["ImagenUrl"];
                        lista.Add(img);
                    }
                }
            }

            return lista;
        }

    }
}

