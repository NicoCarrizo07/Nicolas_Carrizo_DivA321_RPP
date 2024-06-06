using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo
    {

        private ETipo _tipo;

        public ETipo Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
            }
        }



        public Auto() { }


        public Auto(string modelo, float precio, Fabricante fabricante, ETipo tipo)
           : base(modelo,precio,fabricante) 
        {
            _tipo = tipo;

        }


        public static bool operator ==(Auto auto1, Auto auto2)
        {
            return auto1 == auto2 && auto1._tipo == auto2._tipo;

        }

        public static bool operator !=(Auto auto1, Auto auto2)
        {
            return !(auto1 == auto2);
        }


        public static explicit operator float(Auto auto)
        {
            return auto.Precio;
        }


        public override bool Equals(object obj)
        {
            if (obj is Auto auto)
            {
                return base.Equals(auto) && _tipo == auto._tipo;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append((string)this); 
            stringBuilder.AppendLine($"TIPO: {_tipo}");


            return stringBuilder.ToString();


            
        }



    }
}
