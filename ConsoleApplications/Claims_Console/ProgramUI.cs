using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    public class ProgramUI
    {
        public void Run()
        {
            SeedMenuItems();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("View Menu Options Below/n" +
                    " 1. See All Claims/n" +
                    " 2. Take care of next claim /n" +
                    " 3. Enter a new claim /n" +
                    " 4. Exit ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;

                    case "2":
                        NextClaim();
                        break;

                    case "3":
                        CreateNewClaim();
                        break;

                    case "4":
                        Console.WriteLine("Good Bye");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please select a valid option between 1-4");
                        break;
                }
                
            }
           
        }
        private void ViewAllClaims()
        {
            List<Claims>

        }
        private void NextClaim()
        {

        }

        private void CreateNewClaim()
        {

        }


        public void SeedMenuItems()
        {

        }
    }
}
