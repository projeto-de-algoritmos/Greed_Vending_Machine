using Vending_Machine.Interfaces;

namespace Vending_Machine.Entities.Sodas
{
    public class Guarana : AbstractSoda
    {

        public Guarana()
        {
            this.Name = "Guarana";
            this.Value = 3.25;
        }
    }
}