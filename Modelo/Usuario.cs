using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaRealRobayoJose_DI.Modelo
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public String Nick { get; set; }

        public String Nombre { get; set; }

        public int Edad { get; set; }

        public String Contrasena { get; set; }
    }
}
