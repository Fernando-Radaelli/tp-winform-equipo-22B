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
                comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, A.IdMarca, A.IdCategoria FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id JOIN CATEGORIAS C ON A.IdCategoria = C.Id";
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
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)lectura["IdMarca"];
                    aux.Marca.Descripcion = (string)lectura["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lectura["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lectura["Categoria"];
                    aux.ListaImagenes = new List<Imagen>();
                    Lista.Add(aux);
                }
                lectura.Close();


                foreach (var articulo in Lista)
                {
                    comando.CommandText = "SELECT Id, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@IdArticulo", articulo.Id);
                    SqlDataReader lecturaImagenes = comando.ExecuteReader();

                    while (lecturaImagenes.Read())
                    {
                        Imagen img = new Imagen();
                        img.Id = (int)lecturaImagenes["Id"];
                        img.ImagenURL = (string)lecturaImagenes["ImagenUrl"];
                        articulo.ListaImagenes.Add(img);
                    }
                    lecturaImagenes.Close();
                }
              
                return Lista;
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
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

        public int Agregar(Articulo nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;


                comando.CommandText = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) " +
                               "VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio);" +
                               "SELECT SCOPE_IDENTITY();";


                comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                comando.Parameters.AddWithValue("@IdMarca", nuevo.Marca.Id);
                comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.Id);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);

                comando.Connection = conexion;
                conexion.Open();

                return Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }          
        }

        public void Eliminar(int idArticulo)
        {
            SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.Open();              
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM IMAGENES WHERE IdArticulo = @IdArticulo";
                comando.Parameters.Clear(); 
                comando.Parameters.AddWithValue("@IdArticulo", idArticulo);
                comando.ExecuteNonQuery();
                comando.CommandText = "DELETE FROM ARTICULOS WHERE Id = @IdArticulo";
                
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@IdArticulo", idArticulo);
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
        public List<Articulo> filtrar(string campo, string criterio, string filtroAvanzado)
        {
            List<Articulo> listaArticulo = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio FROM ARTICULOS A JOIN MARCAS M ON A.IdMarca = M.Id JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE ";
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtroAvanzado;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtroAvanzado;
                            break;
                        default:
                            consulta += "Precio = " + filtroAvanzado;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Nombre like '" + filtroAvanzado + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Nombre like '%" + filtroAvanzado + "'";
                            break;
                        default:
                            consulta += "A.Nombre like '%" + filtroAvanzado + "%'";
                            break;
                    }
                }
                else if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Codigo like '" + filtroAvanzado + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Codigo like '%" + filtroAvanzado + "'";
                            break;
                        default:
                            consulta += "A.Codigo like '%" + filtroAvanzado + "%'";
                            break;
                    }
                }
                else if (campo == "Descripción")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Descripcion like '" + filtroAvanzado + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Descripcion like '%" + filtroAvanzado + "'";
                            break;
                        default:
                            consulta += "A.Descripcion like '%" + filtroAvanzado + "%'";
                            break;
                    }

                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtroAvanzado + "%' ";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + filtroAvanzado + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtroAvanzado + "%'";
                            break;
                    }
                }
                else if (campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtroAvanzado + "%' ";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtroAvanzado + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtroAvanzado + "%'";
                            break;
                    }
                }

                comando.CommandText = consulta;
                comando.Connection = conexion;
                conexion.Open();
                lectura = comando.ExecuteReader();

                while (lectura.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ListaImagenes = new List<Imagen>();
                    aux.Id = (int)lectura["Id"];
                    aux.Codigo = (string)lectura["Codigo"];
                    aux.Nombre = (string)lectura["Nombre"];
                    aux.Descripcion = (string)lectura["Descripcion"];
                    aux.Precio = (decimal)lectura["Precio"];


                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)lectura["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)lectura["Categoria"];

                    listaArticulo.Add(aux);
                }

                return listaArticulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }

        public void agregarImagen(Imagen nuevaImagen)
        {
            SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @imagenUrl)";
                comando.Parameters.AddWithValue("@idArticulo", nuevaImagen.IdArticulo);
                comando.Parameters.AddWithValue("@imagenUrl", nuevaImagen.ImagenURL);

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
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }

        public void Modificar(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE Id = @id";

                comando.Parameters.AddWithValue("@codigo", articulo.Codigo);
                comando.Parameters.AddWithValue("@nombre", articulo.Nombre);
                comando.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                comando.Parameters.AddWithValue("@idMarca", articulo.Marca.Id);
                comando.Parameters.AddWithValue("@idCategoria", articulo.Categoria.Id);
                comando.Parameters.AddWithValue("@precio", articulo.Precio);
                comando.Parameters.AddWithValue("@id", articulo.Id); 

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
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }

        public void EliminarImagenes(int idArticulo)
        {
            SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "DELETE FROM IMAGENES WHERE IdArticulo = @IdArticulo";
                comando.Parameters.AddWithValue("@IdArticulo", idArticulo);
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
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }

    }
}

