using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace WpfApp_doga
{
    internal class eu_orszagok
    {

        [Name(name: "[Név]")]
        public string Nev { get ; set; }
        [Name(name: "[Főváros]")]
        public string Fovaros { get; set; }
        [Name(name: "[Belépés dátuma]")]
        public string Bdatum { get; set; }
        [Name(name: "[Népesség]")]
        public int Nepesseg { get; set; }
        [Name(name: "[Terület]")]
        public int Terulet { get; set; }
    }
}
