using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private eCarColors m_CarColors;
        private eNumberOfDoors m_NumberOfDoors;

        protected Car(int i_NumberOfWheels, float i_MaxAirPressure, float i_MaxEnergy)
            : base(i_NumberOfWheels, i_MaxAirPressure, i_MaxEnergy)
        {
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
    }
}
