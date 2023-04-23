using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contas.LibClasses
{
    public class Carteira
    {
        public double Saldo
        {
            get;
            private set;
        }
        public string Dono 
        { 
            get; 
            set;
        }// get= busca, set= define.

        public int Numero_da_conta 
        { 
            get;
            set;
        }// Adciona um numero a conta

        public string Cpf 
        {
            get;
            set; 
        }// adciona um cpf a conta

        public bool Sacar(double Valor)//método sacar
        {
            if (Valor > this.Saldo)// se valor maior que saldo, retorna false
                return false;

            this.Saldo -= Valor;// saldo - valor, return verdadeiro
            //this.Saldo = Saldo - Valor;
            return true;
        }

        public bool Depositar(double Valor)
        {
            this.Saldo += Valor;// saldo + valor, return true, adciona um valor ao saldo.
            return true;
        }

        public bool Transferir
            (Carteira destino, double valor)// destino carteira, valor tipo double
        {  
            //se nao tiver saldo cancela transferencia retornando false
            if (this.Saldo <= valor)
                return false;

            
            //Executa transferencia tirando da conta origem e deposita na conta destino
            this.Sacar(valor);
            bool tOK = destino.Depositar(valor);
            if (tOK)// se transferencia ocorreu com sucesso retorna true
                return true;
            else// caso ocorrer erro faz o rollback voltando dinheiro para conta de origem
            {
                this.Depositar(valor);
                return false;
            }
        }
    }
}
