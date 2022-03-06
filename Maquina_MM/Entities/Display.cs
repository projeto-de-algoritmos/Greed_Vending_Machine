using System;
using System.Collections.Generic;
using Vending_Machine.Enums;
using Vending_Machine.Interfaces;
using static Vending_Machine.Entities.Inventory;

namespace Vending_Machine
{
    public class Display:IDisplay
    {
        public void OpcaoUsuario(ref string opcao)
        {
                Console.WriteLine("MENU");
                Console.WriteLine("1 : Adicionar dinheiro");
                Console.WriteLine("2 : Escolher produto");
                Console.WriteLine("3 : Cancelar compra ");
                Console.WriteLine("4 : Mostrar iventario ");
                Console.WriteLine("5 : Mostrar historico ");
                Console.WriteLine("X : Desligar Sistema ");
                Console.WriteLine("C : Limpar tela");
                string valor = Console.ReadLine().ToUpper();

                if (
                    valor == "X" || 
                    valor == "C" )
                {
                    opcao = valor;
                    return;
                }
                //verifico se o valor e numerico e se esta no intervalo determinado
                if (int.TryParse(valor, out int result) &&
                    int.Parse(valor) <= 5 && int.Parse(valor) >= 1)
                {
                    opcao = valor;
                    return;
                }
                Console.WriteLine("Por favor Digite um valor valido");
            }

        public bool AddCash(ref double amount)
        {
            Console.Clear();
            Console.WriteLine("Adicione a quantia ");

            try
            {
                var opcaoUsuario = Console.ReadLine().ToUpper();
                if(opcaoUsuario == "X"){
                    return false;
                }
                if( double.Parse(opcaoUsuario) < 0 )
                { 
                    Console.WriteLine("Insira um valor maior que zero");
                    return false;
                }
                amount=double.Parse(opcaoUsuario);
                return true;
            }
            catch (Exception ex)
            {  
                Console.WriteLine("Por favor insira um valor ");
                var e =ex.Message;//Somente para sumir com o warning
                return false;
            }

        }

        public void CancelPurchase(double amount)
        {
            if(amount==0){
                Console.WriteLine("Nenhum valor para ser retornado");
                return;
            }
            Console.WriteLine($"Retornando o total de R$ {amount}");
        }

        public void ChooseSoda(ref ChooseSodaEnum choosenSoda)
        {
            
                Console.WriteLine("1 : Coca-Cola");
                Console.WriteLine("2 : Guarana");
                Console.WriteLine("3 : SkolBeats ");
                Console.WriteLine("X : Cancelar ");
                string valor = Console.ReadLine().ToUpper();

                if (valor == "X" )
                {
                    choosenSoda=0;
                    return;
                }
                //verifico se o valor e numerico e se esta no intervalo determinado
                if (int.TryParse(valor, out int result) &&
                    int.Parse(valor) <= 3 && int.Parse(valor) >= 1)
                {
                    Enum.TryParse(valor,out choosenSoda);
                    return;
                }
                Console.WriteLine("Por favor Digite um valor valido");
        }

        public void ShowIventory(List<Stored_Soda> iventory)
        {
            foreach(Stored_Soda storedSoda in iventory){
                Console.Write($"{storedSoda.Name}");
                Console.Write($" R${storedSoda.UnitValue}");
                Console.WriteLine($" Estoque:{storedSoda.TotalAmount}");
            }
        }

        public void OutofStock()
        {
            Console.WriteLine("Bebida sem estoque");
        }

        public void AmountLess(double diference)
        {
            Console.WriteLine($"Por favor insira R${diference} para efetuar a compra");
        }

        public void AmountOver(double diference)
        {
            Console.WriteLine($"Retornando o troco de R${diference}");
        }

        public void PurchaseOk()
        {
            Console.WriteLine($"Compra realizada!");
        }

        public void ShowHistoric(int totalSales, double totalAmount)
        {
            Console.WriteLine($"Vendas realizadas: {totalSales}");
            Console.WriteLine($"Saldo total: R${totalAmount}");
        }
    }
}



