using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Mohammad Raja

namespace RaheemRestaurant.BusinessLogic
{
    // Define a class named 'ShoppingCart' to manage the shopping cart functionality in the restaurant application.
    public class ShoppingCart
    {
        // Private dictionaries to store the main courses, appetizers, and desserts along with their quantities.
        private Dictionary<string, int> _mainCourses;
        private Dictionary<string, int> _appetizers;
        private Dictionary<string, int> _desserts;

        // Constructor to initialize the shopping cart with empty dictionaries for main courses, appetizers, and desserts.
        public ShoppingCart()
        {
            _mainCourses = new Dictionary<string, int>();
            _appetizers = new Dictionary<string, int>();
            _desserts = new Dictionary<string, int>();
        }

        // Public method to add a main course item to the shopping cart.
        public void AddMainCourse(string itemName, int quantity)
        {
            AddItem(_mainCourses, itemName, quantity);
        }

        // Public method to add an appetizer item to the shopping cart.
        public void AddAppetizer(string itemName, int quantity)
        {
            AddItem(_appetizers, itemName, quantity);
        }

        // Public method to add a dessert item to the shopping cart.
        public void AddDessert(string itemName, int quantity)
        {
            AddItem(_desserts, itemName, quantity);
        }

        // Private helper method to add an item to a specific category in the shopping cart.
        private void AddItem(Dictionary<string, int> category, string itemName, int quantity)
        {
            if (category.ContainsKey(itemName))
            {
                category[itemName] += quantity; // If the item is already in the cart, increment the quantity.
            }
            else
            {
                category.Add(itemName, quantity); // If the item is not in the cart, add it with the specified quantity.
            }
        }

        // Public method to list all items in the shopping cart, categorized by type.
        public void ListItems()
        {
            Console.WriteLine("Shopping Cart:");
            Console.WriteLine("Main Courses:");
            ListCategoryItems(_mainCourses);

            Console.WriteLine("Appetizers:");
            ListCategoryItems(_appetizers);

            Console.WriteLine("Desserts:");
            ListCategoryItems(_desserts);
        }

        // Private helper method to list items from a specific category in the shopping cart.
        private void ListCategoryItems(Dictionary<string, int> category)
        {
            foreach (var item in category)
            {
                Console.WriteLine($"{item.Key}: {item.Value}"); // Print each item and its quantity.
            }
        }
    }
}