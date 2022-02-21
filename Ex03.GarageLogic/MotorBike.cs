using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class MotorBike : Vehicle
    {
        private int m_EngineCapacity;
        private eTypeOfLicenses m_TypeOfLicenses;

        protected MotorBike(int i_NumberOfWheels, float i_MaxAirPressure, float i_MaxBattery)
            : base(i_NumberOfWheels, i_MaxAirPressure, i_MaxBattery)
        {
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
    }
}
