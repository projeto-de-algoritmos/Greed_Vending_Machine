using Vending_Machine.Interfaces;

namespace Vending_Machine.Entities
{
    public abstract class AbstractSoda: ISoda
    {
        public string Name {get; protected set;} 
        public double Value{get; protected set;}

        public void ChangueValue(double value)
        {
            if(value > 0 ){
                this.Value=value;
            }
        }
    }
}