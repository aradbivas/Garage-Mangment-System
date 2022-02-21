using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_BatteryMaxTimeInHours = 2.6f;
        private const int k_NumberOfWheels = 4;
        private const float k_MaxAirPressure = 29f;
        private Electric m_Electric = new Electric();

        public ElectricCar()
        : base(k_NumberOfWheels, k_MaxAirPressure, k_BatteryMaxTimeInHours)
        {
            m_Electric.BatteryMaxTime = k_BatteryMaxTimeInHours;
        }

        public Electric Electric
        {
            get
            {
                return m_Electric;
            }

            set
            {
                m_Electric = value;
            }
        }

        public override void AddVehicleData(DetailsForEachVehicle i_DetailsForEachVehicle)
        {
            m_Electric.BatteryTimeInHours = i_DetailsForEachVehicle.CurrentEnergyAmount;
            this.EnergySource = m_Electric;
            this.ModelName = i_DetailsForEachVehicle.ModelName;
            this.CarInformation.CarOwnerName = i_DetailsForEachVehicle.OwnerName;
            this.CarInformation.CarOwnerPhoneNumber = i_DetailsForEachVehicle.OwnerPhoneNumber;
            this.CarInformation.CarStatus = eCarStatus.InRepair;
            this.PlateNumber = i_DetailsForEachVehicle.PlateNumber;
            this.NumberOfDoors = i_DetailsForEachVehicle.NumberOfDoors;
            this.CarColors = i_DetailsForEachVehicle.CarColors;
        }
    }
}
