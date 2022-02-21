using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUi
    {
        private readonly Garage r_Garage = new Garage();
        private Vehicle m_Vehicle;

        public void AddNewVehicleToGarage()
        {
            int userSelectedVehicleType = userSelectVehicleType();
            eVehicleTypes vehicleType = (eVehicleTypes)userSelectedVehicleType;

            m_Vehicle = VehicleBuilder.CreateVehicle(vehicleType.ToString());
            try
            {
                DetailsForEachVehicle detailsByCarType = getDetailsByCarType(vehicleType);

                m_Vehicle.AddVehicleData(detailsByCarType);
                AddWheels(ref m_Vehicle);
                m_Vehicle.AddEnergyInPercent(detailsByCarType.CurrentEnergyAmount);
                r_Garage.AddVehicleToGarage(m_Vehicle);
                Console.WriteLine("Vehicle added successfully");
            }
            catch(ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }

        private DetailsForEachVehicle getDetailsByCarType(eVehicleTypes i_VehicleTypes)
        {
            DetailsForEachVehicle detailsForEachVehicleForm = new DetailsForEachVehicle();

            Console.WriteLine("Please enter Vehicle's plate Number.");
            string plateNumber = Console.ReadLine();

            while(plateNumber == string.Empty)
            {
                Console.WriteLine("Please enter Vehicle's plate Number.");
                plateNumber = Console.ReadLine();
            }

            if(r_Garage.CheckIfVehicleIsInGarage(plateNumber))
            {
                m_Vehicle = r_Garage.GetVehicleFromGarage(plateNumber);
                m_Vehicle.CarInformation.CarStatus = eCarStatus.InRepair;
                throw new ArgumentException("Vehicle already in the garage, Changed status to in repair");
            }
            else
            {
                Console.WriteLine("Please enter Vehicle's model name.");
                string modelName = Console.ReadLine();

                while (modelName == string.Empty)
                {
                    Console.WriteLine("Please enter Vehicle's model name.");
                    modelName = Console.ReadLine();
                }

                detailsForEachVehicleForm.PlateNumber = plateNumber;
                detailsForEachVehicleForm.ModelName = modelName;

                Console.WriteLine("Enter Vehicle owner name");
                detailsForEachVehicleForm.OwnerName = Console.ReadLine();
                while (detailsForEachVehicleForm.OwnerName == string.Empty)
                {
                    Console.WriteLine("Please enter Vehicle owner name.");
                    detailsForEachVehicleForm.OwnerName = Console.ReadLine();
                }

                Console.WriteLine("Enter Vehicle owner phone number.");
                detailsForEachVehicleForm.OwnerPhoneNumber = Console.ReadLine();
                while (detailsForEachVehicleForm.OwnerPhoneNumber == string.Empty)
                {
                    Console.WriteLine("Please enter Vehicle owner phone number.");
                    detailsForEachVehicleForm.OwnerPhoneNumber = Console.ReadLine();
                }

                switch(i_VehicleTypes.ToString())
                {
                    case "DieselCar":
                        {
                            getDetailsForDieselCar(ref detailsForEachVehicleForm);
                            break;
                        }

                    case "DieselBike":
                        {
                            getDetailsForDieselBike(ref detailsForEachVehicleForm);
                            break;
                        }

                    case "Truck":
                        {
                            getDetailsForDieselTruck(ref detailsForEachVehicleForm);
                            break;
                        }

                    case "ElectricCar":
                        {
                            getDetailsForElectricCar(ref detailsForEachVehicleForm);
                            break;
                        }

                    case "ElectricBike":
                        {
                            getDetailsForElectricBike(ref detailsForEachVehicleForm);
                            break;
                        }
                }
            }

            return detailsForEachVehicleForm;
        }

        private void getDetailsForElectricCar(ref DetailsForEachVehicle io_VehicleDetails)
        {
            io_VehicleDetails.CurrentEnergyAmount = getCurrentEnergyAmount();
            io_VehicleDetails.CarColors = getCarColor();
            io_VehicleDetails.NumberOfDoors = getNumberOfDoors();
        }

        private void getDetailsForElectricBike(ref DetailsForEachVehicle io_VehicleDetails)
        {
            io_VehicleDetails.CurrentEnergyAmount = getCurrentEnergyAmount();
            io_VehicleDetails.LicenseType = geTypeOfLicenses();
            io_VehicleDetails.EngineCapacity = getEngineCapacity();
        }

        private void getDetailsForDieselTruck(ref DetailsForEachVehicle io_VehicleDetails)
        {
            io_VehicleDetails.CurrentEnergyAmount = getCurrentEnergyAmount();
            io_VehicleDetails.NumberOfDoors = getNumberOfDoors();
            io_VehicleDetails.CarColors = getCarColor();
            io_VehicleDetails.CargoCapacity = getCargoCapacity();
            io_VehicleDetails.HascoldGoods = isTruckHaveColdGoods();
        }

        private float getCargoCapacity()
        {
            Console.WriteLine("Enter cargo capacity ");
            string cargoCapacityString = Console.ReadLine();

            while (!CheckIfValueParseableForInt(cargoCapacityString))
            {
                cargoCapacityString = Console.ReadLine();
            }

            int cargoCapacity = int.Parse(cargoCapacityString);

            return cargoCapacity;
        }

        private bool isTruckHaveColdGoods()
        {
            bool coldGoods = false;
            Console.WriteLine("Enter 1 if car have cold goods or 0 otherwise");
            string userChoice = Console.ReadLine();

            while(!isValidAnswer(userChoice))
            {
                Console.WriteLine("Please enter 1 or 0");
                userChoice = Console.ReadLine();
            }

            if(userChoice == "1")
            {
                 coldGoods = true;
            }

            return coldGoods;
        }

        private bool isValidAnswer(string i_UserAnswer)
        {
            return i_UserAnswer == "1" || i_UserAnswer == "0";
        }

        private void getDetailsForDieselCar(ref DetailsForEachVehicle io_VehicleDetails)
        {
            io_VehicleDetails.CurrentEnergyAmount = getCurrentEnergyAmount();
            io_VehicleDetails.NumberOfDoors = getNumberOfDoors();
            io_VehicleDetails.CarColors = getCarColor();
        }

        private void getDetailsForDieselBike(ref DetailsForEachVehicle io_VehicleDetails)
        {
            io_VehicleDetails.CurrentEnergyAmount = getCurrentEnergyAmount();
            io_VehicleDetails.LicenseType = geTypeOfLicenses();
            io_VehicleDetails.EngineCapacity = getEngineCapacity();
        }

        private int getEngineCapacity()
        {
            Console.WriteLine("Enter engine capacity ");
            string currentFuelAmountString = Console.ReadLine();
            int engineCapacity;

            while (!int.TryParse(currentFuelAmountString, out engineCapacity))
            {
                Console.WriteLine("Invalid choice, please enter numbers only.");
                currentFuelAmountString = Console.ReadLine();
            }

            return engineCapacity;
        }

        private eTypeOfLicenses geTypeOfLicenses()
        {
            string getLicensesType = string.Format(
                @"Please enter your licenses type
Enter 1 for A licenses type
Enter 2 for A2 licenses type
Enter 3 for AA licenses type
Enter 4 for B licenses type");

            Console.WriteLine(getLicensesType);
            string userLicensesType = Console.ReadLine();

            while (!CheckIfValueParseableForInt(userLicensesType) || !CheckIfValueInRange(userLicensesType, 1, 4))
            {
                userLicensesType = Console.ReadLine();
            }

            eTypeOfLicenses userLicenses = (eTypeOfLicenses)int.Parse(userLicensesType);

            return userLicenses;
        }

        private float getCurrentEnergyAmount()
        {
            Console.WriteLine("Please Enter current energy amount lower or equal {0}", m_Vehicle.MaxEnergy);
            string currentFuelAmount = Console.ReadLine();
            float fuelAmountFloat;

            while (!float.TryParse(currentFuelAmount, out fuelAmountFloat) || !CheckIfValueInRange(currentFuelAmount,0,m_Vehicle.MaxEnergy))
            {
                Console.WriteLine("Please Enter current energy amount lower or equal then: {0}", m_Vehicle.MaxEnergy);
                currentFuelAmount = Console.ReadLine();
            }

            fuelAmountFloat = float.Parse(currentFuelAmount);

            return fuelAmountFloat;
        }

        private eNumberOfDoors getNumberOfDoors()
        {
            Console.WriteLine("How many doors the car have? Please enter number between 2 to 5");
            string getNumberOfDoors = Console.ReadLine();
            while(!CheckIfValueParseableForInt(getNumberOfDoors) || !CheckIfValueInRange(getNumberOfDoors, 2, 5))
            {
                getNumberOfDoors = Console.ReadLine();
            }

            eNumberOfDoors doorsNumber = (eNumberOfDoors)int.Parse(getNumberOfDoors);

            return doorsNumber;
        }

        private eCarColors getCarColor()
        {
            string getCarColorMessage = string.Format(
                @"What is the car color?
Enter 1 for Red
Enter 2 for White
Enter 3 for Black
Enter 4 for Blue");
            Console.WriteLine(getCarColorMessage);
            string carColor = Console.ReadLine();

            while(!CheckIfValueParseableForInt(carColor) || !CheckIfValueInRange(carColor, 1, 4))
            {
                carColor = Console.ReadLine();
            }

            eCarColors carColorsEnum = (eCarColors)int.Parse(carColor);

            return carColorsEnum;
        }

        private int userSelectVehicleType()
        {
            string addNewCar = string.Format(
                @"Please choose the Vehicle type you want to add:
To add a Diesel car, type 1.
To add a Diesel bike, type 2.
To add a Diesel truck, type 3.
To add a Electric car, type 4.
To add a Electric bike, type 5.");
            Console.WriteLine(addNewCar);
            string vehicleType = Console.ReadLine();

            while (!CheckIfValueParseableForInt(vehicleType) || !CheckIfValueInRange(vehicleType, 1, 5))
            {
                try
                {
                    vehicleType = Console.ReadLine();
                }

                catch(FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }

                catch(ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
            }

            return int.Parse(vehicleType);
        }

        public bool CheckIfValueParseableForInt(string i_Value)
        {
            bool isParseable = true;

            try
            {
                int.Parse(i_Value);
            }

            catch (FormatException formatException)
            {
                Console.WriteLine("Please enter numbers only!");
                isParseable = false;
            }

            return isParseable;
        }

        public bool CheckIfValueInRange(string i_Value, float i_MinRange, float i_MaxRange)
        {
            bool isInRange = true;
            float intValue = float.Parse(i_Value);

            try
            {
                if(intValue > i_MaxRange || intValue < i_MinRange)
                {
                    isInRange = false;
                    throw new ValueOutOfRangeException(new Exception(), i_MaxRange, i_MinRange);
                }
            }

            catch(ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine("Enter numbers between {0} to {1}.", i_MinRange, i_MaxRange);
            }

            return isInRange;
        }

        public void AddWheels(ref Vehicle i_Vehicle)
        {
            for (int i = 0; i < i_Vehicle.NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel();

                Console.WriteLine("Enter wheel number {0} manufacture Name", i + 1);
                string manufacturerName = Console.ReadLine();

                while(manufacturerName == string.Empty)
                {
                    Console.WriteLine("Enter wheel number {0} manufacture Name", i + 1);
                    manufacturerName = Console.ReadLine();
                }

                Console.WriteLine("Enter wheel number {0} current Air Pressure", i + 1);
                string currentAirPressure = Console.ReadLine();

                try
                {
                    float currentAirPressureInFloat;

                    while (!float.TryParse(currentAirPressure, out currentAirPressureInFloat) || !CheckIfValueInRange(currentAirPressure, 0, i_Vehicle.MaxAirPressure))
                    {
                        Console.WriteLine("Please enter only numbers!");
                        currentAirPressure = Console.ReadLine();
                    }

                    wheel.Manufacturer = manufacturerName;
                    wheel.AirPressur = currentAirPressureInFloat;
                    wheel.MaxAirPressur = i_Vehicle.MaxAirPressure;
                    i_Vehicle.AddWheelToList(wheel);
                }

                catch(ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
            }
        }

        public void ChangeCarStatus()
        {
            Console.WriteLine("Please enter Vehicle plate number");
            string plateNumber = Console.ReadLine();
            string chooseCarStatus = string.Format(@"Please choose Vehicle status:
enter 1 for In Repair.
enter 2 for Fixed.
enter 3 for Paid.");
            Console.WriteLine(chooseCarStatus);
            string userCarStatus = Console.ReadLine();

            while(!CheckIfValueParseableForInt(userCarStatus) || !CheckIfValueInRange(userCarStatus, 1, 3))
            {
                userCarStatus = Console.ReadLine();
            }

            eCarStatus carStatus = (eCarStatus)int.Parse(userCarStatus);
            try
            {
                r_Garage.ChangeStatus(plateNumber, carStatus);
                Console.WriteLine("Vehicle {0} status changed to {1}", plateNumber, carStatus);
            }

            catch(KeyNotFoundException keyNotFoundException)
            {
                Console.WriteLine(keyNotFoundException.Message);
            }
        }

        public void InflateWheelsToMax()
        {
            Console.WriteLine("Please enter Vehicle plate number");
            string plateNumber = Console.ReadLine();
            while (plateNumber == string.Empty)
            {
                Console.WriteLine("Please enter Vehicle plate number");
                plateNumber = Console.ReadLine();
            }

            try
            {
                r_Garage.InflateWheelToMax(plateNumber);
                Console.WriteLine("Vehicle {0} wheels inflated to max ", plateNumber);
            }

            catch (KeyNotFoundException keyNotFoundException)
            {
                Console.WriteLine(keyNotFoundException.Message);
            }
        }

        public void AddFuelToVehicle()
        {
            Console.WriteLine("Please enter Vehicle plate number");
            string plateNumber = Console.ReadLine();

            while (plateNumber == string.Empty)
            {
                Console.WriteLine("Please enter Vehicle plate number");
                plateNumber = Console.ReadLine();
            }

            string chooseVehicleFuelType = string.Format(@"Please choose Vehicle fuel type:
enter 1 for Soler.
enter 2 for Octan 95.
enter 3 for Octan 96.
enter 4 for Octan 98.");

            Console.WriteLine(chooseVehicleFuelType);
            string fuelString = Console.ReadLine();
            int fuelType;

            while(!int.TryParse(fuelString, out fuelType) && !CheckIfValueInRange(fuelString, 1, 4))
            {
                fuelString = Console.ReadLine();
            }

            eFuelType fuel = (eFuelType)fuelType;

            Console.WriteLine("Please enter amount of fuel");
            string amount = Console.ReadLine();
            float fuelAmount;

            while (!float.TryParse(amount, out fuelAmount))
            {
                Console.WriteLine("Please enter only numbers!");
                amount = Console.ReadLine();
            }

            try
            {
                r_Garage.FuelVehicle(plateNumber, fuel, fuelAmount);
                Console.WriteLine("Vehicle {0} fuel type {1} is added by {2} ", plateNumber, fuel, amount);
            }

            catch(ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine(valueOutOfRangeException.Message);
            }

            catch(KeyNotFoundException keyNotFoundException)
            {
                Console.WriteLine(keyNotFoundException.Message);
            }

            catch(ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }

        public void ChargeVehicleBattery()
        {
            Console.WriteLine("Please enter Vehicle plate number");
            string plateNumber = Console.ReadLine();

            while(plateNumber == string.Empty)
            {
                Console.WriteLine("Please enter Vehicle plate number");
                plateNumber = Console.ReadLine();
            }

            Console.WriteLine("Please enter how much time to charge");
            string batteryTime = Console.ReadLine();
            float batteryTimeToAdd;

            while (!float.TryParse(batteryTime, out batteryTimeToAdd))
            {
                Console.WriteLine("Please enter only numbers!");
                batteryTime = Console.ReadLine();
            }

            try
            {
                r_Garage.ChargeVehicle(plateNumber, batteryTimeToAdd);
                Console.WriteLine("Vehicle {0} battery added {1} hours.", plateNumber, batteryTime);
            }

            catch(ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine(valueOutOfRangeException.Message);
            }

            catch(KeyNotFoundException keyNotFoundException)
            {
                Console.WriteLine(keyNotFoundException.Message);
            }

            catch(ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }

        public void PrintVehicleList()
        {
            string menuOptions = string.Format(@"Do you want to see all the keys, or filter by status:
enter 1 for viewing all of the vehicle plates.
enter 2 for filter by status.");

            Console.WriteLine(menuOptions);
            string userChoice = Console.ReadLine();

            while (!CheckIfValueParseableForInt(userChoice) || !CheckIfValueInRange(userChoice, 1, 2))
            {
                userChoice = Console.ReadLine();
            }

            int choose = int.Parse(userChoice);

            if (choose == 2)
            {
                printVehicleListByStatus();
            }
            else
            {
                string vehiclesInTheGarage = r_Garage.ShowVehicleThatInTheGarage();
                if (vehiclesInTheGarage.Length > 0) 
                {
                    Console.WriteLine("Vehicle that are in the garage are:"); 
                    Console.WriteLine(vehiclesInTheGarage);
                }
                else
                {
                    Console.WriteLine("There is not vehicles in the garage!");
                }
            }
        }

        private void printVehicleListByStatus()
        {
            string chooseCarStatus = string.Format(@"Please choose vehicle status:
enter 1 for In Repair.
enter 2 for Fixed.
enter 3 for Paid.");
            Console.WriteLine(chooseCarStatus);
            string userCarStatus = Console.ReadLine();

            while (!CheckIfValueParseableForInt(userCarStatus) || !CheckIfValueInRange(userCarStatus, 1, 3))
            {
                userCarStatus = Console.ReadLine();
            }

            eCarStatus carStatus = (eCarStatus)int.Parse(userCarStatus);
            string vehiclesInTheGarage = r_Garage.ShowVehicleThatInTheGarageByStatus(carStatus);

            if(vehiclesInTheGarage.Length > 0)
            {
                Console.WriteLine("Vehicle that are in the garage with status {0} are:", carStatus);
                Console.WriteLine(vehiclesInTheGarage);
            }
            else
            {
                Console.WriteLine("There is not vehicles in the garage with status {0}.", carStatus );
            }
        }

        public void PrintFullInformationOnVehicle()
        {
            Console.WriteLine("Please enter vehicle plate number:");
            string plateNumber = Console.ReadLine();

            while (plateNumber == string.Empty)
            {
                Console.WriteLine("Please enter vehicle plate number:");
                plateNumber = Console.ReadLine();
            }

            try
            {
                Vehicle vehicleToGetData = r_Garage.GetVehicleFromGarage(plateNumber);
                string dataOnVehicle = r_Garage.FullInformation(vehicleToGetData);
                Console.WriteLine(dataOnVehicle);
            }

            catch(KeyNotFoundException keyNotFoundException)
            {
                Console.WriteLine(keyNotFoundException.Message);
            }
        }
    }
}