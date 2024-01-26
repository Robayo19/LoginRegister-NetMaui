namespace PracticaRealRobayoJose_DI.Vistas;

public partial class VistaBienvenida : ContentPage
{
	public VistaBienvenida()
	{
		InitializeComponent();
		usuarios.ItemsSource = App._usuarioRepositorio.listarUsuarios();
    }
}