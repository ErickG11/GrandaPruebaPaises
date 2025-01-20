using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GrandaPruebaPaises.Models;

namespace GrandaPruebaPaises.Services
{
    public class ServicioBaseDeDatos
    {
        private SQLiteAsyncConnection _conexion;

        public ServicioBaseDeDatos()
        {
            var rutaBaseDeDatos = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "paises.db");
            _conexion = new SQLiteAsyncConnection(rutaBaseDeDatos);
            _conexion.CreateTableAsync<Pais>().Wait(); 
        }

        public Task<int> GuardarPaisAsync(Pais pais)
        {
            return _conexion.InsertAsync(pais);
        }

        public Task<List<Pais>> ObtenerPaisesAsync()
        {
            return _conexion.Table<Pais>().ToListAsync();
        }
    }
}
