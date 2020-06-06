using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe
{
    public class Cafe_Repository
    {
        private List<Cafe> _cafeObjectList = new List<Cafe>();

        //CREATE
        public void CreateMeal(Cafe content)
        {
            _cafeObjectList.Add(content);
        }

        //READ
        public List<Cafe> ViewMealList()
        {
            return _cafeObjectList;
        }

        //UPDATE
        public bool UpdateMeal(int id, Cafe newname)
        {
            Cafe original = GetMenuItembyId(id);
            if(original != null)
            {
                original.MealId = newname.MealId;
                original.MealName = newname.MealName;
                original.Description = newname.Description;
                original.Ingredients = newname.Ingredients;
                original.Price = newname.Price;
                return true;
            }
            else
            {
                return false;
            }

        }

        //DELETE
        public bool DeleteMeal(int mealId)
        {
            Cafe item = GetMenuItembyId(mealId);
            if(item == null)
            {
                return false;
            }

            int initialCount = _cafeObjectList.Count;
            _cafeObjectList.Remove(item);
            if (initialCount > _cafeObjectList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //helper method
        public Cafe GetMenuItembyId(int mealId)
        {
            foreach(Cafe item in _cafeObjectList)
            {
                if(item.MealId == mealId)
                {
                    return item;
                }                 
            }
            return null;
        } 
    }
}
