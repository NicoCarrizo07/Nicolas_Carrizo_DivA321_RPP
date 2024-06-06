using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabricante
    {
        private string _marca;
        private EPais _pais;

        /// <summary>
        /// Propiedad que obtiene la marca del fabricante.
        /// </summary>
        public string Marca
        {
            get
            {
                return _marca;
            }
            set
            {
                _marca = value;
            }
        }

        /// <summary>
        /// Propiedad que obtiene el pais de origen del fabricante.
        /// </summary>
        public EPais Pais
        {
            get
            {
                return _pais;
            }
            set
            {
                _pais = value;
            }
        }

        /// <summary>
        /// constructor por defecto de la clase Fabricante.
        /// </summary>
        public Fabricante() { }

        /// <summary>
        /// constructor de la clase Fabricante que inicializa la marca y el pai s.
        /// </summary>
        /// <param name="marca">Marca del fabricante.</param>
        /// <param name="pais">País de origen del fabricante.</param>
        public Fabricante(string marca , EPais pais) 
        {
            _marca= marca;
            _pais= pais;
        
        }

        /// <summary>
        /// sobrecarga del operador de igualdad == para comparar dos fabricantes.
        /// </summary>
        /// <param name="fabricante1">Primer fabricante a comparar.</param>
        /// <param name="fabricante2">Segundo fabricante a comparar.</param>
        /// <returns>True si los fabricantes son iguales, False en caso contrario.</returns>
        public static bool operator ==(Fabricante fabricante1, Fabricante fabricante2)
        {
            return fabricante1._marca == fabricante2._marca && fabricante1._pais == fabricante2._pais;
            
        }
        /// <summary>
        /// sobrecarga del operador de desigualdad != para comparar dos fabricantes.
        /// </summary>
        /// <param name="fabricante1">Primer fabricante a comparar.</param>
        /// <param name="fabricante2">Segundo fabricante a comparar.</param>
        /// <returns>true si los fabricantes son diferentes, false en caso contrario.</returns>
        public static bool operator !=(Fabricante fabricante1, Fabricante fabricante2)
        {
            return !(fabricante1 == fabricante2);
        }


        /// <summary>
        /// conversión implicita de un objeto Fabricante a una cadena de texto.
        /// </summary>
        /// <param name="fabricante">Fabricante a convertir.</param>
        /// <returns>cadena que representa el fabricante en formato "Marca, País".</returns>
        public static implicit operator string(Fabricante fabricante)
        {

            return $"{fabricante.Marca}, {fabricante.Pais}";
        }







    }
}
