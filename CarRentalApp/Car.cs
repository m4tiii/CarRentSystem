using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp
{
    internal class Car
    {
        int id, amountOfCarsAvailable;
        String carModel, carCategory, location;
        double standardRentPriceMultiplier, averageFuelUsage;

        public Car(int id, string carModel, string carCategory, string location, double averageFuelUsage, int amountOfCarsAvailable)
        {
            this.id = id;
            this.carModel = carModel;
            this.carCategory = carCategory;
            this.location = location;
            this.averageFuelUsage = averageFuelUsage;
            this.amountOfCarsAvailable = amountOfCarsAvailable;
            priceCalc();
        }

        public double StandardRentPriceMultiplier { get => standardRentPriceMultiplier; set => standardRentPriceMultiplier = value; }
        public string CarCategory { get => carCategory; set => carCategory = value; }

        public int AmountOfCarsAvailable { get => amountOfCarsAvailable; set => amountOfCarsAvailable = value; }
        public double AverageFuelUsage { get => averageFuelUsage; set => averageFuelUsage = value; }

        //Setting basic price multiplier of rent by checking car category
        public void priceCalc()
        {
            switch (carCategory)
            {
                case "Basic":
                    standardRentPriceMultiplier = 1.0;
                    break;
                case "Standard":
                    standardRentPriceMultiplier = 1.3;
                    break;
                case "Medium":
                    standardRentPriceMultiplier = 1.6;
                    break;
                case "Premium":
                    standardRentPriceMultiplier = 2.0;
                    break;
            }
        }

        public override string ToString()
        {
            return "Samochod nr " + id + ", Model: " + carModel + ", Kategoria: " + carCategory + ", Lokalizacja: " + location;
        }
    }
}
