using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta
{
    internal class Data
    {
        public static string CestaKData = "Data.txt";
        public static string CestaKeConfig = "Config.txt"; 
        


        public static List<Hrac> Hraci = new List<Hrac>();

        public static int LogedPlayerID=-1;

        public static bool Logged=false;

        public static Ruleta Ruleta = new Ruleta();


        public static bool Animace = true;
        public static int[] RozsahRuletyA = { 100, 200 };
        public static int[] RozsahRuletyB = { 20, 100 };
        public static ConsoleColor[] Barvy = { ConsoleColor.DarkGray, ConsoleColor.DarkYellow };

        public static void GetPlayers()
        {
            try {
                string[] raw = File.ReadAllLines(CestaKData);
                Hraci.Clear();
                foreach (string line in raw)
                {
                    string[] separated = line.Split("#-#");
                    Hraci.Add(new Hrac(separated[0], separated[1], separated[2], Convert.ToInt32(separated[3]), Convert.ToBoolean(separated[4])));
                }
            } catch { }
            
        }

        public static void Save()
        {
            string[] data = new string[Hraci.Count];
            int cycle = 0;
            foreach (Hrac hrac in Hraci)
            {
                data[cycle] = $"{hrac.Name}#-#{hrac.LastName}#-#{hrac.Password}#-#{hrac.Credit}#-#{hrac.AutoPlay}";
                cycle++;
            }
            
            File.WriteAllLines(CestaKData, data);
        }

       

        public static void ConfigSync(int mode)
        {

            if (mode == 0)//load
            {
                if (File.Exists(CestaKeConfig))
                {
                    StreamReader sr = new StreamReader(CestaKeConfig);
                    Animace = Convert.ToBoolean(sr.ReadLine().Split(':')[1]);

                    string rozsahA = sr.ReadLine().Split(':')[1];
                    string rozsahB = sr.ReadLine().Split(':')[1];

                    

                    RozsahRuletyA[0] = Convert.ToInt32(rozsahA.Split("#-#")[0]); //for cyklus by trval déle napsat
                    RozsahRuletyA[1] = Convert.ToInt32(rozsahA.Split("#-#")[1]);
                    RozsahRuletyB[0] = Convert.ToInt32(rozsahB.Split("#-#")[0]);
                    RozsahRuletyB[1] = Convert.ToInt32(rozsahB.Split("#-#")[1]);
                    Barvy[0] = (ConsoleColor)Convert.ToInt32(sr.ReadLine().Split(':')[1]);
                    Barvy[1] = (ConsoleColor)Convert.ToInt32(sr.ReadLine().Split(':')[1]);
               
               
               
                    sr.Dispose();
                }
                else
                {
                    StreamWriter sw = new StreamWriter(CestaKeConfig);
                    sw.WriteLine("Animace:" + Animace);
                    sw.WriteLine($"Rozsah ruletyA:{RozsahRuletyA[0]}#-#{RozsahRuletyA[1]}");
                    sw.WriteLine($"Rozsah ruletyB:{RozsahRuletyB[0]}#-#{RozsahRuletyB[1]}");
                    sw.WriteLine("Primární barva:" + (int)Barvy[0]);
                    sw.WriteLine("Sekundární barva:" + (int)Barvy[1]);

                    sw.Flush();
                    sw.Dispose();
                }
            }else if (mode == 1)//save
            {
                StreamWriter sw = new StreamWriter(CestaKeConfig);
                sw.WriteLine("Animace:" + Animace);
                sw.WriteLine($"Rozsah ruletyA:{RozsahRuletyA[0]}#-#{RozsahRuletyA[1]}");
                sw.WriteLine($"Rozsah ruletyB:{RozsahRuletyB[0]}#-#{RozsahRuletyB[1]}");
                sw.WriteLine("Primární barva:" + (int)Barvy[0]);
                sw.WriteLine("Sekundární barva:" + (int)Barvy[1]);

                sw.Flush();
                sw.Dispose();
            }
            
        }

        public static void Prechod()
        {

            if (!Animace)
            {
                Console.BackgroundColor = Barvy[0];
                Console.Clear();
                return;
            }

            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            Console.SetCursorPosition(0, 0);
            

           // Random rand = new Random();

            for (int x = 0; x < height; x++)
            {
              //  double tmp = rand.NextDouble();
                for (int y = 0; y < width; y++)
                {
                   
                    Console.BackgroundColor = Barvy[(y + x) % 2];

                    Console.Write(' ');

                }
                
              //  if (tmp > 0.8)
              //      Thread.Sleep(10);

            }
            Console.BackgroundColor = Barvy[0];
            Console.Clear();
        }

    }
}
