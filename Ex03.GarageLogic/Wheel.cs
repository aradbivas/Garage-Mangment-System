using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public void InflateWheel(float i_AirPressure)
        {
            if(i_AirPressure + m_CurrentAirPressure <= m_MaxAirPressure)
            {
                m_CurrentAirPressure = i_AirPressure + m_CurrentAirPressure;
            }
        }

        public void InflateWheelToMax()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }

        public string Manufacturer
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        public float AirPressur
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressur
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                m_MaxAirPressure = value;
            }
        }
    }
}
