using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPv4Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserire 32 bit");
            AddressGenerator addressGenerator = new AddressGenerator("11000000.10101000.00000000.00000000/24");
            Console.WriteLine(addressGenerator.generateIPv4());
            Console.WriteLine(addressGenerator.generateSubnet());
            Console.ReadLine();

        }
    }
}
