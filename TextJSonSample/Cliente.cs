using System;
using System.Collections.Generic;
using System.Text;

namespace TextJSonSample
{
    class Cliente
    {
        //Un Guid genera un valor aleatorio grande (evitando que se repitan), actua como una primary key para cada objeto
        public Guid IdCliente { get; set; } 

        public string Nombre { get; set; }

        public string Apellidos{ get; set; }

        public List<Vehiculo> vehiculos { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("IdCliente: {0}", IdCliente);
            sb.AppendFormat("Nombre: {0}", Nombre);
            sb.AppendFormat("Apellidos: {0}", Apellidos);
            sb.AppendFormat("Vehiculos: {0}", String.Join<Vehiculo>(",", vehiculos));

            return sb.ToString();
        }
    }
}
