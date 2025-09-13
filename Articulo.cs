using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TPWinForm_Equipo22B
{
    internal class Articulo
    {
            public int Id { get; set; }              // PK de la tabla ARTICULOS
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public Marca Marca { get; set; }         // Acá hay relación con MARCAS
            public Categoria Categoria { get; set; } // Acá hay relación con CATEGORIAS
            public decimal Precio { get; set; }
            public List<Imagen> Imagenes { get; set; } //Y acá hay relación con IMAGENES
        
    }
}
