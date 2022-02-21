using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Car
    {
        private const int k_NumberOfWheels = 16;
        private const float k_MaxAirPressure = 25f;
        private const float k_MaxTankSize = 130f;
        private const eFuelType k_Fuel = eFuelType.Soler;
        private bool m_HasColdGoods;
        private float m_CargoCapacity;
        private Diesel m_Diesel = new Diesel();

        public Truck()
        : base(k_NumberOfWheels, k_MaxAirPressure, k_MaxTankSize)
        {
            m_Diesel.MaxFuelAmount = k_MaxTankSize;
            m_Diesel.FuelType = k_Fuel;
        }

        public eFuelType FuelType
        {
            get
            {
                return k_Fuel;
            }
        }

        public float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }

            set
            {
                m_CargoCapacity = value;
            }
        }

        public bool HascoldGoods
        {
            get
            {
                return m_HasColdGoods;
            }

            set
            {
                m_HasColdGoods = value;
            }
        }

        public float MaxTankSize
        {
            get
            {
                return k_MaxTankSize;
            }
        }

        public float MaxAirPressur
        {
            get
            {
                return k_MaxAirPressure;
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

            this.CargoCapacity = i_DetailsForEachVehicle.CargoCapacity;
            this.HascoldGoods = i_DetailsForEachVehicle.HascoldGoods;
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
