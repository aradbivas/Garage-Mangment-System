# Garage-Mangment-System


This programe is a large scale progame that was written in c# and .net.
The project uses heritage composition and polymorphism, made to pratice Object Orinated Programming.
The programe was wrtiten in though of easy maintance and improvent in the future,
made so th logic part and ui itself(cmd) is seperated so you be able to add new type of vehicles in the future without with minimale change of the progame.

The supporte five diffrente types of vehicles,
Electric bike, electric car, gas car, gas bike and truck
each one of this vehicle has it's  own propirties along side of the normal propirties the vehicle have.

The bike and car classes inheritor from vehicle class that have data member like: model, licenes plate, how many enerygy left and list that contains wheel objects.
the electric bike and gas bike inheritor from bike class, that have this data member: licenses types and engine volume.
the electric car and gas car inheritor from car class, that have this data member: car color and number of doors.
the truck inheritor from vehicle and have this data members: is carrying colds goods and volume of the cargo.
also each one of this object has it's own speacil propirties for example:
The gas car have four wheels with 29 psi max air pressure, fuel type is Octan 95 and max fuel tank is 48L.

each vehicle that run on gas have this futures:
type of fuel, current fuel amount, max fuel amount and fueling function that needs to check if the correct fuel type is inserted.

each vehicle that run on electrcity have this futures:
battery time left in hours, max battery time and charging battery function.

The garage itself holds a list of vehicles, for each vehicle he haves to following detials:
Owner name and phone number, the status of the vehicle that in the garage(in repaier, fixed, paid)

The progame let the user do this following function:
1)Enter new vehicle to the garage, the user needs to fill detailes about the vehicle according to the type of vehicle he entered.
2)Show a list of the vehicles in the garage by plate number, also the user can filter the search by the status of the vehicle in garage.
3)Change the status of vehicle that in the garage.
4)Fuel gas vehicle.
5)Charge elecrtic vehicle.
6)Show full data about a vehicle that in the garage by his plate number.
