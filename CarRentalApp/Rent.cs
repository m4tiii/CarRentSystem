using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp
{
    internal class Rent
    {
        List<Car> carsToRentList = new List<Car>();
        double fuelPrice = 8.07;
        double vatValue = 1.23;
        double basicPriceOfCar = 500.0;

        public Rent()
        {
            carsToRentList.Add(new Car(1, "Seat Leon", "Standard", "Jaslo", 5.0, 9));
            carsToRentList.Add(new Car(2, "Renault Clio", "Basic", "Rzeszow", 4.0, 4));
            carsToRentList.Add(new Car(3, "Nissan Pulsar", "Medium", "Krosno", 6.5, 2));
            carsToRentList.Add(new Car(4, "Audi S5", "Premium", "Jaslo", 11.5, 3));
            carsToRentList.Add(new Car(5, "Honda Civic", "Standard", "Krakow", 5.5, 1));

            UserInterface();
        }

       



        public void UserInterface()
        {
            int carId, yearsOfOwningDriverLicense, rentDays;
            double carPrice, driveDistance;
            Car selectedCar;

            Console.WriteLine("*****************************************************************");
            Console.WriteLine("Witaj w wypożyczalni, masz tu parę samochodów do wypożyczenia");
            Console.WriteLine("Podaj id samochodu i obliczymy koszt wynajmu dla Ciebie");
            foreach (var car in carsToRentList)
            {
                Console.WriteLine(car.ToString());
            }
            carId = int.Parse(Console.ReadLine()) - 1;
            selectedCar = carsToRentList[carId];
            carPrice = priceOfCar(selectedCar);

            Console.WriteLine();

            Console.WriteLine("Na ile dni chcesz wypożyczyć pojazd?");
            rentDays = int.Parse(Console.ReadLine());
            carPrice *= rentDays;

            Console.WriteLine();

            Console.WriteLine("Ile lat masz prawo jazdy?");
            yearsOfOwningDriverLicense = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Ile zamierzasz przejechać średnio kilometrów?");
            driveDistance = double.Parse(Console.ReadLine());

            calculateRentalPrice(yearsOfOwningDriverLicense, carPrice, selectedCar, driveDistance, rentDays);

            Console.WriteLine();

            Console.WriteLine("*****************************************************************");
        }

        public double priceOfCar(Car car)
        {   
            return basicPriceOfCar *= car.StandardRentPriceMultiplier;
        }

        public void calculateRentalPrice(int yearsOfOwningDriverLicense, double carPrice, Car car, double driveDistance, int rentDays)
        {
            if(yearsOfOwningDriverLicense < 5 )
            {
               carPrice *= 1.2;
                if (yearsOfOwningDriverLicense < 3 && car.CarCategory.Equals("Premium"))
                {
                    Console.WriteLine("Masz za krótko prawo jazdy aby wypożyczyć samochód klasy premium");
                    UserInterface();
                }
            }
            

            double rentCarFuelPrice = car.AverageFuelUsage * (driveDistance / 100) * fuelPrice;


            Console.WriteLine("Kwota netto: " + carPrice);
            Console.WriteLine("Kwota brutto: " + (carPrice * vatValue));
            Console.WriteLine("(bazowa cena wypożyczenia) " + basicPriceOfCar + " * (mnożnik za klasę samochodu) " +
                car.StandardRentPriceMultiplier + " * (ilosc dni wypozyczenia) " + rentDays + " + (cena paliwa) " +
                rentCarFuelPrice + " * (podatek VAT) " + vatValue + " = " + (carPrice * vatValue));

            Console.WriteLine("");
        }
    }
}
