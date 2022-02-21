using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class DieselCar : Car
    {
        private const float k_MaxTankSize = 48f;
        private const eFuelType k_FuelType = eFuelType.Octan95;
        public const int k_NumberOfWheels = 4;
        private const float k_MaxAirPressure = 29f;
        private Diesel m_Diesel = new Diesel();

        public DieselCar()
            : base(k_NumberOfWheels, k_MaxAirPressure, k_MaxTankSize)
        {
            m_Diesel.FuelType = k_FuelType;
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

        public eFuelType FuelTypeType
        {
            get
            {
                return k_FuelType;
            }
        }

        public override void AddVehicleData(DetailsForEachVehicle i_DetailsForEachVehicle)
        {
            if(i_DetailsForEachVehicle.CurrentEnergyAmount > MaxTankSize)
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
            this.NumberOfDoors = i_DetailsForEachVehicle.NumberOfDoors;
            this.CarColors = i_DetailsForEachVehicle.CarColors;
        }
    }
}
