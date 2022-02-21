using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
   public abstract class EnergySource
   {
       private float m_CurrentEnergyInPercents;

       public float CurrentEnergy
       {
           get
           {
               return m_CurrentEnergyInPercents;
           }

           set
           {
               m_CurrentEnergyInPercents = value;
           }
       }
    }
}
