using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GrandaPruebaPaises.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using GrandaPruebaPaises.Services;
using System.Collections.ObjectModel;

namespace GrandaPruebaPaises.ViewModel
{
    public class VistaPrincipalViewModel : ObservableObject
    {
        private readonly ServicioApi _servicioApi;
        private readonly ServicioBaseDeDatos _servicioBaseDeDatos;

        public VistaPrincipalViewModel()
        {
            _servicioApi = new ServicioApi();
            _servicioBaseDeDatos = new ServicioBaseDeDatos();
            BuscarComando = new AsyncRelayCommand(BuscarPaisAsync);
            LimpiarComando = new RelayCommand(LimpiarCampos);
            CargarPaisesComando = new AsyncRelayCommand(CargarPaisesAsync);
        }

        private string _nombrePais;
        public string NombrePais
        {
            get => _nombrePais;
            set => SetProperty(ref _nombrePais, value);
        }

        private string _region;
        public string Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }

        private string _enlaceGoogleMaps;
        public string EnlaceGoogleMaps
        {
            get => _enlaceGoogleMaps;
            set => SetProperty(ref _enlaceGoogleMaps, value);
        }

        private string _nombreBD;
        public string NombreBD
        {
            get => _nombreBD;
            set => SetProperty(ref _nombreBD, value);
        }

        private string _mensajeError;
        public string MensajeError
        {
            get => _mensajeError;
            set => SetProperty(ref _mensajeError, value);
        }

        private bool _isErrorVisible;
        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set => SetProperty(ref _isErrorVisible, value);
        }

        private ObservableCollection<Pais> _paisesConsultados;
        public ObservableCollection<Pais> PaisesConsultados
        {
            get => _paisesConsultados;
            set => SetProperty(ref _paisesConsultados, value);
        }

        public ICommand BuscarComando { get; }
        public ICommand LimpiarComando { get; }
        public ICommand CargarPaisesComando { get; }

        private async Task BuscarPaisAsync()
        {
            if (string.IsNullOrEmpty(NombrePais))
            {
                MensajeError = "Ingresa el nombre de un país";
                IsErrorVisible = true;
                return;
            }

            var pais = await _servicioApi.ObtenerPaisPorNombreAsync(NombrePais);
            if (pais != null)
            {
                NombrePais = pais.Nombre;
                Region = pais.Region;
                EnlaceGoogleMaps = pais.EnlaceGoogleMaps;
                NombreBD = "EGranda";

                var nuevoPais = new Pais
                {
                    Nombre = pais.Nombre,
                    Region = pais.Region,
                    EnlaceGoogleMaps = pais.EnlaceGoogleMaps,
                    NombreBD = "EGranda"
                };

                await _servicioBaseDeDatos.GuardarPaisAsync(nuevoPais);

                MensajeError = string.Empty;
                IsErrorVisible = false;
            }
            else
            {
                MensajeError = "No se pudo encontrar el país.";
                IsErrorVisible = true;
            }
        }

        private void LimpiarCampos()
        {
            NombrePais = string.Empty;
            Region = string.Empty;
            EnlaceGoogleMaps = string.Empty;
            NombreBD = string.Empty;
            MensajeError = string.Empty;
            IsErrorVisible = false;
        }

        private async Task CargarPaisesAsync()
        {
            var listPaises = await _servicioBaseDeDatos.ObtenerPaisesAsync();
            PaisesConsultados = new ObservableCollection<Pais>(listPaises);
        }
    }
}
