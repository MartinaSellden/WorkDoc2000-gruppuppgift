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
using System.IO;
using Microsoft.Win32;

namespace WorkDoc2000_gruppuppgift
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCountWords_Click(object sender, RoutedEventArgs e)
        {
            string input = myTextBox.Text;
            string [] words = input.Split(" ");
            int count = words.Length;
            MessageBox.Show("Antal ord: " + count,"Antal ord");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by ex

            Nullable<bool> result = dlg.ShowDialog(); // Show save file dialog box


            File.WriteAllText(dlg.FileName, myTextBox.Text);
            //File.WriteAllText("Testfile.txt", myTextBox.Text);
            //MessageBox.Show("Testfile.txt sparad!", "Sparat filen");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //myTextBox.Text = File.ReadAllText("Testfile.txt");
            OpenFileDialog dlg = new OpenFileDialog();          
            dlg.Filter = "Text documents (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            myTextBox.Text = File.ReadAllText(dlg.FileName);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            count++;

            if (count%2==0)
            {
                myTextBox.Text = myTextBox.Text.ToUpper();
            }
            else
            {
                myTextBox.Text = myTextBox.Text.ToLower();

            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string input = myTextBox.Text;
            string[] sentences = input.Split(". ");
            string text = "";
            foreach (var sentence in sentences)
            {
                text += sentence[0].ToString().ToUpper()+sentence.Substring(1)+". ";  //kolla varför det blir Index out of bounds när den har omvandlat texten. (Efter sista punkten och mellanrummet)
            }
                myTextBox.Text = text;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string text = myTextBox.Text;
            myTextBox.Text = text.Replace('e','3').Replace('a','4').Replace('i','1').Replace('g','6').Replace('o','0').Replace('E', '3').Replace('A', '4').Replace('I', '1').Replace('G', '6').Replace('O', '0');
           
        }
    }
}
