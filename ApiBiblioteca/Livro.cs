using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ApiBiblioteca
{
    public class Livro
    {
        public int isbn { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Genero { get; set; }


        

    }
}
