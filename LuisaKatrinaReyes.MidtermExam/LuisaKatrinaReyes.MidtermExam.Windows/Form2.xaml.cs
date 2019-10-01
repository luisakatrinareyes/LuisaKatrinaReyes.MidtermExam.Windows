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
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace LuisaKatrinaReyes.MidtermExam.Windows
{
        
        public partial class Form2 : Window
    {
        string item;
        public Form2(string whatimlookingfor)
        {
            InitializeComponent();
            this.item = whatimlookingfor;
        }
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
            public string description { get; set; }
        }

        public class sItems
        {
            public string name { get; set; }
            public string price { get; set; }
            public dis discount { get; set; }
        }

        public class dis
        {
            public string amount { get; set; }
        }

        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            var theitem = item;
            var testing = JsonConvert.DeserializeObject<Menu>(File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "restomenu.json"));
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
                        if (find == item)
                        {
                            lblName.Content = "Product: " + testing.categorys[x].mItems[y].name;
                            lblPrice.Content = "Price: " + testing.categorys[x].mItems[y].sItems[z].price;
                            lblDesc.Content = "Desc: " + testing.categorys[x].mItems[y].description;
                            lblDiscount.Content = "Discount: " + testing.categorys[x].mItems[y].sItems[z].discount.amount;

                        }
                    }
                }
            }
        }
    }
}