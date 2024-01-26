using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PracticaRealRobayoJose_DI.Modelo;
using PracticaRealRobayoJose_DI.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticaRealRobayoJose_DI.VistaModelo
{
        public partial class ValidadorRegistro : ObservableValidator
        {
            public ObservableCollection<string> errores { get; set; } = new ObservableCollection<string>();
            public ICommand IrAInicioCommand => new AsyncRelayCommand(irAInicio);

            private String nick;
            [Required(ErrorMessage = nameof(nick) + "Rellene el campo del nick por favor")]
            public String Nick
            {
                get => nick;
                set => SetProperty(ref nick, value);

            }

            private String nombre;
            [Required(ErrorMessage = "Rellene el campo nombre por favor")]
            [RegularExpression(@"^[A-Za-záéíóúüñÁÉÍÓÚÜÑ\s]+$", ErrorMessage = "Unicamente valores alfabeticos en el nombre")]
            public String Nombre
            {

                get => nombre;
                set => SetProperty(ref nombre, value);

            }

            private String contrasena;
            private String confirmarContrasena;

            [Required(ErrorMessage = "El campo contraseña no puede estar vacio")]
            [MinLength(5, ErrorMessage = "Debe tener mas de 5 caracteres")]
            public String Contrasena
            {
                get => contrasena;
                set
                {
                    SetProperty(ref contrasena, value);

                }
            }


            [Required(ErrorMessage = "el campo de comprobar contraseña no puede estar vacio")]
            [Compare(nameof(Contrasena), ErrorMessage = "")]
            public String ConfirmarContrasena
            {
                get => confirmarContrasena;
                set
                {
                    SetProperty(ref confirmarContrasena, value);
                }
            }

        private async Task<bool> validarExistente()
        {
            bool comprobacion = true;

            if (App._usuarioRepositorio.devolverRuta().Table<Usuario>().Where(c => c.Nick == Nick).Count() > 0)
            {
                comprobacion = false;
            }
            else
            {
                comprobacion = true;
            }

            return comprobacion;
        }



        private String edad;
            [Required(ErrorMessage = "inserte una edad")]
            [RegularExpression(@"^[1-9]\d?$|100$", ErrorMessage = "Debe ser una edad entre 1 y 100")]
            public String? Edad
            {
                get => edad;
                set => SetProperty(ref edad, value);
            }


            [RelayCommand]
            public async Task validar()
            {
                ValidateAllProperties();
                errores.Clear();
                GetErrors(nameof(Nick)).ToList().ForEach(f => errores.Add(f.ErrorMessage));
                GetErrors(nameof(Nombre)).ToList().ForEach(f => errores.Add(f.ErrorMessage));
                GetErrors(nameof(Contrasena)).ToList().ForEach(f => errores.Add(f.ErrorMessage));
                GetErrors(nameof(Edad)).ToList().ForEach(f => errores.Add(f.ErrorMessage));
                if (Contrasena != ConfirmarContrasena)
                {
                    GetErrors(nameof(Contrasena)).ToList().ForEach(f => errores.Add(f.ErrorMessage = "Deben ser las mismas contraseñas"));
                    GetErrors(nameof(ConfirmarContrasena)).ToList().ForEach(f => errores.Add(f.ErrorMessage = "Deben ser las mismas contraseñas"));
                }

            if (errores.Count == 0)
                {

                    int numeroEdad;
                bool autenticado = await validarExistente();
                if (int.TryParse(Edad, out numeroEdad))
                {
                        App._usuarioRepositorio.add(new Modelo.Usuario { Nick = Nick, Nombre = Nombre, Contrasena = Contrasena, Edad = numeroEdad });
                        if (autenticado)
                        {
                            await Shell.Current.GoToAsync(nameof(VistaInicio));
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error", "Usuario ya existente", "OK");
                        }
                }


                }
            }

            public async Task irAInicio()
            {
                await Shell.Current.GoToAsync(nameof(Vistas.VistaInicio));
            }


        }

}
