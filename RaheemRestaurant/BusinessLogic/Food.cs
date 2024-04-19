using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaheemRestaurant.BusinessLogic
{
    //Author Nawaf Raheem
    // Define a class named 'Food' to manage food items and their properties.
    public class Food
    {
        // Private field to store the quantity of the food item.
        private int _quantity;

        // Public field to store the price per unit of the food item.
        public double _price;

        // Public field to store the additional price for selected toppings.
        public double _toppingprice;

        // Public property to get or set the price of toppings.
        public double ToppingPrice
        {
            get => _toppingprice;
            set => _toppingprice = value;
        }

        // Public property to get or set the name of the food item.
        public string FoodName { get; set; }

        // Public property to get or set the quantity of the food item.
        public int Quantity { get { return _quantity; } set { _quantity = value; } }

        // Public property to get or set the price per unit of the food item.
        public double Price { get { return _price; } set { _price = value; } }

        // Public property to calculate the total cost of the food item, including the price of any selected toppings.
        public double Total { get { return (_price * _quantity) + _toppingprice; } }

        // Public properties to manage the addition of specific toppings to the food item.
        public bool Olives { get; set; }
        public bool Hummus { get; set; }
        public bool Fries { get; set; }
        public bool Garlic { get; set; }
        public bool Tahini { get; set; }

        // Default constructor for the Food class.
        public Food() { }

        // Constructor for the Food class that initializes the food item with specific attributes.
        public Food(int quantity, double price, bool olive, bool hummus, bool fries, bool garlic, bool tahini)
        {
            Price = price;    // Set the price per unit.
            Olives = olive;   // Initialize whether olives are included.
            Hummus = hummus;  // Initialize whether hummus is included.
            Fries = fries;    // Initialize whether fries are included.
            Garlic = garlic;  // Initialize whether garlic is included.
            Tahini = tahini;  // Initialize whether tahini is included.
            Quantity = quantity; // Set the quantity of the food item.
        }
    }
}
