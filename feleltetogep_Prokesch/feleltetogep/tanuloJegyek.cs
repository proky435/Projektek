using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleltetogep
{
    internal class tanuloJegyek
    {
        private int tanid;
        private string tnev;
        private int osztID;
        private int jegy;

        public tanuloJegyek(int tanid, string tnev, int osztID, int jegy)
        {
            this.Tanid = tanid;
            this.Tnev = tnev;
            this.OsztID = osztID;
            this.Jegy = jegy;
        }

        public int Tanid { get => tanid; set => tanid = value; }
        public string Tnev { get => tnev; set => tnev = value; }
        public int OsztID { get => osztID; set => osztID = value; }
        public int Jegy { get => jegy; set => jegy = value; }

        public override string ToString()
        {
            return $"Tanuló neve: {Tnev} Tanuló osztályzata: {Jegy}";
        }
    }
}
