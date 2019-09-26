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

namespace LuisaKatrinaReyes.MidtermExam.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TreeViewItem Parent1Item = new TreeViewItem();
            Parent1Item.Header = "Menu";
            TreeView1.Items.Add(Parent1Item);
            //

            TreeViewItem Child1Item = new TreeViewItem();
            Child1Item.Header = "Appeteasers";
            Parent1Item.Items.Add(Child1Item);
            //
            TreeViewItem Child2Item = new TreeViewItem();
            Child2Item.Header = "Fino Sides";
            Parent1Item.Items.Add(Child2Item);
            //
        }

    }
}
