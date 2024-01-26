namespace PracticaRealRobayoJose_DI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Vistas.VistaBienvenida),typeof(Vistas.VistaBienvenida));
        Routing.RegisterRoute(nameof(Vistas.VistaRegistro), typeof(Vistas.VistaRegistro));
        Routing.RegisterRoute(nameof(Vistas.VistaInicio), typeof(Vistas.VistaInicio));
    }
}
