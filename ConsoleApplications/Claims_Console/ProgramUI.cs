using Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komodo_Claims;

namespace Claims_Console
{
    public class ProgramUI
    {

        private Claims_Repository _claimsRepository = new Claims_Repository();
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
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        private void CreateNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            //CLAIM TYPE
            Console.WriteLine("{Please select the claim type: (Car = 1, Home = 2, Theft = 3)");
            newClaim.ClaimType = (TypeOfClaim)Enum.ToObject(typeof(TypeOfClaim), Console.ReadLine());

            //DESCRIPTION
            Console.WriteLine("Please enter the description for this claim");
            newClaim.Description = Console.ReadLine();

            //CLAIM AMOUNT
            Console.WriteLine("Please enter the amount of this claim");
            newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());
            //DATE OF INCIDENT
            //DATE OF CLAIM
            //IS VALID

        }
        private void ViewAllClaims()
        {
            Console.Clear();
            List<Claims>


        }
        private void NextClaim()
        {

        }

      


        public void SeedMenuItems()
        {

        }

    }
}
