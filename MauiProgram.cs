using PracticaRealRobayoJose_DI.Repositorios;

namespace PracticaRealRobayoJose_DI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        String ruta = ObtenerRutaBD.devolverRuta("tablaUsuarios.db");
        builder.Services.AddSingleton<UsuarioRepositorio>(
            s => ActivatorUtilities.CreateInstance<UsuarioRepositorio>(s, ruta)
            );
        return builder.Build();
	}
}
