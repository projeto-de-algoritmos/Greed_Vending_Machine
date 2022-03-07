using System.Collections.Generic;
using Vending_Machine.Entities;
using Vending_Machine.Enums;

namespace Vending_Machine.Interfaces
{
    public interface IDisplay
    {
        void OpcaoUsuario(ref string opcao);
        bool AddCash(ref double amount);
        void CancelPurchase(double amount);
        void ChooseSoda(ref ChooseSodaEnum choosenSoda);
        void ShowIventory(List<Inventory.Stored_Soda> iventory);
        void OutofStock();
        void AmountLess(double diference);
        void AmountOver(List<string> countBankNotes,Dictionary<string, double> BankNotes);
        void PurchaseOk();
        void ShowHistoric(int totalSales, double totalAmount);
    }
}