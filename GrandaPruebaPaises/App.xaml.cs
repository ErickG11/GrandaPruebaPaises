using GrandaPruebaPaises.ViewModel;
using GrandaPruebaPaises.Views;

namespace GrandaPruebaPaises
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new VistaPrincipal 
            { 
                BindingContext = new VistaPrincipalViewModel()
            };
        }
    }
}
