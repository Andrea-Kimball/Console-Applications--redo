using Komodo_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                Console.WriteLine("View Menu Options Below \n" +
                    " 1. See All Claims \n" +
                    " 2. Take care of next claim  \n" +
                    " 3. Enter a new claim  \n" +
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
            Console.WriteLine("Please select the claim type: (Car = 1, Home = 2, Theft = 3)");
           newClaim.ClaimType = (TypeOfClaim)Enum.ToObject(typeof(TypeOfClaim), Console.ReadLine());
            
          
            //DESCRIPTION
            Console.WriteLine("Please enter the description for this claim");
            newClaim.Description = Console.ReadLine();

            //CLAIM AMOUNT
            Console.WriteLine("Please enter the amount of this claim");
            newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            //DATE OF INCIDENT
            Console.WriteLine("Enter the date of the incident");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            //DATE OF CLAIM
            Console.WriteLine("Enter the date of the claim");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            //IS VALID
            Console.WriteLine("Is this claim valid? (y/n)");
            
            newClaim.IsValid = Convert.ToBoolean(Console.ReadLine());


            _claimsRepository.CreateClaim(newClaim);

        }
        private void ViewAllClaims()
        {           

            Console.Clear();
            List<Claims> listOfClaims = _claimsRepository.ViewClaims();
            Console.WriteLine("|Claim ID|__|Type|__|Description|__|Amount|__|DateOfIncident|__|DateOfClaim|__|IsValid|\n");

            foreach (Claims item in listOfClaims)
            {
               
                Console.WriteLine($" |{item.ClaimID}||{item.ClaimType}|{item.Description}|${item.ClaimAmount}|{item.DateOfIncident}|{item.DateOfClaim}|{item.IsValid}|\n");
            }

        }
        private void NextClaim()
        {

        }
        


        public void SeedMenuItems()
        {
            //int claimID, enum ClaimType, string Description, double ClaimAmount, DateTime DateOfIncident, DateTime DateOfClaim, bool isValid

            string carIncidentDate = "April 25, 2018";
            var parsedCarIncidentDate = DateTime.Parse(carIncidentDate).Date;
            string carClaimDate = "April 27, 2018";
            var parsedCarClaimDate = DateTime.Parse(carClaimDate);

            var homeIncidentDate = "April 11, 2018";
            var homeClaimDate = "April 12, 2018";
            var theftIncidentDate = "April 27, 2018";
            var theftClaimDate = "June 1, 2018";
            

            Claims carClaim = new Claims(1, TypeOfClaim.Car, "Car accident on 465", 400, parsedCarIncidentDate, parsedCarClaimDate, true);

            Claims homeClaim = new Claims(2, TypeOfClaim.Home, "House fire in kitchen", 4000, Convert.ToDateTime(homeIncidentDate).Date, Convert.ToDateTime(homeClaimDate).Date, true);

            Claims theftClaim = new Claims(3, TypeOfClaim.Theft, "Stolen pancakes", 4, Convert.ToDateTime(theftIncidentDate), Convert.ToDateTime(theftClaimDate), false);

            _claimsRepository.CreateClaim(carClaim);
            _claimsRepository.CreateClaim(homeClaim);
            _claimsRepository.CreateClaim(theftClaim);

        }

    }
}
