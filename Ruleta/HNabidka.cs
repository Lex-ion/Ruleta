﻿using System;
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
                Data.Prechod();
                Console.WriteLine($"Vítej, {hrac.Name} {hrac.LastName}, co si přeješ?\nZůstatek: {hrac.Credit}\n");

                Console.WriteLine("Vsadit           [1]");
                Console.WriteLine("Roztočit ruletu  [2]");
                Console.WriteLine("Nastavení        [3]");
                Console.WriteLine("Odhlásit se      [0]");


                switch (Console.ReadKey(true).KeyChar)
                {
                    default: Menu(); break;

                    case '1': Hrat(); break;
                    case '2': Data.Ruleta.Roztoc(); break;
                    case '3': Nastaveni(); break;
                    case '0': Data.Logged = false; active = false; break;
                }
                if (!active)
                    break;
            } while (active);
        }
  
        static void Hrat()
        {
            var hrac = Data.Hraci[Data.LogedPlayerID];
            Data.Prechod();
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

            Console.Write("\n\nChceš opravdu vsadit? Ano[1] / Ano, ale ještě netočit[2] / Ne[0] ");

            while (loop)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1': Data.Ruleta.Vsad(new Sazka(hrac, result, licheNeboSude, cerveneNeboCerne)); Data.Ruleta.Roztoc() ; loop = false; break;
                    case '2': Data.Ruleta.Vsad(new Sazka(hrac, result, licheNeboSude, cerveneNeboCerne)); loop = false; break;
                    case '3':  loop = false; break;
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
                Data.Prechod();

                Console.WriteLine($"Automatické hraní            [1] - {hrac.AutoPlay}");
                Console.WriteLine($"Animace                      [2] - {Data.Animace}"); 
                Console.WriteLine( "Zpět                         [0]");

                switch (Console.ReadKey(true).KeyChar)
                {
                    default: Menu(); break;

                    case '1': hrac.AutoPlay = !hrac.AutoPlay; break;
                    case '2': Data.Animace = !Data.Animace;Data.ConfigSync(1); break;
                    case '0': active = false; break;
                }

            } while (active);
        }
    }
}
