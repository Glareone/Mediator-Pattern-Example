using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Mediator
{
    class Program
    {
        static void Main()
        {
            var executor1 = new Executor("Glareone", @"D:\mads\", "KILL THEM ALL");
            var executor2 = new Executor("Lis", @"C:\mads\", "LIE TO ALL");
            var executor3 = new Executor("BeerGod", @"D:\beer\", "BeerToAll");

            List<Executor> listofMads = new List<Executor> { executor1, executor2 }; 
            
            Mediator.AddExecutors("mad", listofMads);
            Mediator.AddExecutors("beer", new List<Executor> { executor3 });

            Mediator.DoAllByExecutors("mad");

        }
    }
}
