using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace feleltetogep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<sqlOsztalyok> classList = new List<sqlOsztalyok>();
        List<sqlTanulok> studentList = new List<sqlTanulok>();
        List<sqlTanulok> akt = new List<sqlTanulok>();
        List<sqlTanulok> notHere = new List<sqlTanulok>();
        List<sqlFeleltek> feleltekNem = new List<sqlFeleltek>();
        List<sqlTanulok> feleltekMar = new List<sqlTanulok>();
        List<tanuloJegyek> tanuloJegy = new List<tanuloJegyek>();

        static bool listaba(List<sqlOsztalyok> keresList, string target)
        {
            bool listaba = false;
            for (int i = 0; i < keresList.Count; i++)
            {
                if (target == keresList[i].osztNev)
                {
                    listaba = true;
                }
            }
            return listaba;
        }
        static bool listabaTanulo(List<sqlTanulok> keresList, string target, int targetID)
        {
            bool listaba = false;
            for (int i = 0; i < keresList.Count; i++)
            {
                if (target == keresList[i].tnev && targetID == keresList[i].OsztID)
                {
                    listaba = true;
                }
            }
            return listaba;
        }

        public MainWindow()
        {
            InitializeComponent();
            loadSql();
        }

        public void loadSql()
        {
            dbconect firstCon = new dbconect("127.0.0.1", "db", "root", "");
            classList = firstCon.selectAllOsztalyok();
            osztalyokListBox.Items.Clear();
            osztalyokComboBox.Items.Clear();
            osztalyokComboBox2.Items.Clear();
            osztalyokComboBox3.Items.Clear();
            felelesBox.Items.Clear();
            for (int i = 0; i < classList.Count; i++)
            {
                osztalyokListBox.Items.Add(classList[i].osztNev);
                osztalyokComboBox.Items.Add(classList[i].osztNev);
                osztalyokComboBox2.Items.Add(classList[i].osztNev);
                osztalyokComboBox3.Items.Add(classList[i].osztNev);
                felelesBox.Items.Add(classList[i].osztNev);
                Console.WriteLine(classList[i].osztNev + "+" + classList[i].OsztID);
            }
            studentList = firstCon.selectAllTanulok();
            infoBlock.Text = "";
            for (int i = 0; i < studentList.Count; i++)
            {
                string osztnev = "";
                int OsztID = studentList[i].OsztID;

                for (int j = 0; j < classList.Count; j++)
                {
                    if (classList[j].OsztID == OsztID)
                    {
                        osztnev = classList[j].osztNev;
                    }
                }

                infoBlock.Text += $"{studentList[i].tnev} a {osztnev} osztályba jár. \n";
            }
            feleltekNem = firstCon.selectAllFeleltek();
            tanuloJegy = firstCon.selectAllTanuloJegyek();
        }

        private void osztAdd(object sender, RoutedEventArgs e)
        {
            sqlOsztalyok temp = new sqlOsztalyok();
            dbconect con = new dbconect("127.0.0.1", "db", "root", "");

            if (classList.Count < 1)
            {
                osztalyokListBox.Items.Add(osztalyokAddInput.Text);
                temp.osztNev = osztalyokAddInput.Text;
                classList.Add(temp);
                con.InstertData(temp);
            }
            else
            {
                if (!listaba(classList, osztalyokAddInput.Text))
                {
                    osztalyokListBox.Items.Add(osztalyokAddInput.Text);
                    temp.osztNev = osztalyokAddInput.Text;
                    classList.Add(temp);
                    con.InstertData(temp);
                }
                else
                {
                    MessageBox.Show("Ez már benne van a tábláan!", "Whoops!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            loadSql();
        }

        private void tanuloAdd(object sender, RoutedEventArgs e)
        {
            sqlTanulok temp = new sqlTanulok();
            dbconect con = new dbconect("127.0.0.1", "db", "root", "");
            string osztnev = osztalyokComboBox.Text;
            int OsztID = 0;

            for (int i = 0; i < classList.Count; i++)
            {
                if (classList[i].osztNev == osztnev)
                {
                    OsztID = classList[i].OsztID;
                }
            }


            if (!listabaTanulo(studentList, tanuloNev.Text, OsztID))
            {
                osztalyokListBox.Items.Add(osztalyokAddInput.Text);
                temp.tnev = tanuloNev.Text;
                temp.OsztID = OsztID;
                studentList.Add(temp);
                con.InstertDataTanulok(temp);
            }
            else
            {
                MessageBox.Show("Ez már benne van!", "saad", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            loadSql();
        }

        private int soroltT;
        private void sorsol(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Sorsolas....");
            akt.Clear();
            feleltekMar.Clear();
            for (int i = 0; i < studentList.Count; i++)
            {
                for (int j = 0; j < feleltekNem.Count; j++)
                {
                    if (studentList[i].Tanid == feleltekNem[j].felelt)
                    {
                        feleltekMar.Add(studentList[i]);
                    }
                }
            }
            string valasztottOszt = felelesBox.Text;
            int OsztID = 0;
            for (int i = 0; i < classList.Count; i++)
            {
                if (classList[i].osztNev == valasztottOszt)
                {
                    OsztID = classList[i].OsztID;
                }
            }
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].OsztID == OsztID)
                {
                    akt.Add(studentList[i]);
                }
            }
            for (int j = 0; j < feleltekMar.Count; j++)
            {
                akt.Remove(feleltekMar[j]);
            }
            for (int j = 0; j < notHere.Count; j++)
            {
                akt.Remove(notHere[j]);
            }
            try
            {
                Random ran = new Random();
                soroltT = ran.Next(0, akt.Count);
                jelenlegifelelo.Text = akt[soroltT].tnev;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Már mindenki felelt!");
            }
        }

        private void isHere(object sender, RoutedEventArgs e)
        {
            dbconect con = new dbconect("127.0.0.1", "db", "root", "");
            sqlFeleltek felelt = new sqlFeleltek();
            felelt.felelt = akt[soroltT].Tanid;
            con.InstertDataFelelt(felelt);
            feleltekNem.Add(felelt);
            MessageBox.Show("OK", "OK", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void isNotHere(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].tnev == jelenlegifelelo.Text)
                {
                    notHere.Add(studentList[i]);
                }
            }
        }

        private void ertekel(object sender, RoutedEventArgs e)
        {
            dbconect con = new dbconect("127.0.0.1", "db", "root", "");
            int jegy = Convert.ToInt32(jegyek.Text);
            string ertekelendoDiak = jelenlegifelelo.Text;
            int jtid = 0;
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].tnev == ertekelendoDiak)
                {
                    jtid = studentList[i].Tanid;
                }
            }

            con.InsertIntoOsztalyzatok(jtid, jegy);
            MessageBox.Show($"{ertekelendoDiak} sikeresen értékelve! ({jegy})", "huhu", MessageBoxButton.OK, MessageBoxImage.Information);
            jelenlegifelelo.Text = "";
            loadSql();
        }

        private void osztalyzatMutat(object sender, RoutedEventArgs e)
        {
            tanulokJegyeListBox.Items.Clear();
            int oid = -1;
            for (int i = 0; i < classList.Count; i++)
            {
                if (classList[i].osztNev == osztalyokComboBox2.Text)
                {
                    oid = classList[i].OsztID;
                }
            }
            for (int i = 0; i < tanuloJegy.Count; i++)
            {
                if (tanuloJegy[i].OsztID == oid)
                {
                    tanulokJegyeListBox.Items.Add(tanuloJegy[i].ToString());
                }
            }
        }

        private void torolFelel(object sender, RoutedEventArgs e)
        {
            dbconect con = new dbconect("127.0.0.1", "db", "root", "");
            int Tanid = -1;
            int ind = -1;
            for (int i = 0; i < studentList.Count; i++)
            {
                if (feleltTanulokListBox.SelectedItem.ToString() == studentList[i].tnev)
                {
                    Tanid = studentList[i].Tanid;
                    ind = i;
                }
            }
            var itemToRemove = feleltekNem.Single(x => x.felelt == Tanid);
            feleltekNem.Remove(itemToRemove);
            con.DeleteFelelo(Tanid);
            MessageBox.Show("Felelő törölve!", "huhu!", MessageBoxButton.OK);
            loadSql();
            feleltTanulokListBox.Items.Remove(studentList[ind].tnev);
        }

        private void torolFelelAll(object sender, RoutedEventArgs e)
        {
            dbconect con = new dbconect("127.0.0.1", "db", "root", "");
            feleltekNem.Clear();
            con.DeleteFelelok();
            MessageBox.Show("Felelők törölve!", "huhu!", MessageBoxButton.OK);
            loadSql();
            feleltTanulokListBox.Items.Clear();
        }

        private void tanulokMutat(object sender, RoutedEventArgs e)
        {
            feleltekMar.Clear();
            for (int i = 0; i < studentList.Count; i++)
            {
                for (int j = 0; j < feleltekNem.Count; j++)
                {
                    if (studentList[i].Tanid == feleltekNem[j].felelt)
                    {
                        feleltekMar.Add(studentList[i]);
                    }
                }
            }
            feleltTanulokListBox.Items.Clear();
            int oid = -1;
            for (int i = 0; i < classList.Count; i++)
            {
                if (classList[i].osztNev == osztalyokComboBox3.Text)
                {
                    oid = classList[i].OsztID;
                }
            }
            for (int i = 0; i < feleltekMar.Count; i++)
            {
                if (feleltekMar[i].OsztID == oid)
                {
                    feleltTanulokListBox.Items.Add(feleltekMar[i].tnev);
                }
            }
        }
    }
}
