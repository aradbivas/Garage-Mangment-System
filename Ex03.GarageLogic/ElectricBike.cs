using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricBike : MotorBike
    {
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 30f;
        private const float k_BatteryMaxTimeInHours = 2.3f;
        private Electric m_Electric = new Electric();

        public ElectricBike()
        : base(k_NumberOfWheels, k_MaxAirPressure, k_BatteryMaxTimeInHours)
        {
            m_Electric.BatteryMaxTime = k_BatteryMaxTimeInHours;
        }

/*        public int NumberOfWheels
        {
            get
            {
                return k_NumberOfWheels;
            }
        }*/

/*        public float MaxAirPressure
        {
            get
            {
                return k_MaxAirPressure;
            }
        }*/

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
            this.LicenseType = i_DetailsForEachVehicle.LicenseType;
            this.EngineCapacity = i_DetailsForEachVehicle.EngineCapacity;
        }
    }
}
