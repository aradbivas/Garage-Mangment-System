using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly int r_NumberOfWheels;
        private readonly float r_MaxAirPressure;
        private readonly float r_MaxEnergy;
        private string m_PlateNumber;
        private string m_ModelName;
        private List<Wheel> m_ListOfWheels;
        private CarInformation m_CarInformation;
        private EnergySource m_EnergySource;

        protected Vehicle(int i_NumberOfWheels, float i_MaxAirPressure, float i_MaxEnergy)
        {
            r_MaxAirPressure = i_MaxAirPressure;
            r_NumberOfWheels = i_NumberOfWheels;
            r_MaxEnergy = i_MaxEnergy;
            m_ListOfWheels = new List<Wheel>();
            m_CarInformation = new CarInformation();
        }

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }

            set
            {
                m_EnergySource = value;
            }
        }

        public List<Wheel> ListOfWheels
        {
            get
            {
                return m_ListOfWheels;
            }

            set
            {
                m_ListOfWheels = value;
            }
        }

        public void AddWheelToList(Wheel i_Wheel)
        {
            m_ListOfWheels.Add(i_Wheel);
        }

        public CarInformation CarInformation
        {
            get
            {
                return m_CarInformation;
            }

            set
            {
                m_CarInformation = value;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public string PlateNumber
        {
            get
            {
                return m_PlateNumber;
            }

            set
            {
                m_PlateNumber = value;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public int NumberOfWheels
        {
            get
            {
                return r_NumberOfWheels;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public abstract void AddVehicleData(DetailsForEachVehicle i_DetailsForEachVehicle);

        public void AddEnergyInPercent(float i_Energy)
        {
            this.EnergySource.CurrentEnergy = i_Energy / r_MaxEnergy;
        }
    }
}
