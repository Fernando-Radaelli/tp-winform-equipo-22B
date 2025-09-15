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
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Marca> ListarMarcas()
        {
            List<Marca> lista = new List<Marca>();
            SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            SqlCommand comando = new SqlCommand("SELECT Id, Descripcion FROM MARCAS", conexion);
            SqlDataReader lectura;

            try
            {
                conexion.Open();
                lectura = comando.ExecuteReader();
                while (lectura.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)lectura["Id"];
                    aux.Descripcion = (string)lectura["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            SqlCommand comando = new SqlCommand("SELECT Id, Descripcion FROM CATEGORIAS", conexion);
            SqlDataReader lectura;

            try
            {
                conexion.Open();
                lectura = comando.ExecuteReader();
                while (lectura.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)lectura["Id"];
                    aux.Descripcion = (string)lectura["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Agregar(Articulo nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;

               
                comando.CommandText = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) " +
                                      "VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)";

                
                comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                comando.Parameters.AddWithValue("@IdMarca", nuevo.Marca.Id); 
                comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.Id); 
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
       
    }
}

