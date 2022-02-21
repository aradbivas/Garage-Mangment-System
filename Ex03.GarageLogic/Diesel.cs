using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Diesel : EnergySource
    {
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;

        public void FillTank(float i_LitersToFill, eFuelType i_FuelType)
        {
            if(i_FuelType == m_FuelType)
            {
                if(m_CurrentFuelAmount + i_LitersToFill <= m_MaxFuelAmount)
                {
                    m_CurrentFuelAmount = m_CurrentFuelAmount + i_LitersToFill;
                }
                else
                {
                    throw new ArgumentException(string.Format("Can't fill tank Over {0} Liters", m_MaxFuelAmount));
                }
            }
            else
            {
                throw new ArgumentException("Fuel type doesn't match");
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                m_FuelType = value;
            }
        }

        public float CurrentFuelAmount
        {
            get
            {
                return m_CurrentFuelAmount;
            }

            set
            {
                m_CurrentFuelAmount = value;
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return m_MaxFuelAmount;
            }

            set
            {
                m_MaxFuelAmount = value;
            }
        }
    }
}