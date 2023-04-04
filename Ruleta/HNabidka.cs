using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta
{
    internal class HNabidka
    {
        public static void Menu()
        {
            var hrac = Data.Hraci[Data.LogedPlayerID];
            bool active = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"Vítej, {hrac.Name} {hrac.LastName}, co si přeješ?\nZůstatek: {hrac.Credit}\n");

                Console.WriteLine("Hrát         [1]");
                Console.WriteLine("Nastavení    [2]");
                Console.WriteLine("Odhlásit se  [0]");


                switch (Console.ReadKey(true).KeyChar)
                {
                    default: Menu(); break;

                    case '1': Hrat(); break;
                    case '2': Nastaveni(); break;
                    case '0': active = false; break;
                }
            } while (active);
        }
  
        static void Hrat()
        {
            var hrac = Data.Hraci[Data.LogedPlayerID];
            Console.Clear();
            Console.Write($"Kolik si chceš vsadit? [zůstatek: {hrac.Credit}] - ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Neplatný vklad!");
                Console.ReadKey(true);
                return;
            }
            
                Console.Write("\nSázíš na červené[1] nebo černé[2]?  ");
            bool cerveneNeboCerne=false;
            bool loop = true;

            while (loop)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1': cerveneNeboCerne = true; loop = false; break;
                    case '2': cerveneNeboCerne = false; loop = false; break;

                }
            }loop = true;
            


            Console.Write("\nSázíš na liché[1] nebo sudé[2]?  ");
            bool licheNeboSude=false;
            while (loop)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1': licheNeboSude = true; loop = false; break;
                    case '2': licheNeboSude = false; loop = false; break;
                }
            }loop= true;

            Console.Write("\n\nChceš opravdu vsadit? Ano[1] / Ne[2] ");

            while (loop)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1': Data.Ruleta.Vsad(new Sazka(hrac, result, licheNeboSude, cerveneNeboCerne)); Data.Ruleta.Roztoc() ; loop = false; break;
                    case '2':  loop = false; break;
                }
            }

            
        }

        static void Nastaveni()
        {
            var hrac = Data.Hraci[Data.LogedPlayerID];
            bool active = true;

            do
            {
                Data.Save();
                Console.Clear();

                Console.WriteLine($"Automatické hraní            [1] - {hrac.AutoPlay}");
                Console.WriteLine("Experimentální režim         [2] - false"); //dodělat - maz. soub.
                Console.WriteLine("Zpět                         [0]");

                switch (Console.ReadKey(true).KeyChar)
                {
                    default: Menu(); break;

                    case '1': hrac.AutoPlay = !hrac.AutoPlay; break;
                    case '2': Nastaveni(); break;
                    case '0': active = false; break;
                }

            } while (active);
        }
    }
}
