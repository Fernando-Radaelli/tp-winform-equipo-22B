using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWinForm_Equipo22B
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }

        public string ImagenURL { get; set; }

        public override string ToString()
        {
            return ImagenURL;
        }
    }
}
