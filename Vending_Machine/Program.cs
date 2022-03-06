using System;
using Vending_Machine.Entities;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Machine machine = new Machine();
                Console.WriteLine($"{Environment.NewLine}");
                Console.WriteLine("Seja bem vindo !");
                machine.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
