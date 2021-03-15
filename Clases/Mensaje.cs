using System;
using System.Collections.Generic;
using System.Text;

namespace PoorLamport.Clases
{
    public class Mensaje
    {
        public Proceso Origen { get; set; }
        public Proceso Destino { get; set; }
        public int Tiempo { get; set; }
        public string Contenido { get; set; }
    }
}
