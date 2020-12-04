using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIns_Repository
{

    public class Developer
    {
        public string Name { get; set; }
        public int IDnumber { get; set; }
        public bool AccessToPluralsight { get; set; }

        public Developer() { }

        public Developer(string name, int idNumber, bool accessToPluralsight)
        {
            Name = name;
            IDnumber = idNumber;
            AccessToPluralsight = accessToPluralsight;
        }

    }
}
