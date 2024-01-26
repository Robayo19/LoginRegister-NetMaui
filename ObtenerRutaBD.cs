using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaRealRobayoJose_DI
{
    public class ObtenerRutaBD
    {
        public static String devolverRuta(String nombreBD)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, nombreBD);
        }
    }
}
