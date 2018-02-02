using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp8
{
   public class Products
    {
        private int profit;
        private int price;
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                ValuesChanged("Price");
            }
        }
        private int deliveryPrise;
        public int DeliveryPrise
        {
            get
            {
                return deliveryPrise;
            }
            set
            {
                deliveryPrise = value;
            }
        }

        public string City { get; set; }
        public int Profit
        {
            get
            {
                return profit;
            }
            set
            {
                profit = value;
                OnPropertyChanged("Profit");
            }
        }

        public event Action SomethingChanged;
        private void ValuesChanged(string propertyName)
        {
            Profit = price - DeliveryPrise;
            OnPropertyChanged(propertyName);
            SomethingChanged?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
