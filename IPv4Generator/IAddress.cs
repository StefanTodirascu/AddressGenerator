using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPv4Generator
{
    /// <summary>
    /// Interfaccia per la generazione di indirizzi IPv4 e l'opportuna subnet mask
    /// </summary>
    internal interface IAddress
    {
        /// <summary>
        /// Genera un indirizzo IPv4 
        /// </summary>
        /// <returns>IPv4 in formato stringa</returns>
        string generateIPv4();

        /// <summary>
        /// Genera una subnet mask
        /// </summary>
        /// <returns>Subnet mask in formato stringa</returns>
        string generateSubnet();
    }
}
