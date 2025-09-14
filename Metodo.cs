using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWinForm_Equipo22B
{
    internal class Metodo
    {   
        public List<Articulo> Listar()
        {
            List<Articulo> Lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando= new SqlCommand();
            SqlDataReader lectura;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id, Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria FROM ARTICULOS"; 
                comando.Connection=conexion;

                conexion.Open();
                lectura = comando.ExecuteReader();

                while (lectura.Read())
                {
                    Articulo aux =new Articulo();

                    aux.Id = (int)lectura["Id"];
                    aux.Codigo = (string)lectura["Codigo"];
                    aux.Nombre = (string)lectura["Nombre"];
                    aux.Descripcion = (string)lectura["Descripcion"];
                    aux.Precio = (decimal)lectura["Precio"];

                    aux.ListaImagenes = new List<Imagen>();
                    Lista.Add(aux);
                }
                lectura.Close();
                conexion.Close();

                foreach (var articulo in Lista)
                {
                    comando.CommandText = "SELECT Id, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@IdArticulo", articulo.Id);
                    conexion.Open();
                    SqlDataReader lecturaImagenes = comando.ExecuteReader();

                    while (lecturaImagenes.Read())
                    {
                        Imagen img = new Imagen();
                        img.Id = (int)lecturaImagenes["Id"];
                        img.ImagenURL = (string)lecturaImagenes["ImagenUrl"];
                        articulo.ListaImagenes.Add(img);
                    }
                    lecturaImagenes.Close();
                    conexion.Close();
                }

                return Lista;

                /*aux.ImagenUrlbase = new Imagen();
                if (lectura["ImagenURL"] is DBNull)
                {
                    aux.ImagenUrlbase.Id = 0;
                    aux.ImagenUrlbase.ImagenURL = "";
                }
                else
                {

                    aux.ImagenUrlbase.Id = (int)lectura["IdImg"];
                    aux.ImagenUrlbase.ImagenURL = (string)lectura["ImagenUrl"];
                }*/

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

