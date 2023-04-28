using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Propieda que setea value previamente validado
        /// </summary>
        private string Numero
        {
            set 
            {
                this.numero = ValidarOperando(value);
            }
        }
        /// <summary>
        /// Constructor que setea numero a 0
        /// </summary>
        public  Operando()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor que recibe un double
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor que recibe un string y lo setea a la propiedad
        /// </summary>
        /// <param name="numero"></param>
        public Operando(string numero)
        {
            Numero = numero;
        }

        /// <summary>
        /// Metodo que retorna un double parseando un string
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public double ValidarOperando(string numero)
        {
            double auxNumero = 0;
            double.TryParse(numero, out auxNumero);
            return auxNumero;
        }
        /// <summary>
        /// Metodo que valida un binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool retorno = true;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que retorna un string de un binario pasado a decimal
        /// </summary>
        /// <param name="numeroBinario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string numeroBinario)
        {
            string numeroDecimal = "Valor invalido!";
            int auxBinario;
            int sumador = 0;
            if (EsBinario(numeroBinario))
            {
                for (int i = numeroBinario.Length - 1; i >= 0; i--)
                {
                    auxBinario = int.Parse(numeroBinario[i].ToString());
                    if (auxBinario == 1)
                    {
                        sumador += (int)Math.Pow(2, numeroBinario.Length - 1 - i);
                    }
                    else
                    {
                        sumador += 0;
                    }
                }
                numeroDecimal = sumador.ToString();
            }
            return numeroDecimal;
        }

        /// <summary>
        /// Metodo que retorna un string de un double decimal pasado a string binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public  string DecimalBinario(double numero)
        {
            string binario = "";
            int numeroAbsoluto = Math.Abs((int)numero);
            while (numeroAbsoluto > 0)
            {
                binario = numeroAbsoluto % 2 + binario;
                numeroAbsoluto = numeroAbsoluto / 2;
            }
            return binario;
        }

        /// <summary>
        /// Metodo de que retonar un string reutilizando el metodo anterior
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string DecimalBinario(string binario)
        {
            string auxBinario = "Valor invalido!";
            if (double.TryParse(binario, out double numeroDecimal))
            {
                auxBinario = this.DecimalBinario(numeroDecimal);
            }
            return auxBinario;
        }
        /// <summary>
        /// Sobreecarga de operador + que retorna una suma double
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator + (Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Sobreecarga de operador - que retorna una resta double
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobreecarga de operador * que retorna una multiplicacion double
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Sobreecarga de operador / que retorna una division double o double.MinValue si n2 es 0
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator / (Operando n1, Operando n2)
        {
            double retorno;
            if(n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }
            
            return retorno;
        }
    }
}