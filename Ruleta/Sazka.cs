using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta
{
    public class Sazka
    {
        public Hrac Hrac { get; set; }
        public int VyseSazky { get; set; }
        public bool LicheNeboSude { get; set; }
        public bool CerveneNeboCerne { get; set; } //cervena - true
        public bool Uspesna { get; set; }
        
        public Sazka(Hrac hrac, int vyseSazky, bool licheNeboSude, bool cerveneNeboCerne)
        {
            Hrac = hrac;
            VyseSazky = vyseSazky;
            LicheNeboSude = licheNeboSude;
            CerveneNeboCerne = cerveneNeboCerne;
            Uspesna = false;
        }



    }
}
