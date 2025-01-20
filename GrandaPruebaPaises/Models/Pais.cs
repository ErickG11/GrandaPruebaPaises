﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GrandaPruebaPaises.Models
{
        public class Pais
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }  
            public string Nombre { get; set; }  
            public string Region { get; set; }  
            public string EnlaceGoogleMaps { get; set; }  
            public string NombreBD { get; set; }  
        }

}
