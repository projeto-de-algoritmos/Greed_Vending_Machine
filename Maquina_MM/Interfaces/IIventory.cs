using System.Collections.Generic;
using static Vending_Machine.Entities.Inventory;

namespace Vending_Machine.Interfaces
{
    public interface IIventory
    {
        List<Stored_Soda> GetStoredSodas();
        bool ContainsSoda(string sodaName);
        double ReturnSodaValue(string sodaName);
        void ConfirmPurchase(string sodaChoosen);
    }
}