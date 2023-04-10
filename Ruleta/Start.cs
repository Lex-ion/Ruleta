using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta
{
    public class Start
    {
        public static void Menu()
        {
            bool active = true;
            do
            {

                

                Data.GetPlayers();


                Data.Prechod();

                Console.WriteLine("Login        [1]");
                Console.WriteLine("Registrace   [2]");
                Console.WriteLine("Sledovat     [3]");
                Console.WriteLine("KONEC        [0]");

                switch (Console.ReadKey(true).KeyChar)
                {
                    default: Menu(); break;

                    case '1': Login(); break;
                    case '2': Register(); break;
                    case '3': Data.Ruleta.Roztoc(); break;
                    case '0':active = false; break;
                }
            }while (active);
        }
        
        public static void Login()
        {
            
            Data.Prechod();
            Console.Write(" Zadej své příjmení: ");
            string prijmeni = Console.ReadLine();
            Console.Write("\n Zadej své jméno: ");
            string jmeno = Console.ReadLine();
            Console.Write("\n Zadej heslo: ");
            string heslo = Console.ReadLine();
            int cycle = 0;
            bool found=false;
            foreach (Hrac hrac in Data.Hraci)
            {
                if (hrac.LastName == prijmeni && hrac.Password==heslo&&hrac.Name==jmeno)
                {
                    Data.LogedPlayerID = cycle;
                    found = true;
                    Data.Logged = true;
                    break;
                }cycle++;
            }
            if (found)
            {
                HNabidka.Menu();
            }else
                Console.WriteLine("Nesprávné heslo nebo login");
            Console.ReadKey(true);
            Menu();
        }
        public static void Register()
        {
            Data.Prechod();
            Console.Write(" Zadej své jméno: ");
            string jmeno = Console.ReadLine();
            Console.Write("\n Zadej své přijmení: ");
            string prijmeni = Console.ReadLine();

            string hesloFrag ;
            string hesloFrag1;
            int cycle=0;

            do
            {
                if (cycle > 0)
                {
                    Console.WriteLine("Hesla se neshodují!");
                }
                Console.Write("\n Zadej heslo: ");
                hesloFrag = Console.ReadLine();
                Console.Write("\n Zopakuj heslo: ");
                hesloFrag1 = Console.ReadLine();
                cycle++;
            } while (hesloFrag != hesloFrag1&&cycle>0);


            
            bool found = false;
            foreach (Hrac hraci in Data.Hraci)
            {
                if (hraci.LastName == prijmeni && hraci.Password == hesloFrag&&hraci.Name==jmeno)
                {
                    
                    found = true;
                    break;
                }
                
            }
            if (found)
            {
                Console.WriteLine("Účet již existuje!");
                Console.ReadKey(true);
                Menu();
            }
            


                Hrac hrac = new Hrac(jmeno,prijmeni,hesloFrag,1000,false);

            if (!File.Exists(Data.CestaKData))
            {
                File.WriteAllText(Data.CestaKData,$"{hrac.Name}#-#{hrac.LastName}#-#{hrac.Password}#-#{hrac.Credit}#-#{hrac.AutoPlay}");
                
            }else
            {
                string[] data = File.ReadAllLines(Data.CestaKData);
                string[] toWrite = new string[data.Length+1];
                for (int i = 0; i < data.Length; i++)
                {
                    toWrite[i] = data[i];
                }
                toWrite[toWrite.Length - 1] = $"{hrac.Name}#-#{hrac.LastName}#-#{hrac.Password}#-#{hrac.Credit}#-#{hrac.AutoPlay}";
                
                File.WriteAllLines(Data.CestaKData,toWrite);

            }


            Data.Prechod();
            Menu();
        }
    }
}
