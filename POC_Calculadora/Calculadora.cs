using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Calculadora
{
    public class Calculadora
    {
        public double Numero1 { get; set; }
        public double Numero2 { get; set; }
        public enum Operacao { Adicao = 1, Subtracao = 2, Multiplicacao = 3, Divisao = 4 }

        public double Adicao()
        {
            return this.Numero1 + this.Numero2;
        }

        public double Subtracao() 
        { 
            return this.Numero1 - this.Numero2;
        }

        public double Multiplicacao()
        {
            return this.Numero1 * this.Numero2;
        }

        public double Dividir()
        {
            if (this.Numero2.Equals(0))
                return 0;

            return this.Numero1 / this.Numero2;
        }

        public double Calcular(Operacao vOperacao)
        {
            double Result = -1;

            switch (vOperacao)
            {
                case Operacao.Adicao:
                    Result = Adicao();
                    break;
                case Operacao.Subtracao:
                    Result = Subtracao();
                    break;
                case Operacao.Multiplicacao:
                    Result = Multiplicacao();
                    break;
                case Operacao.Divisao:
                    Result = Dividir();
                    break;
            }

            return Result;

        }
    }
}