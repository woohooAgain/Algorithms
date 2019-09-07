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
            var result = 0;
            var stationDistancesList = stationDistancesString.Split(' ').Select(d => int.Parse(d)).ToList();
            //stationDistancesList.Add(int.Parse(totalWay));
            try
            {
                var distances = CountDistancesBetweenStations(stationDistancesList, int.Parse(totalWay), int.Parse(maxDistanceOnFullTank));
                result = CountStopsNumber(distances, int.Parse(maxDistanceOnFullTank));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex}");
                result = -1;
            }
            
            Console.WriteLine($"{result}");
        }

        static List<int> CountDistancesBetweenStations(List<int> stations, int totalWay, int fullTankDistance)
        {
            var result = new List<int>(stations.Count()+1);
            var localStations = new List<int>(stations);
            localStations.Insert(0,0);
            localStations.Add(totalWay);
            for(var i = 0; i < localStations.Count() - 1; i++)
            {
                Console.WriteLine($"{i} {localStations[i]} {localStations[i+1]}");
                var distance = localStations[i] - localStations[i+1];
                if (distance > fullTankDistance)
                {
                    throw new Exception();
                }
                result.Add(localStations[i] - localStations[i+1]);                
            }
            return result;
        }

        static int CountStopsNumber(List<int> stations, int maxDistance)
        {
            var stopsCounter = 0;
            var i = 0;
            while(i < stations.Count())
            {
                var j = i;
                var currentDistance = stations[j];
                while(currentDistance<=maxDistance && j < stations.Count())
                {
                    j++;
                    currentDistance += stations[j];
                }
                if (currentDistance > maxDistance)
                {
                    stopsCounter++;
                }
            };
            return stopsCounter;
        }
    }
}