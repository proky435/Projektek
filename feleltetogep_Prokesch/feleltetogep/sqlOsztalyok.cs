using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleltetogep
{
    internal class sqlOsztalyok
    {
        public int OsztID { get; set; }
        public string osztNev { get; set; }

        public sqlOsztalyok()
        {
        }
        public sqlOsztalyok(string osztNev)
        {
            this.osztNev = osztNev;
        }
        public sqlOsztalyok(int id, string osztNev)
        {
            this.osztNev = osztNev;
            this.OsztID = id;
        }
    }
}