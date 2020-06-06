using Komodo_Cafe;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class ProgramUI
    {

        private Cafe_Repository _cafeRepository = new Cafe_Repository();

        //method that starts the UI
        public void Run()
        {
            SeedMenuItems();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options
                Console.WriteLine("Select an option below: \n" +
                    "\n" +
                    "1.Create a new menu item \n" +
                    "2. View all menu items \n" +
                    "3. View menu items by ID \n" +
                    "4. Update a menu item \n" +
                    "5. Delete a menu item \n" +
                    "6. Exit");

                //Get users input
                string input = Console.ReadLine();
                //evaluate user input
                switch (input)
                {
                    case "1":
                        //create new menu items
                        CreateMenuItem();
                        break;
                    case "2":
                        //view all menu items
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        //view menus by ID
                        ViewMenuItemById();
                        break;
                    case "4":
                        //update a menu item
                        UpdateMenuItem();
                        break;
                    case "5":
                        //Delete a menu item
                        DeleteMenuItem();
                        break;
                    case "6":
                        //exit
                        Console.WriteLine("GoodBye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("please enter a valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            
        }

       private void CreateMenuItem()
        {
            Console.Clear();
            Cafe newItem = new Cafe();

            //meal name
            Console.WriteLine("Enter menu item name:");
            newItem.MealName = Console.ReadLine();

            //description
            Console.WriteLine("Enter menu item description:");
            newItem.Description = Console.ReadLine();

            //ingredients
            Console.WriteLine("Enter menu item ingredients separated by comma:");
            newItem.Ingredients = string.Join(",",Console.ReadLine());
                        
            

            //price
            Console.WriteLine("Enter menu item price:");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            _cafeRepository.CreateMeal(newItem);

        }
        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<Cafe> listOfContent = _cafeRepository.ViewMealList();
            foreach(Cafe item in listOfContent)
            {
                Console.WriteLine($"Id: {item.MealId} \n" +
                    $"Name: {item.MealName} \n" +
                    $"Description:{item.Description}");
            }
        }
        private void ViewMenuItemById()
        {
            Console.Clear();
            DisplayAllMenuItems();

            Console.WriteLine("Which item would you like to view?");
            var input = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Cafe itemId = _cafeRepository.GetMenuItembyId(input);
            if(itemId != null)
            {
                Console.WriteLine($"youve selected Id: {itemId.MealId}");
                Console.WriteLine($"Name: {itemId.MealName}");
                Console.WriteLine($"Description: {itemId.Description}");
                Console.WriteLine($"Ingredients: {itemId.Ingredients}");
                Console.WriteLine($"Price: {itemId.Price}");
            }
            else
            {
                Console.WriteLine($"youve selected Id: " + input);
                Console.WriteLine("No menu item by that Id could be found");
            }
            
            

        }
        private void UpdateMenuItem()
        {
            Console.Clear();
            DisplayAllMenuItems();

            Console.WriteLine("Which item would you like to update?");
            var input = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Cafe newItem = new Cafe();

            //meal name
            Console.WriteLine("Enter menu item new name:");
            newItem.MealName = Console.ReadLine();

            //description
            Console.WriteLine("Enter menu item new description:");
            newItem.Description = Console.ReadLine();

            //ingredients
            Console.WriteLine("Enter menu item new ingredients separated by comma:");
            newItem.Ingredients = Console.ReadLine();



            //price
            Console.WriteLine("Enter menu item new price:");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            bool wasUpdated= _cafeRepository.UpdateMeal(input, newItem);
            if (wasUpdated)
            {
                Console.WriteLine("Menu item updated");
            }
            else
            {
                Console.WriteLine("unable to update menu item");
            }

        }
        private void DeleteMenuItem()
        {
            Console.Clear();
            DisplayAllMenuItems();
            Console.WriteLine("Which item would you like to Remove?");
            var input = Convert.ToInt32(Console.ReadLine());
            bool wasDeleted = _cafeRepository.DeleteMeal(input);
            if (wasDeleted)
            {
                Console.WriteLine("This item was succesfully deleted");
            }
            else
            {
                Console.WriteLine($"youve selected Id: " + input);
                Console.WriteLine("No menu item by that Id could be found");
            }

        }
    
        //Seed method
        private void SeedMenuItems()
        {
            
            //int mealId, string mealname,  string description, List<string> ingredients, double price

            Cafe burger = new Cafe(1, "Burger Meal", "Hamburger with fires and a small drink",string.Join(",","burger, fries, soda"), 5.99) ; 
            Cafe chickenSandwich = new Cafe(2, "Chicken Sandwich Meal", "Chicken sandwich with fires and a small drink", string.Join(",", "Chicken Sandwich, fries, soda"), 5.99);
            Cafe nuggets = new Cafe(3, "Chicken nuggets Meal", "nuggets with fires and a small drink", string.Join(",", "nuggets, fries, soda"), 5.99);

            _cafeRepository.CreateMeal(burger);
            _cafeRepository.CreateMeal(chickenSandwich);
            _cafeRepository.CreateMeal(nuggets);
        }
    }
}
