﻿using System;
using System.Text;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            :base(chasis, marca, color)
        {
        }
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get{ return ETamanio.Grande; }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SUV");
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}
