using System;
using System.Text;
using System.Text.Json.Serialization;

namespace TextJSonSample
{
    class Vehiculo
    {
        public Guid IdVehiculo { get; set; } 

        public string Matricula { get; set; }

        public string Modelo { get; set; }

        public Color color;

        //Ignorara el proximo parametro a la hora de crear el json
        //[JsonIgnore]
        public Cliente Cliente { get; set; }
        
    }
}
