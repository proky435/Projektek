using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleltetogep
{
    internal class sqlTanulok
    {
        public int Tanid { get; set; }
        public string tnev { get; set; }
        public int OsztID { get; set; }

        public sqlTanulok(int Tanid, string tnev, int OsztID)
        {
            this.Tanid = Tanid;
            this.tnev = tnev;
            this.OsztID = OsztID;
        }
        public sqlTanulok()
        {

        }
    }
}
