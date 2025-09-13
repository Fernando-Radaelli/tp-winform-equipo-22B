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
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando= new SqlCommand();
            SqlDataReader lectura;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Codigo, Nombre, Descripcion, idMarca, Precio from ARTICULOS"; 
                comando.Connection=conexion;

                conexion.Open();
                lectura = comando.ExecuteReader();

                while (lectura.Read())
                {
                    Articulo aux =new Articulo();
                    aux.Codigo = (string)lectura["Codigo"];
                    aux.Nombre = (string)lectura["Nombre"];
                    aux.Descripcion = (string)lectura["Descripcion"];
                    aux.Id = (int)lectura["idMarca"];
                    aux.Precio = (decimal)lectura["Precio"];

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

    }
}

