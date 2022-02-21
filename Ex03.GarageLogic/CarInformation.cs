using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class CarInformation
    {
        private string m_CarOwnerName;
        private string m_CarOwnerPhoneNumber;
        private eCarStatus m_CarStatus;

        public string CarOwnerName
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

        public string CarOwnerPhoneNumber
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

        public eCarStatus CarStatus
        {
            get
            {
                return m_CarStatus;
            }

            set
            {
                m_CarStatus = value;
            }
        }
    }
}
