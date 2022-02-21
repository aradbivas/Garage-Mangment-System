using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class DieselBike : MotorBike
    {
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 30f;
        private const float k_MaxTankSize = 5.8f;
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private Diesel m_Diesel = new Diesel();

        public DieselBike()
            : base(k_NumberOfWheels, k_MaxAirPressure, k_MaxTankSize)
        {
            m_Diesel.FuelType = eFuelType.Octan98;
            m_Diesel.MaxFuelAmount = k_MaxTankSize;
        }

        public Diesel Diesel
        {
            get
            {
                return m_Diesel;
            }

            set
            {
                m_Diesel = value;
            }
        }

        public float MaxTankSize
        {
            get
            {
                return k_MaxTankSize;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return k_FuelType;
            }
        }

        public override void AddVehicleData(DetailsForEachVehicle i_DetailsForEachVehicle)
        {
            if (i_DetailsForEachVehicle.CurrentEnergyAmount > MaxTankSize)
            {
                throw new ValueOutOfRangeException(new Exception(), k_MaxTankSize, 0);
            }
            else
            {
                m_Diesel.CurrentFuelAmount = i_DetailsForEachVehicle.CurrentEnergyAmount;
            }

            this.EnergySource = m_Diesel;
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
