using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_VehicleList = new Dictionary<string, Vehicle>();

        public void AddVehicleToGarage(Vehicle i_Vehicle)
        {
            m_VehicleList.Add(i_Vehicle.PlateNumber, i_Vehicle);
        }

        public bool CheckIfVehicleIsInGarage(string i_CarPlateNumber)
        {
            return m_VehicleList.ContainsKey(i_CarPlateNumber);
        }

        public Vehicle GetVehicleFromGarage(string i_PlateNumber)
        {
            Vehicle vehicle;

            if(CheckIfVehicleIsInGarage(i_PlateNumber))
            {
                vehicle = m_VehicleList[i_PlateNumber];
            }
            else
            {
                throw new KeyNotFoundException("Car is not in the garage");
            }

            return vehicle;
        }

        public void ChangeStatus(string i_PlateNumber, eCarStatus i_Status)
        {
            if(m_VehicleList.ContainsKey(i_PlateNumber))
            {
                m_VehicleList[i_PlateNumber].CarInformation.CarStatus = i_Status;
            }
            else
            {
                throw new KeyNotFoundException("Car is not in the garage");
            }
        }

        public void InflateWheelToMax(string i_PlateNumber)
        {
            Vehicle vehicle = GetVehicleFromGarage(i_PlateNumber);
            List<Wheel> wheels = vehicle.ListOfWheels;

            foreach(Wheel wheel in vehicle.ListOfWheels)
            {
                wheel.InflateWheelToMax();
            }
        }

        public void FuelVehicle(string i_PlateNumber, eFuelType i_FuelType, float i_Amount)
        {
            Vehicle vehicle = GetVehicleFromGarage(i_PlateNumber);

            if(vehicle.EnergySource is Diesel)
            {
                Diesel diesel = vehicle.EnergySource as Diesel;

                diesel.FillTank(i_Amount, i_FuelType);
            }
            else
            {
                throw new ArgumentException("Vehicle is not powered by fuel");
            }
        }

        public void ChargeVehicle(string i_PlateNumber, float i_TimeToCharge)
        {
            Vehicle vehicle = GetVehicleFromGarage(i_PlateNumber);

            if (vehicle.EnergySource is Electric)
            {
                Electric electric = vehicle.EnergySource as Electric;

                electric.ChargeVehicle(i_TimeToCharge);
            }
            else
            {
                throw new ArgumentException("Vehicle is not powered by electric");
            }
        }

        public string ShowVehicleThatInTheGarage()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            foreach (string key in m_VehicleList.Keys)
            {
                vehicleInfo.AppendLine(key);
            }

            return vehicleInfo.ToString();
        }

        public string ShowVehicleThatInTheGarageByStatus(eCarStatus i_CarStatus)
        {
            StringBuilder vehicleInfo = new StringBuilder();

            foreach (string key in m_VehicleList.Keys)
            {
                if (m_VehicleList[key].CarInformation.CarStatus == i_CarStatus)
                {
                    vehicleInfo.AppendLine(key);
                }
            }

            return vehicleInfo.ToString();
        }

        public string FullInformation(Vehicle i_Vehicle)
        {
            eCarStatus vehicleStatus = i_Vehicle.CarInformation.CarStatus;
            StringBuilder stringBuilder = new StringBuilder();
            string ownerName = i_Vehicle.CarInformation.CarOwnerName;
            string ownerPhone = i_Vehicle.CarInformation.CarOwnerPhoneNumber;

            stringBuilder.Append(string.Format(
                @"
Client Info:
owner name: {0}.
owner phone number: {1}.",
                ownerName,
                ownerPhone));

            stringBuilder.Append(
                string.Format(
                    @"
Vehicle Info:
Model name: {0}.
License number: {1}.
Energy left: {2}.
Car Status: {3}.",
                    i_Vehicle.ModelName,
                    i_Vehicle.PlateNumber,
                    i_Vehicle.EnergySource.CurrentEnergy,
                    vehicleStatus.ToString()))
                ;
            stringBuilder.AppendLine();

            int i = 0;

            foreach (Wheel wheel in i_Vehicle.ListOfWheels)
            {
                stringBuilder.Append(string.Format
                (
                    @"
wheel number {0} details:
max air pressure: {1}
Wheel current air Pressure: {2}
Wheel manufacturer: {3}",
                    i++,
                    wheel.MaxAirPressur,
                    wheel.AirPressur,
                    wheel.Manufacturer));

                stringBuilder.AppendLine();
            }

            if (i_Vehicle.EnergySource is Diesel)
            {
                stringBuilder.Append(string.Format("Fuel Type: {0}", (i_Vehicle.EnergySource as Diesel).FuelType.ToString()));
                stringBuilder.AppendLine();
                stringBuilder.Append(
                    string.Format("current amount: {0}", (i_Vehicle.EnergySource as Diesel).CurrentFuelAmount));
                stringBuilder.AppendLine();
                stringBuilder.Append(
                    string.Format("Max amount of fuel: {0}", (i_Vehicle.EnergySource as Diesel).MaxFuelAmount));
                stringBuilder.AppendLine();
            }

            if (i_Vehicle.EnergySource is Electric)
            {
                stringBuilder.Append(string.Format("battery time left: {0}", (i_Vehicle.EnergySource as Electric).BatteryTimeInHours));
                stringBuilder.AppendLine();
                stringBuilder.Append(string.Format("battery max time: {0}", (i_Vehicle.EnergySource as Electric).BatteryMaxTime));
                stringBuilder.AppendLine();
            }

            if (i_Vehicle is Car)
            {
                stringBuilder.Append(string.Format("Number of doors: {0}", (i_Vehicle as Car).NumberOfDoors));
                stringBuilder.AppendLine();
                stringBuilder.Append(string.Format("Color: {0}", (i_Vehicle as Car).CarColors));
                stringBuilder.AppendLine();
            }

            if (i_Vehicle is MotorBike)
            {
                stringBuilder.Append(string.Format("License Type: {0}", (i_Vehicle as MotorBike).LicenseType));
                stringBuilder.AppendLine();
                stringBuilder.Append(string.Format("Motor Engine Capacity: {0}", (i_Vehicle as MotorBike).EngineCapacity));
                stringBuilder.AppendLine();
            }

            if (i_Vehicle is Truck)
            {
                stringBuilder.Append(string.Format("Truck cargo capacity: {0}", (i_Vehicle as Truck).CargoCapacity));
                stringBuilder.AppendLine();
                stringBuilder.Append(string.Format("Truck has cold goods: {0}", (i_Vehicle as Truck).HascoldGoods));
                stringBuilder.AppendLine();
            }

            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }
    }
}
