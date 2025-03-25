using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleltetogep
{
    internal class jegyekLekérdez
    {
        public int jegy { get; set; }
        public string tnev { get; set; }
        public string osztNev { get; set; }

        public jegyekLekérdez()
        {

        }

        public jegyekLekérdez(int jegy, string tnev, string osztNev)
        {
            this.jegy = jegy;
            this.tnev = tnev;
            this.osztNev = osztNev;
        }
    }
}