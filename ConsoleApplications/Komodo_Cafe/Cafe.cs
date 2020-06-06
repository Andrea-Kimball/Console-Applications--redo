using System;
using System.Collections.Generic;
using System.Collections; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe
{
    public class Cafe
    {
        //define properties
        public int MealId { get; set; }
        public string MealName { get; set; }        
        public string Description { get; set; }
        public string Ingredients { get; set; } 
        public double Price { get; set; }


        //constructors
        public Cafe() { }

        public Cafe(int mealId, string mealname,  string description, string ingredients, double price) 
        {
            MealId = mealId;
            MealName = mealname;           
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
