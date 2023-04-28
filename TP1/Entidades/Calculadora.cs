using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Metodo que valida operador
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            char retorno = '+';
            if(operador == '-' || operador == '*' || operador == '/')
            {
                retorno = operador;
            }
            return retorno;
        }
        /// <summary>
        /// Metodo para elegir y retorna operacion
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {

            double retorno = 0;
            switch (ValidarOperador(operador))
            {
                case '+':
                    retorno = num1 + num2;
                    break;
                case '-':
                    retorno = num1 - num2;
                    break;
                case '*':
                    retorno = num1 * num2;
                    break;
                case '/':
                    retorno = num1 / num2;
                    break;
            }
            return retorno;
        }

    }
}
