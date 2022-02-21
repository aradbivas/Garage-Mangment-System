using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class DetailsForEachVehicle
    {
        private string m_ModelName;
        private string m_CarOwnerName;
        private string m_CarOwnerPhoneNumber;
        private string m_PlateNumber;
        private bool m_HasColdGoods;
        private float m_CargoCapacity;
        private int m_EngineCapacity;
        private float m_CurrentEnergyAmount;
        private eCarColors m_CarColors;
        private eNumberOfDoors m_NumberOfDoors;
        private eTypeOfLicenses m_TypeOfLicenses;

        public float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }

            set
            {
                m_CurrentEnergyAmount = value;
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

        public eCarColors CarColors
        {
            get
            {
                return m_CarColors;
            }

            set
            {
                m_CarColors = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                m_EngineCapacity = value;
            }
        }

        public eTypeOfLicenses LicenseType
        {
            get
            {
                return m_TypeOfLicenses;
            }

            set
            {
                m_TypeOfLicenses = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_CarOwnerName;
            }

            set
            {
                m_CarOwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_CarOwnerPhoneNumber;
            }

            set
            {
                m_CarOwnerPhoneNumber = value;
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
    }
}
