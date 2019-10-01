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
using Newtonsoft.Json;
using System.IO;

namespace LuisaKatrinaReyes.MidtermExam.Windows
{

    public class Menu
    {
        public title categorys { get; set; }
    }

    public class title
    {
        public string name { get; set; }
        [JsonProperty("menu-items")]
        public string mItems { get; set; }
    }

    public class mItems
    {
        public string name { get; set; }
        [JsonProperty("Sub-items")]
        public string sItems { get; set; }
    }

    public class sItems
    {
        public string price { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
