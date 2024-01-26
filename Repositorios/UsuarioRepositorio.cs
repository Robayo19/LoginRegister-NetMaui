using PracticaRealRobayoJose_DI.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaRealRobayoJose_DI.Repositorios
{
    public class UsuarioRepositorio
    {
        private string _ruta;
        private SQLiteConnection conexion;

        public UsuarioRepositorio(string ruta)
        {
            _ruta = ruta;
            conexion = new SQLiteConnection(ruta);
            System.Diagnostics.Debug.WriteLine($"La ruta de la base de datos es: {_ruta}");
            if (!conexion.TableMappings.Any(e => e.MappedType.Name == "Usuario"))
            {
                conexion.CreateTable<Usuario>();
            }
        }

        public void add(Usuario usuario)
        {
            conexion.Insert(usuario);
        }

        public ObservableCollection<Usuario> listarUsuarios()
        {
            List<Usuario> usuarios = conexion.Table<Usuario>().ToList();
            ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>(usuarios);
            return listaUsuarios;
        }

        public SQLiteConnection devolverRuta()
        {
            return conexion;
        }
    }
}
