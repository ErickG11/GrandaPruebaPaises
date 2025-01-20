using GrandaPruebaPaises.Views;

namespace GrandaPruebaPaises;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("VistaConsultado", typeof(VistaConsultado)); // Registramos la ruta para VistaConsultado
    }
}
