using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxRange;
        private float m_MinRange;

        public ValueOutOfRangeException(Exception i_Exception, float i_MaxRange, float i_MinRange)
            : base(string.Format("Value out of range, value should be between {0} and {1}", i_MinRange, i_MaxRange), i_Exception)
        {
            m_MaxRange = i_MaxRange;
            m_MinRange = i_MinRange;
        }

        public ValueOutOfRangeException(string i_Message, float i_MaxRange, float i_MinRange)
        {
            m_MaxRange = i_MaxRange;
            m_MinRange = i_MinRange;
        }
    }
}
