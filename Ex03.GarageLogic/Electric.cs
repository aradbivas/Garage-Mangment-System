using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Electric : EnergySource
    {
        private float m_BatteryTimeInHours;
        private float m_BatteryMaxTimeInHours;

        private void chargeBattery(float numOfHours)
        {
            if(BatteryTimeInHours + numOfHours <= m_BatteryMaxTimeInHours)
            {
                BatteryTimeInHours = BatteryTimeInHours + numOfHours;
            }
        }

        public float BatteryTimeInHours
        {
            get
            {
                return m_BatteryTimeInHours;
            }

            set
            {
                m_BatteryTimeInHours = value;
            }
        }

        public float BatteryMaxTime
        {
            get
            {
                return m_BatteryMaxTimeInHours;
            }

            set
            {
                m_BatteryMaxTimeInHours = value;
            }
        }

        public void ChargeVehicle(float i_TimeToAdd)
        {
            if(m_BatteryTimeInHours + i_TimeToAdd <= m_BatteryMaxTimeInHours)
            {
                m_BatteryMaxTimeInHours = m_BatteryTimeInHours + i_TimeToAdd;
            }
            else
            {
                throw new ArgumentException("Can not charge over the limit!");
            }
        }
    }
}
