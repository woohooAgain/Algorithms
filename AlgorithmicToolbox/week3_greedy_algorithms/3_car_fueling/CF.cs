using System;
using System.Collections.Generic;
using System.Linq;

namespace CarFueling
{
    class Program
    {
        static void Main()
        {
            var totalWay = Console.ReadLine();
            var maxDistanceOnFullTank = Console.ReadLine();
            var numberOfStations = Console.ReadLine();
            var stationDistancesString = Console.ReadLine();
            var stationDistancesArray = stationDistancesString.Split(' ').Select(d => int.Parse(d)).ToList();
            var visitedStations = new List<int>(int.Parse(numberOfStations));
            var result = 0;
            var currentDistance = 0;
            var lastStation = 0;
            // for(var i = 0; i < int.Parse(numberOfStations); i++)
            // {
                
            // }
            Console.WriteLine($"{result}");
        }

        static int CountNextStation(List<int> stations, int currentStation, int maxDistance, int numberOfStations)
        {
            var currentDistance = 0;
            var lastStation = 0;
            for (var i = currentStation; i <= numberOfStations; i++)
            {
                if (currentDistance + stations[i] < maxDistance)
                {
                    currentDistance += stations[i];
                    lastStation = i;
                }
            }
            if (currentDistance == 0 && lastStation == 0)
            {
                return -1;
            }
            else
            {
                return lastStation;
            }
        }
    }
}