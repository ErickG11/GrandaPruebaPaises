using GrandaPruebaPaises.Services;
using GrandaPruebaPaises.ViewModel;

namespace GrandaPruebaPaises.Views;

public partial class VistaConsultado : ContentPage
{
    private readonly ServicioBaseDeDatos _servicioBaseDeDatos;

    public VistaConsultado()
    {
        InitializeComponent();
        _servicioBaseDeDatos = new ServicioBaseDeDatos();
        CargarPaises();
    }

    private async void CargarPaises()
    {
        var ListPaises = await _servicioBaseDeDatos.ObtenerPaisesAsync();
        LVPaises.ItemsSource = ListPaises;
    }
}
