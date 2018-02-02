using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        ObservableCollection<Products> product;
        private string path = "data.json";
        public MainWindow()
        {
            InitializeComponent();

            FileRead();

            if (product.Count == 0)
            {
                product.Add(new Products() { City = "Астана", DeliveryPrise = 20 });
                product.Add(new Products() { City = "Алмата", DeliveryPrise = 40 });
                product.Add(new Products() { City = "Костанай", DeliveryPrise = 60 });
            }
            dataGrid.ItemsSource = product;

            FileWrite();
        }

        private void FileRead()
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamReader stream = new StreamReader(fileStream))
                {
                    using (JsonTextReader reader = new JsonTextReader(stream))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        product = serializer.Deserialize<ObservableCollection<Products>>(reader);
                        if (product == null) product = new ObservableCollection<Products>();
                    }
                }
            }
        }
        private void FileWrite()
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter stream = new StreamWriter(fileStream))
                {
                    using (JsonTextWriter writer = new JsonTextWriter(stream))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(writer, product);
                    }
                }
            }
        }
    }
}
