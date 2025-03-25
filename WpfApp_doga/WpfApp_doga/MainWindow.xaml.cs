using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft;
using Microsoft.Win32;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Collections;


namespace WpfApp_doga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<eu_orszagok> list = new List<eu_orszagok>();
        static List<eu_orszagok> beolv(string fnev)
        {
            FileStream fs = new FileStream(fnev, FileMode.Open);
            using (var reader = new StreamReader(fs, Encoding.UTF8))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<eu_orszagok>().ToList();
                fs.Close();
                return records;
            }
            
        }

        private void Megnyit_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Csv fájlok(*.csv)|*.csv|Minden fájl(*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == true)
            {
                dataGrid1.ItemsSource = beolv(openFileDialog1.FileName);
                list = beolv(openFileDialog1.FileName);
            }
            alapit();
            felt();
        }

        private void Ment_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "Csv fájlok(*.csv)|*.csv|Minden fájl(*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                using (var writer = new StreamWriter(fs, Encoding.UTF8))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(list);
                }
                fs.Close();
            }
        }

        private void resultB_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.ItemsSource != null)
            {
                var label = RadioResult;
                if ((bool)kTer.IsChecked)
                {
                    int kt = list.Min(eu_orszagok => eu_orszagok.Terulet);
                    int index = list.FindIndex(a => a.Terulet == kt);
                    label.Content = list[index].Nev;
                }
                else if ((bool)lTer.IsChecked)
                {
                    int kt = list.Max(eu_orszagok => eu_orszagok.Terulet);
                    int index = list.FindIndex(a => a.Terulet == kt);
                    label.Content = list[index].Nev;
                }
                else if ((bool)kNep.IsChecked)
                {
                    int kt = list.Min(eu_orszagok => eu_orszagok.Nepesseg);
                    int index = list.FindIndex(a => a.Nepesseg == kt);
                    label.Content = list[index].Nev;
                }
                else if ((bool)lNep.IsChecked)
                {
                    int kt = list.Max(eu_orszagok => eu_orszagok.Nepesseg);
                    int index = list.FindIndex(a => a.Nepesseg == kt);
                    label.Content = list[index].Nev;
                }
            }
        }

        public void alapit()
        {
            List<string> alapL = new List<string>();
            int alapdb = 0; 
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Bdatum == "alapító")
                {
                    alapL.Add(list[i].Nev);
                    alapdb++;
                }
            }
            alapdb1.Content = alapdb;
            listView1.ItemsSource = alapL;
        }

        public void felt()
        {
            List<string> kezdobetuk = new List<string>();
            kezdobetuk.Add(list[0].Nev.Substring(0, 1).ToString());
            comboBox1.Items.Add(list[0].Nev.Substring(0, 1).ToString());
            for (int i = 1; i < list.Count; i++)
            {
                int vandb = 0;
                for (int j = 0; j < kezdobetuk.Count; j++)
                {
                    if (kezdobetuk[j] == list[i].Nev.Substring(0, 1).ToString())
                    {
                        vandb++;
                    }
                }
                if (vandb == 0)
                {
                    kezdobetuk.Add(list[i].Nev.Substring(0, 1).ToString());
                    comboBox1.Items.Add(list[i].Nev.Substring(0, 1).ToString());
                }
            }
        }

        private void szuro_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                if (comboBox1.SelectedItem.ToString() == list[i].Nev.Substring(0, 1).ToString())
                {
                    listBox1.Items.Add(list[i].Nev);
                }
            }
        }
    }
}
