using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta
{
    public class Hrac
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Credit { get; set; }
        public string Password { get; set; }
        public bool AutoPlay { get; set; }

       public Hrac(string name, string lastName, string password,int credit,bool autoPlay)
        {
            Name = name;
            LastName = lastName;
            
            Password = password;
            AutoPlay = autoPlay;
            Credit = credit;
            
        }



    }
}
