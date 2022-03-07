using System;
using System.Collections.Generic;
using System.Linq;
using Vending_Machine.Enums;
using Vending_Machine.Interfaces;

namespace Vending_Machine.Entities
{
    public class Machine
    {
        private IDisplay _Display { get; set; }

        private Purchase _Purchase { get; set; }

        private IIventory _Iventory {get; set;}

        public List<Sale> _HistoricSales{ get; private set; }

        private Dictionary<string,double> _BankNotes{get;set;}

        public Machine()
        {
            _Display = new Display();
            _Purchase =new Purchase();
            _Iventory= new Inventory();
            _HistoricSales = new List<Sale>();
            _BankNotes= new Dictionary<string, double>()
            {
                {"Hundred" , 100},
                {"Fifty" , 50},
                {"Twenty_Five" , 25},
                {"Ten" , 10},
                {"Five",5},
                {"Two",2},
                {"One",1},
                {"Fifty_Cents" , 0.50},
                {"Twenty_Five_Cents" , 0.25},
                {"Ten_Cents" , 0.10},
                {"Five_Cents",0.05},
                {"One_Cent", 0.01}
            };
        }

        public void Start(){
            string opcaoUsuario = "" ;

            this._Display.OpcaoUsuario(ref opcaoUsuario);
            while (opcaoUsuario != "X"){
                switch (opcaoUsuario)
                    {
                        case "1":
                            this.AddCash();
                            break;
                        case "2":
                            this.ChooseSoda();
                            break;    
                        case "3":
                            this.CancelPurchase();
                            break;
                        case "4":
                            this.ShowIventory();
                            break;
                        case "5":
                            this.ShowHistoric();
                            break;
                        case "C":
                            Console.Clear();
                            break;    
                    }
                    this._Display.OpcaoUsuario(ref opcaoUsuario);
            }
        }


        private void ShowIventory()
        {
            List<Inventory.Stored_Soda> iventory = this._Iventory.GetStoredSodas();
            this._Display.ShowIventory(iventory);
        }

        private void AddCash()
        {
            double amount = 0.0;
            if(this._Display.AddCash(ref amount))
                this._Purchase.AddCash(amount);
        }
        private void ChooseSoda()
        {
            ChooseSodaEnum sodaChoosen =0 ;
            this._Display.ChooseSoda(ref sodaChoosen);
            if(sodaChoosen != 0){
                if(VerifyStockSoda(sodaChoosen.ToString())){
                    this.ConfirmPurchase(sodaChoosen.ToString());
                    return;
                }
                this._Display.OutofStock();
            }        
        }

        private bool VerifyStockSoda(string sodaName){
            return this._Iventory.ContainsSoda(sodaName);
        }
        private void ConfirmPurchase(string sodaChoosen)
        {
            var sodaValue = this._Iventory.ReturnSodaValue(sodaChoosen);
            double diferenceAmountSoda = this._Purchase.Amount - sodaValue;
            if(diferenceAmountSoda<0){
                this._Display.AmountLess(diferenceAmountSoda*-1);
                return;
            }
            if(diferenceAmountSoda == 0)
            {
                FinalizePurchase(sodaChoosen, sodaValue);
                return;
            }
            
            var countBankNotes= this.BankNoteCount(diferenceAmountSoda);
            this._Display.AmountOver(countBankNotes,this._BankNotes);        
            FinalizePurchase(sodaChoosen, sodaValue);    

        }

        private void FinalizePurchase(string sodaChoosen, double sodaValue)
        {
            this._Iventory.ConfirmPurchase(sodaChoosen);
            this.AddinHistoric(sodaChoosen, sodaValue);
            this._Display.PurchaseOk();
        }

        private List<string> BankNoteCount(double diferenceAmountSoda)
        {
            
            List<string> countBankNotes = new List<string>(); 
            foreach (string bankNote in _BankNotes.Keys){

                while(this._BankNotes[bankNote] <= diferenceAmountSoda){
                    diferenceAmountSoda = diferenceAmountSoda -_BankNotes[bankNote];
                    countBankNotes.Add(bankNote);
                }
            }
            return countBankNotes;
        }

        private void ShowHistoric()
        {
            var totalSales = this._HistoricSales.Count;
            var TotalCost = this._HistoricSales.Sum(hp=>hp.TotalCost);
            this._Display.ShowHistoric(totalSales,TotalCost);
        }

        private void AddinHistoric(string sodaName,double sodaValue){
            
            this._HistoricSales.Add(new Sale(sodaValue,sodaName));
            this._Purchase = new Purchase();
        }

        private void CancelPurchase()
        {
            //todo Retornar valor total sem produto
            this._Display.CancelPurchase(this._Purchase.Amount);
            this._Purchase = new Purchase();
        }

    
        public class Purchase
        {
            public Purchase()
            {
                this.Amount = 0;
            }
            public double Amount { get; set; }
            public void AddCash(double amount){
                this.Amount += amount;
            }
        }
    
        public class Sale
        {
            public Sale(double totalCost, string productName)
            {
                TotalCost = totalCost;
                ProductName = productName;
            }

            public double TotalCost { get; set; }
            public string ProductName { get; set; }
        }
    }


}