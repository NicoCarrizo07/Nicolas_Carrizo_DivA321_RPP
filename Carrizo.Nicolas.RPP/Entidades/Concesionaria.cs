using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    //para serializar
    [XmlInclude(typeof(Moto))]
    [XmlInclude(typeof(Auto))]
    


    public class Concesionaria
    {

        private int _capacidad;
        private List<Vehiculo> _vehiculos;

        public int Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = value; }
        }

        public List<Vehiculo> Vehiculos
        {
            get { return _vehiculos; }
            set { }
        }

        public double PrecioDeAutos
        {
            get { return ObtenerPrecio(EVehiculo.Auto); }
            set { }
        }

        public double PrecioDeMotos
        {
            get { return ObtenerPrecio(EVehiculo.Moto); }
            set { }
        }

        public double PrecioTotal
        {
            get { return ObtenerPrecio(EVehiculo.Ambos); } 
            set { }
        }


        /// <summary>
        /// constructor privado de la clase Concesionaria que inica la lista de Vehiculos.
        /// </summary>
        private Concesionaria()
        {
            _vehiculos = new List<Vehiculo>();
        }

        // <summary>
        /// constructor de la clase Concesionaria que establece la capacidad maxima.
        /// </summary>
        /// <param name="capacidad">capacidad maxima de la concesionaria.</param>
        private Concesionaria(int capacidad) : this()
        {
            _capacidad = capacidad;
        }


        /// <summary>
        /// obtiene el precio total de los vehiculos de un determinado tipo.
        /// </summary>
        /// <param name="tipo">Tipo de vehículo (Auto, Moto o Ambos).</param>
        /// <returns>precio total de los vehiculos del tipo especificado.</returns>
        private double ObtenerPrecio(EVehiculo tipo)
        {
            double total = 0;


            foreach (Vehiculo vehiculo in _vehiculos)
            {

                if (tipo == EVehiculo.Ambos)
                {
                    total += vehiculo.Precio;
                }
                else if (tipo.ToString() == vehiculo.GetType().Name)
                {
                    total += vehiculo.Precio;

                }
            }

            return total;
        }


        // <summary>
        /// Muestra la informacion de la concesionaria y sus vehiculos.
        /// </summary>
        /// <param name="concesionaria">concesionaria a mostrar.</param>
        /// <returns>cadena de texto con la información de la concesionaria y sus vehiculos.</returns>
        public static string Mostrar(Concesionaria concesionaria)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Capacidad: {concesionaria.Capacidad}");
            stringBuilder.AppendLine($"Total por autos: {concesionaria.PrecioDeAutos}");
            stringBuilder.AppendLine($"Total por motos: {concesionaria.PrecioDeMotos}");
            stringBuilder.AppendLine($"Total : {concesionaria.PrecioTotal}\n");
            stringBuilder.AppendLine($"********************************************************************************************************");
            stringBuilder.AppendLine("                                Listado de Vehiculos");
            stringBuilder.AppendLine($"********************************************************************************************************");

            foreach (Vehiculo vehiculo in concesionaria._vehiculos)
            {
                if (vehiculo is Auto auto)
                {
                    stringBuilder.AppendLine(auto.ToString());
                }
                else if (vehiculo is Moto moto)
                {
                    stringBuilder.AppendLine(moto.ToString());
                }

            }

            return stringBuilder.ToString();
        }


        /// <summary>
        /// Sobrecarga implicita que permite inicializar una concesionaria especificando su capacidad.
        /// </summary>
        /// <param name="capacidad">Capacidad máxima de la concesionaria.</param>
        /// <returns>nueva instancia de Concesionaria con la capacidad especificada.</returns>
        public static implicit operator Concesionaria(int capacidad) //lo hago pq mis constructores son privados y lo inicializo desde aca
        {
            return new Concesionaria(capacidad);

        }

        /// <summary>
        /// sobrecarga del operador de igualdad == para comparar una concesionaria con un vehiculo.
        /// </summary>
        /// <param name="concesionaria">Concesionaria a comparar.</param>
        /// <param name="vehiculo">vehiculo a buscar en la concesionaria.</param>
        /// <returns>true si el vehiculo está en la concesionaria, False en caso contrario.</returns>
        public static bool operator ==(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            return concesionaria.Vehiculos.Contains(vehiculo);
        }


        public static bool operator !=(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            return !(concesionaria == vehiculo);
        }


        /// <summary>
        /// Sobrecarga del operador de adición + para agregar un vehiculo a la concesionaria.
        /// </summary>
        /// <param name="concesionaria">Concesionaria a la que se agregara el vehículo.</param>
        /// <param name="vehiculo">Vehiculo a agregar.</param>
        /// <returns>La concesionaria actualizada con el vehículo agregado.</returns>
        public static Concesionaria operator +(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            if (concesionaria._vehiculos.Count >= concesionaria._capacidad)
            {
                Console.WriteLine("¡No hay más lugar en la concesionaria!");
            }
            else if (concesionaria == vehiculo) 
            {
                Console.WriteLine("¡El vehículo ya está en la concesionaria!.");
            }
            else
            {
                concesionaria.Vehiculos.Add(vehiculo);
            }

            return concesionaria;
        }


        /// <summary>
        /// sobrecarga del operador de sustracción - para eliminar un vehiculo de la concesionaria.
        /// </summary>
        /// <param name="concesionaria">Concesionaria de la que se eliminara el vehiculo.</param>
        /// <param name="vehiculo">Vehiculo que se eliminara de la concesionaria.</param>
        /// <returns>concesionaria actualizada sin el vehiculo especificado.</returns>
        public static Concesionaria operator -(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            if (concesionaria == vehiculo)
            {
                concesionaria.Vehiculos.Remove(vehiculo);
            }
            else
            {
                Console.WriteLine("¡El vehículo no está en la concesionaria!");
            }

            return concesionaria;
        }


        // <summary>
        /// Guarda la informacion de la concesionaria en un archivo de texto.
        /// </summary>
        /// <param name="rutaArchivo">Ruta del archivo donde se guardara la información.</param>
        public void GuardarConcesionaria(string rutaArchivo)
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                writer.Write(Mostrar(this));
            }
  
        }


        /// <summary>
        /// Serializa la información de la concesionaria en un archivo XML.
        /// </summary>
        /// <param name="rutaArchivo">Ruta del archivo donde se guardara la informacion serializada.</param>
        public void SerializarConcesionaria(string rutaArchivo)
        {
            XmlSerializer Xmlserializer = new XmlSerializer(typeof(Concesionaria));

            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                Xmlserializer.Serialize(writer, this);
            }
        }


        /// <summary>
        /// Deserializa la informacion de una concesionaria desde un archivo XML.
        /// </summary>
        /// <param name="rutaArchivo">Ruta del archivo XML que contiene la informacion de la concesionaria.</param>
        /// <returns>Instancia de Concesionaria con la informacin deserializada.</returns>
        public static Concesionaria DeserializarConcesionaria(string rutaArchivo)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Concesionaria));


            using (StreamReader reader = new StreamReader(rutaArchivo))
            {

                return (Concesionaria)serializer.Deserialize(reader);
            }
        }


    }
}
