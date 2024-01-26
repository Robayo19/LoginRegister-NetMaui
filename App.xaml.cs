using PracticaRealRobayoJose_DI.Repositorios;

namespace PracticaRealRobayoJose_DI;

public partial class App : Application
{

	public static UsuarioRepositorio _usuarioRepositorio {  get; set; }

	public App(UsuarioRepositorio usuarioRepositorio)
	{
		InitializeComponent();
		_usuarioRepositorio = usuarioRepositorio;
		MainPage = new AppShell();
	}
}
