using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }
        
        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

       
        public string DecimalBinario(double numero)
        {
            int auxNum;
            bool isNumero;


            isNumero = int.TryParse(numero.ToString(), out auxNum);

            if (isNumero)
            {
                if (auxNum > 0)
                {
                    int aux = 0;
                    string auxString = "";
                    string retorno = "";

                    while (auxNum > 0)
                    {
                        aux = auxNum % 2;
                        auxString = Convert.ToString(aux);
                        retorno = auxString + retorno;
                        auxNum = auxNum / 2;
                    }

                    return retorno;
                }
                else
                {
                    return "0";
                }

            }
            else
            {
                return "Valor Invalido";
            }


        }
        public string DecimalBinario(string numero)
        {           
            string numeroBinario;
            bool numeroValidado;
            double auxNumero;

            numeroValidado = double.TryParse(numero, out auxNumero);
            if(numeroValidado)
            {
                numeroBinario = DecimalBinario(auxNumero);

                return numeroBinario;
            }
            else
            {
                return "Valor Invalido";
            }    

        }
        public string BinarioDecimal(string numero)
        {
            bool validado;
            
            validado=EsBinario(numero);

            if (validado)
            {
                char[] array = numero.ToCharArray();

                Array.Reverse(array);

                int auxNum = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        if (i == 0)
                        {
                            auxNum += 1;
                        }
                        else
                        {
                            auxNum += (int)Math.Pow(2, i);
                        }
                    }

                }

                return Convert.ToString(auxNum);
            }
            else
            {
                return "Valor inválido";
            }
            
            
        }

        private double ValidarNumero(string strNumero)
        {
            bool validado;

            validado = double.TryParse(strNumero,out double numero);
            
            if(validado== true)
            {
                return numero;
            }

            return 0;           
        }

        public string SetNumero
        {           
            set 
            {
                double numero;

                numero = this.ValidarNumero(value);

                if (numero != 0)
                {
                    this.numero = numero;
                }
            }
        }

        private bool EsBinario(string str)
        {
            bool aux = false;

            foreach(char item in str)
            {
                if(item == '0' || item == '1')
                {
                    aux = true;
                    
                }
                else
                {
                    aux = false;
                    return aux;
                }
            }
            return aux;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double suma;

            suma = n1.numero + n2.numero;

            return suma;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resta;

            resta = n1.numero - n2.numero;

            return resta;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double division;
            
            if(n2.numero != 0)
            {
                division = n1.numero/n2.numero;
                return division;
            }

            return double.MinValue;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double multiplicacion;

            multiplicacion = n1.numero * n2.numero;

            return multiplicacion;
        }

    }
}
