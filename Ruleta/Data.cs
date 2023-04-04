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

        public static List<Hrac> Hraci = new List<Hrac>();

        public static int LogedPlayerID=-1;

        public static bool Logged=false;

        public static Ruleta Ruleta = new Ruleta();
        
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

    }
}
