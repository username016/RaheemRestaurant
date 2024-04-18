using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaheemRestaurant.BusinessLogic
{
    //Author Nawaf Raheem

    public class Food
    {
        private int _quantity;
        public double _price;
        public double _toppingprice;

        public double ToppingPrice
        {
            get => _toppingprice;
            set => _toppingprice = value;

        }

        public string FoodName { get; set; }

        public int Quantity { get { return _quantity; } set { _quantity = value; } }

        public double Price { get { return _price; } set { _price = value; } }

        public double Total { get { return (_price * _quantity) + _toppingprice;  } }

        public bool Olives { get; set; }
        public bool Hummus { get; set; }
        public bool Fries { get; set; }
        public bool Garlic { get; set; }
        public bool Tahini { get; set; }


        public Food() { }

        public Food(int quantity, double price, bool olive, bool hummus, bool fries,bool garlic, bool tahini )
        {

            Price = price;
             
            Olives = olive;

            Hummus = hummus;

            Fries = fries;

            Garlic = garlic;

            Tahini = tahini;

            Quantity = quantity;

        }


    }
}
