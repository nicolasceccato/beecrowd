namespace Beecrowd1023;

using System;
using System.Collections.Generic;
using System.Linq;

public class Beecrowd1023
{
    static void Main(string[] args) { 

        int numberOfHouses = Convert.ToInt32(Console.ReadLine());
    
        int cityNumber = 0;

        List<City> cities = new List<City>();
        while(numberOfHouses != 0)
        {
            List<House> houses = new List<House>();
            for (int i = 0; i < numberOfHouses; i++)
            {
                
                string line = Console.ReadLine();
                string[] values = line.Split(' ');
                int residents = Convert.ToInt32(values[0]);
                int consumption = Convert.ToInt32(values[1]);
                House house = new House(residents, consumption);
                houses.Add(house);
            }

            City city = new City(houses);
            
            cities.Add(city);
            numberOfHouses = Convert.ToInt32(Console.ReadLine());
            
        }

        foreach (City city in cities)
        {
            cityNumber++;
            Console.WriteLine($"Cidade# {cityNumber}:");
            
            var sumByAverageConsumption = city.SumPersonByAverageConsumption();
            foreach (var kvp in sumByAverageConsumption.OrderBy(kvp => kvp.Key))
            {
                Console.Write($"{kvp.Value}-{kvp.Key} ");
            }
            Console.WriteLine();

            Console.WriteLine($"Consumo medio: {Math.Floor(city.AverageConsumption() * 100) / 100:F2}".Replace(',', '.') + " m3.");

            Console.WriteLine();
        }

    }
}

class City
{
    public List<House> Houses { get; set; }

    public City()
    {
        
    }
    public City(List<House> houses)
    {
        Houses = houses;
    }
    public double AverageConsumption()
    {
        double consumption = 0.0;
        int people = 0;
        foreach (House house in Houses)
        {
            consumption += house.Consumption;
            people += house.Residents;
        }

        return consumption / people;
    }
    public Dictionary<int, int> SumPersonByAverageConsumption()
    {
        // Agrupando as casas pelo consumo médio
        var housesPerAvgConsumption = Houses.GroupBy(house => house.AverageConsumption());

        // Calculando a soma dos moradores em cada grupo
        var sumByAverageConsumption = new Dictionary<int, int>();
        foreach (var group in housesPerAvgConsumption)
        {
            int avgConsumption = (int)Math.Floor(group.Key);
            int totalResidents = group.Sum(house => house.Residents);
            if (!sumByAverageConsumption.ContainsKey(avgConsumption))
            {
                sumByAverageConsumption.Add(avgConsumption, totalResidents);
            }
            else
            {
                sumByAverageConsumption[avgConsumption] += totalResidents;
            }
        }

        return sumByAverageConsumption;
    }

}

class House
{
    public int Residents { get; set; }
    public int Consumption { get; set; }
    
    public House(int residents, int consumption)
    {
        Residents = residents;
        Consumption = consumption;
    }

    public double AverageConsumption()
    {
        return Consumption / (double)Residents;
    }
}