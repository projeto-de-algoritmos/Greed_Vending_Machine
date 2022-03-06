using System;
using System.Collections.Generic;
using Vending_Machine.Entities.Iventory.cs;
using Vending_Machine.Entities.Sodas;

namespace Vending_Machine.Entities
{
    public class Inventory : AbstractIventory
    {
        public Inventory()
        {
            this.StoredSodas = new List<List<AbstractSoda>>();

            
            this.Coca_Cola = new List<AbstractSoda>{
                new Coca_Cola(),
                new Coca_Cola(),
            };

            this.Guarana = new List<AbstractSoda>{
                new Guarana()
            };
            this.Beats = new List<AbstractSoda>{
                
            };


            this.StoredSodas.Add(Coca_Cola);
            this.StoredSodas.Add(Guarana);
            this.StoredSodas.Add(Beats);
            this._catalog.Add(new Coca_Cola().Name,new Coca_Cola().Value);
            this._catalog.Add(new Guarana().Name,new Guarana().Value);
            this._catalog.Add(new Beats().Name,new Beats().Value);
        }

        public override void ConfirmPurchase(string sodaChoosen){
            if(sodaChoosen == "Coca_Cola")
                this.Coca_Cola.RemoveAt(0);
            if(sodaChoosen == "Guarana")
                this.Guarana.RemoveAt(0);
            if(sodaChoosen == "Beats")
                this.Guarana.RemoveAt(0);
        }
        public override bool ContainsSoda(string sodaName)
        {
            //Acesso as propriedades via Reflection
            if(sodaName == "Coca_Cola")
                return this.Coca_Cola.Count>0;
            if(sodaName == "Guarana")
                return this.Guarana.Count>0;
            if(sodaName == "Beats")
                return this.Beats.Count>0;

            return false;
        }
        public override List<Stored_Soda> GetStoredSodas()
        {
            List<Stored_Soda> listStoresSodas = new List<Stored_Soda>();
            foreach (List<AbstractSoda> listAbstractSoda in this.StoredSodas)
            {
                if(listAbstractSoda.Count>0){
                    listStoresSodas.Add(
                        new Stored_Soda(
                            listAbstractSoda[0].Name,
                            listAbstractSoda[0].Value,
                            listAbstractSoda.Count
                        )
                    );
                }
            }
            return listStoresSodas;
        }

        public class Stored_Soda
        {
            public Stored_Soda(string name, double unitValue, int totalAmount)
            {
                this.Name = name;
                this.UnitValue = unitValue;
                this.TotalAmount = totalAmount;
            }
            public string Name { get; set; }
            public double UnitValue { get; set; }
            public int TotalAmount { get; set; }
        }
 
    }

}