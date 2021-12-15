using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextJSonSample
{
    internal class Program
    {
        public static async Task Serialize<T>(T obj, string path)
        {
            string jsonString = JsonSerializer.Serialize(obj);

            using FileStream createStream = File.Create(path); //Crea un archivo de disco
            await JsonSerializer.SerializeAsync<T>(createStream, obj); //Lee el archivo y introduce el valor
            await createStream.DisposeAsync(); //Libera el recurso de forma segura


            //File.WriteAllText(filePath, jsonString);
        }

        public static async Task<T> Deserialize<T>(string path)
        {
            using FileStream createStream = File.OpenRead(path); //Abre un archivo de disco

            var obj = await JsonSerializer.DeserializeAsync<T>(createStream); //Lee el archivo y extrae el valor

            return obj;
        }

        static async Task Main(string[] args)
        {
            //Creamos un cliente con sus vehiculos, Guid.newGuid() generara automaticamente una id propia
            Cliente cliente = new Cliente
            {
                IdCliente = Guid.NewGuid(),
                Nombre = "Henry",
                Apellidos = "Cavil",
            };
            cliente.vehiculos = new List<Vehiculo>(
                    new[] {
                    new Vehiculo
                    {
                        IdVehiculo = Guid.NewGuid(),
                        Matricula = "XXX-XXX",
                        Modelo = "Porche",
                        color = Color.Rojo,
                        //Cliente = cliente

                    },
                    new Vehiculo
                    {
                        IdVehiculo = Guid.NewGuid(),
                        Matricula = "XXX-XXX",
                        Modelo = "Mercedes",
                        color = Color.Azul

                    },
                    new Vehiculo
                    {
                        IdVehiculo = Guid.NewGuid(),
                        Matricula = "XXX-XXX",
                        Modelo = "Volkvagen",
                        color = Color.Verde

                    }
                });
 
            Console.WriteLine("Object before serialization:");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine(cliente);

            await Serialize(cliente, "./Cliente.json");

            var deserialized = await Deserialize<Cliente>("./Cliente.json");

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized);
        }
    }
}