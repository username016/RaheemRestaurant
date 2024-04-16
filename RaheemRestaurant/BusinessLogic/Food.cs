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
        public string FoodName { get; set; }

        public double Price { get; set; }  

        public bool Olives { get; set; }
        public bool Humus { get; set; }
        public bool Fries { get; set; }
        public bool Garlic { get; set; }
        public bool Tahini { get; set; }


        public Food() { }

        public Food( double price, bool olive, bool humus, bool fries,bool garlic, bool tahini )
        {

            Price = price;
             
            Olives = olive;

            Humus = humus;

            Fries = fries;

            Garlic = garlic;

            Tahini = tahini;
        }


    }
}
