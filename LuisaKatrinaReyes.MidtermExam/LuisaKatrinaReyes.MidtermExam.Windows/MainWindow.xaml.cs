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
        public title[] categorys { get; set; }
    }

    public class title
    {
        public string name { get; set; }
        [JsonProperty("menu-items")]
        public mItems[] mItems { get; set; }
    }

    public class mItems
    {
        public string name { get; set; }
        [JsonProperty("Sub-items")]
        public sItems[] sItems { get; set; }
    }

    public class sItems
    {
        public string name { get; set; }
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
            var area = JsonConvert.DeserializeObject<Menu>(File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "restomenu.json" ));
            int length = area.categorys.GetLength(0);

            for (int x = 0; x < length; x++)
            {
                TreeViewItem ParentItem = new TreeViewItem();
                ParentItem.Header = area.categorys[x].name;
                TreeView1.Items.Add(ParentItem);

                int length2 = area.categorys[x].mItems.GetLength(0);

                for (int y = 0; y < length2; y++)
                {
                    TreeViewItem Child1Item = new TreeViewItem();
                    Child1Item.Header = area.categorys[x].name + " - " + area.categorys[x].mItems[y].name;
                    ParentItem.Items.Add(Child1Item);

                    int length3 = area.categorys[x].mItems[y].sItems.GetLength(0);

                    for (int z = 0; z < length3; z++)
                    {
                        TreeViewItem SubItem = new TreeViewItem();
                        SubItem.Header = area.categorys[x].name + " - " + area.categorys[x].mItems[y].name + " - " + area.categorys[x].mItems[y].sItems[z].name;
                        Child1Item.Items.Add(SubItem);
                    }
                }
            }
        }

        private void TreeView1_MouseDoubleClick (object sender, MouseButtonEventArgs e)
        {
            var testing = JsonConvert.DeserializeObject<Menu>(File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "restomenu.json"));
            var selected = TreeView1.SelectedItem as TreeViewItem;
            var whatimlookingfor = selected.Header.ToString();


            string find = null;
            int length = testing.categorys.GetLength(0);
            for (int x = 0; x < length; ++x)
            {
                int length2 = testing.categorys[x].mItems.GetLength(0);
                for (int y = 0; y < length2; y++)
                {
                    int length3 = testing.categorys[x].mItems[y].sItems.GetLength(0);
                    for (int z = 0; z < length3; z++)
                    {
                        find = testing.categorys[x].name + " - " + testing.categorys[x].mItems[y].name + " - " + testing.categorys[x].mItems[y].sItems[z].name;
                        if (find == whatimlookingfor)
                        {

                            Form2 newWindow = new Form2(whatimlookingfor);
                            newWindow.Show();

                        }
                    }
                }
            }
        }
    }
}
