using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleltetogep
{
    internal class sqlFeleltek
    {
        public sqlFeleltek(int felelt)
        {
            this.felelt = felelt;
        }

        public sqlFeleltek()
        {
        }
        public int felelt { get; set; }

    }
}