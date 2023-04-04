using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta
{
    public class Ruleta
    {
        public List<Sazka> Sazky = new List<Sazka>();

        public Ruleta()
        {

        }

        public void Vsad(Sazka sazka)
        {
            if (sazka.VyseSazky > sazka.Hrac.Credit)
            {
                Console.WriteLine("Nedostatečný kredit");
            }else if (sazka.VyseSazky < 1)
            {
                Console.WriteLine("Nelze vsadit");
            }
            else
            {
                sazka.Hrac.Credit -= sazka.VyseSazky;
                Sazky.Add(sazka);
                Console.WriteLine($"{sazka.Hrac.Name} vsadil {sazka.VyseSazky}");

            }
        }

        public void Roztoc()
        {
            Console.Clear();

            AutoPlay();

            Informuj();
            Console.WriteLine();
            Random random = new Random();
            int hodnota = random.Next(0, 37);

            

            bool barva = random.NextDouble() > 0.5;
            bool lichost = hodnota%2==0;


            if (hodnota == 0)
            {
                foreach (Sazka sazka in Sazky)
                {
                    sazka.Hrac.Credit += sazka.VyseSazky;
                }
            }

            foreach (Sazka sazka in Sazky)
            {
                if (sazka.CerveneNeboCerne == barva && sazka.LicheNeboSude == !lichost&&hodnota>0)
                {

                    sazka.Hrac.Credit += 2 * sazka.VyseSazky;
                    sazka.Uspesna = true;
                }
            }
            Data.Save();

            Console.Write("     Na ruletě je číslo: ");
            VisualEff(hodnota, barva);



            Console.WriteLine();
            Vysledek();
            Sazky.Clear();
            Console.ReadKey(true);
        }

        void VisualEff(int value, bool barva)
        {
            Random random = new Random();

            int posX = Console.CursorLeft;
            int posY = Console.CursorTop;

            

            for (int i = 0; i < random.Next(100, 200); i++)
            {
                Console.SetCursorPosition(posX,posY);
                Console.CursorVisible = false;

                RandomColor();

                int tmp = random.Next(37);
                if (tmp == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                if (tmp < 10)
                {
                    Console.Write($"0{tmp}");
                }
                else
                {
                    Console.Write(tmp);
                }
                Thread.Sleep(50);
            }


            for (int i = 0; i < random.Next(20, 100); i++)
            {
                Console.SetCursorPosition(posX, posY);
                Console.CursorVisible = false;


                int tmp = random.Next(10);
                if (value > 29)
                {
                    tmp = random.Next(7);
                }




                if (tmp == 0&&value<10)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else
                    RandomColor();


                if (value < 10)
                {
                    Console.Write("0");
                }else
                    Console.Write(value.ToString().First());
                Console.Write(tmp);
                Thread.Sleep(150);
            }


            Console.SetCursorPosition(posX, posY);
            Console.CursorVisible = false;
            if (value == 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            else if (barva)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;//DarkBlack
            }
            
            if (value < 10)
            {
                Console.Write("0");
            }
            Console.WriteLine(value);
            Console.BackgroundColor = ConsoleColor.DarkGray;

        }

        void RandomColor()
        {
            Random random = new Random();
            if (random.NextDouble() > 0.5)
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }else
            {
                Console.BackgroundColor= ConsoleColor.DarkRed;
            }
        }

        void Informuj()
        {
            foreach (Sazka sazka in Sazky)
            {
                string barva;
                string sudost;

                if (sazka.CerveneNeboCerne)
                {
                    barva = "červené";
                }else
                {
                    barva = "černé";
                }

                if (sazka.LicheNeboSude)
                {
                    sudost = "liché";
                }else
                {
                    sudost = "sudé";
                }

                Console.WriteLine($"{sazka.Hrac.Name} {sazka.Hrac.LastName} vsadil {sazka.VyseSazky} na {sudost} {barva} ");
            }
        }

        void Vysledek()
        {
            foreach (Sazka sazka in Sazky)
            {
                string uspesna = "neúspěsně";
                if (sazka.Uspesna)
                {
                    uspesna = "úspěšně";
                }

                Console.WriteLine($"{sazka.Hrac.Name} {sazka.Hrac.LastName} {uspesna} vsadil a nyní má na účtě {sazka.Hrac.Credit}");
            }
        }

        void AutoPlay()
        {
            foreach (Hrac hrac in Data.Hraci)
            {
                Random rand = new Random();
                bool active = rand.NextDouble() > 0.5;
                if (Data.Logged)
                {
                    if (hrac.AutoPlay && hrac != Data.Hraci[Data.LogedPlayerID] && active)
                    {
                        Sazky.Add(new Sazka(hrac, 25 * rand.Next(1, 31), rand.NextDouble() > 0.5, rand.NextDouble() > 0.5));

                    }
                }else
                {
                    if (hrac.AutoPlay&&active)
                    {
                        Sazky.Add(new Sazka(hrac, 25 * rand.Next(1, 31), rand.NextDouble() > 0.5, rand.NextDouble() > 0.5));

                    }
                }

                
            }
        }
    }
}
