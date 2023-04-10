namespace Ruleta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data.ConfigSync(0);
            Console.WriteLine("Hello, World!");
            
            

            

            Data.GetPlayers();
            Start.Menu();

           // Hrac prvniHrac = new Hrac("Adam", "Malý", "5",1000,false);
           // Hrac druhyHrac = new Hrac("David", "Velký", "5",1000,false);
           // Sazka prvniSazka = new Sazka(prvniHrac, 500, false, true); //sázka na sudé (0) červené (1)
           // Sazka druhaSazka = new Sazka(druhyHrac, 200, true, true); //sázka na liché (1) červené (1)
           // Ruleta hra = new Ruleta();
           // Console.WriteLine($"Adam má z počátku na účtu {prvniHrac.Credit} kreditů");
           // Console.WriteLine($"David má z počátku na účtu {druhyHrac.Credit} kreditů");
           // Console.WriteLine();
           // hra.Vsad(prvniSazka);
           // hra.Vsad(druhaSazka);
           // Console.WriteLine();
           // hra.Roztoc();
           // Console.WriteLine();
           // Console.WriteLine($"Adam má nakonec na účtu {prvniHrac.Credit} kreditů");
           // Console.WriteLine($"David má nakonec na účtu {druhyHrac.Credit} kreditů");
           // Console.ReadKey(true);

        }
            
    }
}