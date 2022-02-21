using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUiManager
    {
        private readonly GarageUi r_GarageUi = new GarageUi();
        private bool m_IsGarageRunning = true;

        private void mainMenu()
        {
            string mainMessage = string.Format(
                @"Welcome to the Garage Manager! 
please choose which option you would like to preform:
Enter 1 to add new vehicle to the garage.
Enter 2 to change status to existing vehicle in the garage.
Enter 3 to inflate wheels to max in existing vehicle in the garage.
Enter 4 to add fuel to a vehicle that is in the garage.
Enter 5 to charge battery to a vehicle that is in the garage.
Enter 6 to show all vehicle's plate numbers that in the garage.
Enter 7 to show full data on vehicle by plate number.
Enter 8 to quit.");
            Console.WriteLine();
            Console.WriteLine(mainMessage);
            string userChoice = Console.ReadLine();

            try
            {
                while (!r_GarageUi.CheckIfValueParseableForInt(userChoice) || !r_GarageUi.CheckIfValueInRange(userChoice, 1, 8))
                {
                    userChoice = Console.ReadLine();
                }
            }

            catch(ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine(valueOutOfRangeException.Message);
            }

            catch (FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
            }

            eGarageOptions garageOptions = (eGarageOptions)int.Parse(userChoice);

            switch (garageOptions)
            {
                case eGarageOptions.AddNewVehicle:
                    {
                        r_GarageUi.AddNewVehicleToGarage();
                        break;
                    }

                case eGarageOptions.ChangeStatus:
                    {
                        r_GarageUi.ChangeCarStatus();

                        break;
                    }

                case eGarageOptions.InflateWheelsToMax:
                    {
                        r_GarageUi.InflateWheelsToMax();
                        break;
                    }

                case eGarageOptions.AddFuelToVehicle:
                    {
                        r_GarageUi.AddFuelToVehicle();
                        break;
                    }

                case eGarageOptions.ChargeVehicle:
                    {
                        r_GarageUi.ChargeVehicleBattery();
                        break;
                    }

                case eGarageOptions.ShowAllVehiclesPlateNumber:
                    {
                        r_GarageUi.PrintVehicleList();
                        break;
                    }

                case eGarageOptions.ShowFullDataOnVehicle:
                    {
                        r_GarageUi.PrintFullInformationOnVehicle();
                        break;
                    }

                case eGarageOptions.Quit:
                    {
                        m_IsGarageRunning = false;
                        break;
                    }
            }
        }

        public void RunGarage()
        {
            while (m_IsGarageRunning)
            {
                mainMenu();
            }
        }
    }
}
