using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Mohammad Raja

namespace RaheemRestaurant.BusinessLogic
{
    public class ShoppingCart
    {

        private Dictionary<string, int> _mainCourses;
        private Dictionary<string, int> _appetizers;
        private Dictionary<string, int> _desserts;

        public ShoppingCart()
        {
            _mainCourses = new Dictionary<string, int>();
            _appetizers = new Dictionary<string, int>();
            _desserts = new Dictionary<string, int>();
        }

        // Add a main course item
        public void AddMainCourse(string itemName, int quantity)
        {
            AddItem(_mainCourses, itemName, quantity);
        }

        // Add an appetizer item
        public void AddAppetizer(string itemName, int quantity)
        {
            AddItem(_appetizers, itemName, quantity);
        }

        // Add a dessert item
        public void AddDessert(string itemName, int quantity)
        {
            AddItem(_desserts, itemName, quantity);
        }

        // Helper method to add an item to a specific dictionary
        private void AddItem(Dictionary<string, int> category, string itemName, int quantity)
        {
            if (category.ContainsKey(itemName))
            {
                category[itemName] += quantity;
            }
            else
            {
                category.Add(itemName, quantity);
            }
        }

        // List all items in the cart
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

        // Helper method to list items in a specific category
        private void ListCategoryItems(Dictionary<string, int> category)
        {
            foreach (var item in category)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }


    }
}
