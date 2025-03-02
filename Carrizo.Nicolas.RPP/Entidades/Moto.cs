﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {

        private ECilindrada _cilindrada;

        public ECilindrada Cilindrada
        {
            get
            {
                return _cilindrada;
            }
            set
            {
                _cilindrada = value;
            }
        }


       public Moto() { }

        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada)
            : base(marca, pais, modelo, precio)
        {

            _cilindrada = cilindrada;


        }


        public static bool operator ==(Moto moto1, Moto moto2)
        {
            return moto1 == moto2 && moto1._cilindrada == moto2._cilindrada;

        }

        public static bool operator !=(Moto moto1, Moto moto2)
        {
            return !(moto1 == moto2);
        }


        public static explicit operator float(Moto moto)
        {
            return moto.Precio;
        }


        public override bool Equals(object obj)
        {
            if (obj is Moto moto)
            {
                return base.Equals(moto) && _cilindrada == moto._cilindrada;
            }
            return false;
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append((string)this);
            stringBuilder.AppendLine($"CILINDRADA: {_cilindrada}");

            return stringBuilder.ToString();
        }


    }
}
