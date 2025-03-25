using System;
using System.Collections.Generic;
using System.IO;

namespace metjelentes
{
    class Meres
    {
        public string Hely { get; set; }
        public string Ido { get; set; }
        public string Szel { get; set; }
        public int Fok { get; set; }

        public Meres(string adatsor)
        {
            string[] adatok = adatsor.Split(' ');
            Hely = adatok[0];
            Ido = adatok[1].Insert(2,":");
            Szel = adatok[2];
            Fok = int.Parse(adatok[3]);
        }
    }

    class Telep
    {
        public string Hely { get; set; }
        public double Osszeg { get; set; }
        public int Darab { get; set; }
        public bool[] Idoben { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }

        List<KeyValuePair<string, int>> szelero;

        public Telep(Meres m)
        {
            Hely = m.Hely;
            Osszeg = 0;
            Darab = 0;
            Idoben = new bool[4];
            for (int i = 0; i < 4; i++)
            {
                Idoben[i] = false; //nem kell, mert alapból false, csak az olvashatóság miatt.
            }
            Max = m.Fok;
            Min = m.Fok;
            szelero = new List<KeyValuePair<string, int>>();
            Admin(m.Ido, m.Szel, m.Fok);
        }
        public void Admin(string ido, string szel, int fok)
        {
            szelero.Add(new KeyValuePair<string, int>(ido, int.Parse(szel.Substring(3, 2))));
            if (fok > Max) Max = fok;
            if (fok < Min) Min = fok;
            /*1, 7, 13, 19, azaz hatóránként kell nézni*/
            if(int.Parse(ido.Substring(0, 2)) % 6 == 1)
            {
                Osszeg += fok;
                Darab++;
                Idoben[int.Parse(ido.Substring(0, 2)) / 6] = true;
            }
        }

        public void Kiir()
        {
            StreamWriter sw = new StreamWriter(Hely+".txt");
            sw.WriteLine(Hely);
            for (int i = 0; i < szelero.Count; i++)
            {
                sw.Write(szelero[i].Key + " ");
                for (int j = 0; j <szelero[i].Value; j++)
                {
                    sw.Write("#");
                }
                sw.WriteLine();
            }
            sw.Close();
        }
    }

    class Program
    {
        static List<Meres> meres = new List<Meres>();
        static List<Telep> telepules = new List<Telep>();
 
        static void Main(string[] args)
        {
            #region 1. beolvasás
            StreamReader sr = new StreamReader("tavirathu13.txt");
            while (!sr.EndOfStream)
            {
                meres.Add(new Meres(sr.ReadLine()));
            }
            sr.Close();
            #endregion

            Console.WriteLine("2. feladat");
            Console.Write("Adja meg egy település kódját! Település: ");
            string telepkod = Console.ReadLine();
            Console.WriteLine("Az utolsó mérési adat a megadott településről {0}-kor érkezett.", UtolsoMeres(telepkod));

            Console.WriteLine("3. feladat");
            MinMax();

            Console.WriteLine("4. feladat");
            //valamint az 5-6. feladat előkészítése
            for (int i = 0; i < meres.Count; i++)
            {
                if (meres[i].Szel=="00000")
                {
                    Console.WriteLine("{0} {1}", meres[i].Hely, meres[i].Ido);
                }

                //település keresése a kigyűjtöttek között
                int j = 0;
                while (j < telepules.Count && telepules[j].Hely != meres[i].Hely)
                    j++;

                if (j<telepules.Count) //ha már felvettük a települést, akkor csak az új értékek adminisztrálása
                {
                    telepules[j].Admin(meres[i].Ido, meres[i].Szel, meres[i].Fok);
                }
                else //új település felvétele és adminisztrálása
                {
                    telepules.Add(new Telep(meres[i]));
                }
            }
            
            Console.WriteLine("5. feladat");
            for (int i = 0; i < telepules.Count; i++)
            {
                string kh = (telepules[i].Idoben[0] && telepules[i].Idoben[1] && telepules[i].Idoben[2] && telepules[i].Idoben[3]) ?
                    "Középhőmérséklet:" + (telepules[i].Osszeg / telepules[i].Darab).ToString("#0") : "NA";
                
                Console.WriteLine("{0} {1}; Hőmérséklet-ingadozás: {2}", telepules[i].Hely, kh, telepules[i].Max-telepules[i].Min );
            }
            
            Console.WriteLine("6. feladat");
            for (int i = 0; i < telepules.Count; i++)
            {
                telepules[i].Kiir();
            }
            Console.WriteLine("A fájlok elkészültek");

            Console.ReadLine();
        }

        private static void MinMax()
        {
            int minh = 0;
            int maxh = 0;
            for (int i = 1; i < meres.Count; i++)
            {
                if (meres[i].Fok > meres[maxh].Fok)
                {
                    maxh = i;
                }
                if (meres[i].Fok < meres[minh].Fok)
                {
                    minh = i;
                }
            }
            Console.WriteLine("A legalacsonyabb hőmérséklet: {0} {1} {2} fok.", meres[minh].Hely, meres[minh].Ido, meres[minh].Fok);
            Console.WriteLine("A legmagasabb hőmérséklet: {0} {1} {2} fok.", meres[maxh].Hely, meres[maxh].Ido, meres[maxh].Fok);
        }

        private static string UtolsoMeres(string telepkod)
        {
            int i;
            for (i = meres.Count - 1; i >= 0 && meres[i].Hely != telepkod; i--)
                ;
            return i >= 0 ? meres[i].Ido : "NA:NA";
        }
    }
}
