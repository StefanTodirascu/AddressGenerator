using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPv4Generator
{

    /// <summary>
    /// Classe che dati 32 bit e il CIDR in input genera il corrispondente indirizzo IPv4 con l'opportuna Subnet Mask
    /// </summary>
    internal class AddressGenerator : IAddress
    {
        string _bit32;

        /// <summary>
        /// Costruttore della classe AddressGenerator che richiede i 32 bit
        /// </summary>
        /// <param name="bit32"></param>
        public AddressGenerator(string bit32)
        {
            _bit32 = bit32;
        }

        /// <summary>
        /// Ritorna l'indirizzo IPv4 corrispondente ai 32 bit dati in input
        /// </summary>
        /// <returns>Indirizzo IPv4 in formato stringa</returns>
        public string generateIPv4()
        {
            string[] otteti;

            //suddivisione dei 32 bit in 4 otteti
            otteti = _bit32.Split('.', '/');

            //conversione di ogni otteto in decimale attraverso il metodo BinToDec(string otteto)
            for (int i = 0; i < 4; i++)             
                otteti[i] = BinToDec(otteti[i]);   



            return $"{otteti[0]}.{otteti[1]}.{otteti[2]}.{otteti[3]}";
        }

        /// <summary>
        /// Ritorna l'opportuna Subnet Mask 
        /// </summary>
        /// <returns>Subnet Mask in formato stringa</returns>
        public string generateSubnet()
        {

            string tmp = "";

            //suddivisiune della stringa data in input in modo da avere il CIDR isolato => CIDR = otteti[4] 
            string[] otteti = _bit32.Split('.', '/');   
            for (int i = 0; i < 32; i++)
            {
                //creazione della stringa con i bit di rete setati a 1 e i bit di host setati a 0 in base al CIDR
                if (i < int.Parse(otteti[4]))       
                    tmp += '1';
                else
                    tmp += '0';

                //switch per suddividere la subnet mask in otteti 
                switch (i)
                {
                    case 7:
                        otteti[0] = tmp; tmp = "";
                        break;
                    case 15:
                        otteti[1] = tmp; tmp = "";
                        break;
                    case 23:
                        otteti[2] = tmp; tmp = "";
                        break;
                }
                otteti[3] = tmp;
            }
            //conversione degli otteti della subnet mask in decimale attraverso il metodo BinToDec(string otteto)
            for (int i = 0; i < 4; i++)
                otteti[i] = BinToDec(otteti[i]);
            return $"{otteti[0]}.{otteti[1]}.{otteti[2]}.{otteti[3]}";
        }




        /// <summary>
        /// Converte un otteto in binario in numero decimale
        /// </summary>
        /// <param name="otteti"></param>
        /// <returns>Numero decimale in formato stringa</returns>
        private string BinToDec(string otteto)
        {
            int tmp = 1;
            int risultato = 0;
            for (int i = 7; i >= 0; i--)
            {
                //condizione per assegnare alla prima posizione dell'otteto il valore 1
                if (i < 7)
                {
                    //si moltiplica per 2 ogni volta che si cambia posizione 
                    tmp = tmp * 2;
                }
                                         
                if (otteto[i] == '1')
                {
                    //se il bit è 1 si somma al risultato la potenza corrispondente alla sua posizione
                    risultato += tmp;                   
                }
            }
            return risultato.ToString();
        }
    }
}
