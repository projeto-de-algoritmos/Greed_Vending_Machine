using System;
using System.Collections.Generic;
using Vending_Machine.Interfaces;
using static Vending_Machine.Entities.Inventory;

namespace Vending_Machine.Entities.Iventory.cs
{
    public class AbstractIventory:IIventory
    {
        public List<AbstractSoda> Coca_Cola { get; set; }
        public List<AbstractSoda> Guarana { get; set; }
        public List<AbstractSoda> Beats { get; set; }
        public List<List<AbstractSoda>> StoredSodas{get;set;}
        public Dictionary<string, double> _catalog = new Dictionary<string, double>();
          
        public virtual bool ContainsSoda(string sodaName)
        {
            throw new System.NotImplementedException();
        }

        public virtual List<Stored_Soda> GetStoredSodas()
        {
            throw new System.NotImplementedException();
        }

        public double ReturnSodaValue(string sodaName){
            return this._catalog[sodaName];
        }

        protected void Catalog_Add(string sodaName , double sodaValue){
            this._catalog.Add(sodaName,sodaValue);
        }

        public virtual void ConfirmPurchase(string sodaChoosen)
        {
            throw new NotImplementedException();
        }
    }
}