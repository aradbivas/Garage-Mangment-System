using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleBuilder
    {
        public static Vehicle CreateVehicle(string i_VehicleType)
        {
            Vehicle vehicle;
            switch(i_VehicleType)
            {
                case "ElectricCar":
                    {
                        vehicle = new ElectricCar();
                        break;
                    }

                case "ElectricBike":
                    {
                        vehicle = new ElectricBike();
                        break;
                    }

                case "DieselCar":
                    {
                        vehicle = new DieselCar();
                        break;
                    }

                case "DieselBike":
                    {
                        vehicle = new DieselBike();
                        break;
                    }

                case "Truck":
                    {
                        vehicle = new Truck();
                        break;
                    }

                default:
                    {
                        vehicle = null;
                        break;
                    }
            }

            return vehicle;
        }
    }
}
