using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using PracticaRealRobayoJose_DI.Vistas;
using System.Windows.Input;
using PracticaRealRobayoJose_DI.Modelo;

namespace PracticaRealRobayoJose_DI.VistaModelo
{
    public partial class ValidarInicio : ObservableValidator
    {
        public ObservableCollection<string> errores { get; set; } = new ObservableCollection<string>();
        public ICommand IrARegistroCommand => new AsyncRelayCommand(irARegistro);

        private String campoNombre;
        [Required(ErrorMessage = "El campo de usuario debe de estar completo")]

        public String String1
        {
            get => campoNombre;
            set => SetProperty(ref campoNombre, value);
        }

        private String contraseña;
        [MinLength(5, ErrorMessage = "La longitud de la contraseña debe ser mayor a 4.")]

        public String Contraseña
        {
            get => contraseña;
            set => SetProperty(ref contraseña, value);
        }

        [RelayCommand]
        public async Task validar()
        {

            ValidateAllProperties();
            errores.Clear();
            GetErrors(nameof(String1)).ToList().ForEach(f => errores.Add(f.ErrorMessage));
            GetErrors(nameof(Contraseña)).ToList().ForEach(f => errores.Add(f.ErrorMessage));

            if (errores.Count == 0)
            {
                bool autenticado = await ComprobarUsuario();
                bool autenticado2 = await ComprobarContraseña();

                if (autenticado && autenticado2)
                {
                    await Shell.Current.GoToAsync(nameof(VistaBienvenida));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Usuario y/o contraseña no coinciden", "OK");
                }
            }
        }

        public async Task irARegistro()
        {
                await Shell.Current.GoToAsync(nameof(VistaRegistro));
        }

        private async Task<bool> ComprobarUsuario()
        {
            bool comprobacion = true;

            if (App._usuarioRepositorio.devolverRuta().Table<Usuario>().Where(c => c.Nick == campoNombre).Count() > 0 || App._usuarioRepositorio.devolverRuta().Table<Usuario>().Where(c => c.Contrasena == contraseña).Count() > 0)
            {
                comprobacion = true;
            }
            else
            {
                comprobacion = false;
            }

            return comprobacion;
        }

        private async Task<bool> ComprobarContraseña()
        {
            bool comprobacion = true;

            if (App._usuarioRepositorio.devolverRuta().Table<Usuario>().Where(c => c.Contrasena == contraseña).Count() > 0)
            {
                comprobacion = true;
            }
            else
            {
                comprobacion = false;
            }

            return comprobacion;
        }
    }
}
