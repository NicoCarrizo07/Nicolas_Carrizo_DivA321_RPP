using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {

        protected Fabricante _fabricante;
        protected static Random _generadorDeVelocidades;
        protected string _modelo;
        protected float _precio;
        protected int _velocidadMaxima;

        public int VelocidadMaxima
        {
            get
            {
                if (_velocidadMaxima == 0)
                {
                    _velocidadMaxima = _generadorDeVelocidades.Next(100, 281);
                }
                return _velocidadMaxima;
            }
            set
            {
                _velocidadMaxima = value;
            }
        }

        public Fabricante Fabricante
        {
            get
            {
                return _fabricante;
            }
            set
            {
                _fabricante = value;
            }
        }

        public string Modelo
        {
            get
            {
                return _modelo;
            }
            set
            {
                _modelo = value;
            }
        }

        public float Precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
            }
        }


        /// <summary>
        /// Constructor por defecto de la clase Vehiculo.
        /// </summary>
        public Vehiculo() { }


        /// <summary>
        /// Constructor estático de la clase Vehiculo que inicializa el generador de velocidades.
        /// </summary>
        static Vehiculo()
        {
            _generadorDeVelocidades = new Random();

        }


        // <summary>
        /// Constructor de la clase Vehiculo que inicializa el modelo, el precio y el fabricante del vehiculo.
        /// </summary>
        /// <param name="marca">Marca del fabricante del vehículo.</param>
        /// <param name="pais">País del fabricante del vehículo.</param>
        /// <param name="modelo">Modelo del vehículo.</param>
        /// <param name="precio">Precio del vehículo.</param>
        public Vehiculo(string marca, EPais pais, string modelo, float precio)
            : this(modelo, precio, new Fabricante(marca, pais))
        {
            
        }

        // <summary>
        /// Constructor de la clase Vehiculo que inicializa el modelo, el precio y el fabricante del vehículo.
        /// </summary>
        /// <param name="modelo">Modelo del vehículo.</param>
        /// <param name="precio">Precio del vehículo.</param>
        /// <param name="fabricante">Fabricante del vehículo.</param>
        public Vehiculo(string modelo, float precio, Fabricante fabricante)

        {
            _modelo = modelo;
            _precio = precio; 
            _fabricante = fabricante;

        }


        /// <summary>
        /// Metodo privado que devuelve una cadena con la informacion del vehiculo.
        /// </summary>
        /// <param name="vehiculo">Vehiculo del que se obtendra la informacion.</param>
        /// <returns>Una cadena con la informacion del vehículo.</returns>

        private static string Mostrar(Vehiculo vehiculo)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"FABRICANTE: {(string)vehiculo._fabricante}"); 
            stringBuilder.AppendLine($"MODELO: {vehiculo._modelo}");
            stringBuilder.AppendLine($"VELOCIDAD MAXIMA: {vehiculo.VelocidadMaxima}");
            stringBuilder.AppendLine($"PRECIO: {vehiculo._precio}");

            return stringBuilder.ToString();

        }

        // <summary>
        /// Sobrecarga del operador de igualdad para comparar dos vehiculos.
        /// </summary>
        /// <param name="vehiculo1">Primer vehiculo a comparar.</param>
        /// <param name="vehiculo2">Segundo vehiculo a comparar.</param>
        /// <returns>True si los vehiculos tienen el mismo modelo y fabricante, False en caso contrario.</returns>
        public static bool operator ==(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return vehiculo1.Modelo == vehiculo2.Modelo && vehiculo1.Fabricante == vehiculo2.Fabricante;

        }

        public static bool operator !=(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return !(vehiculo1 == vehiculo2);
        }


        /// <summary>
        /// Conversion explicita de un objeto Vehiculo a una cadena de texto.
        /// </summary>
        /// <param name="vehiculo">Vehiculo a convertir.</param>
        /// <returns>Una cadena que representa la informacion del vehiculo.</returns>
        public static explicit operator string(Vehiculo vehiculo)
        {
            return Mostrar(vehiculo);
        }















    }
}
