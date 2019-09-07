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
            var stationDistancesList = stationDistancesString.Split(' ').Select(d => int.Parse(d)).ToList();
            stationDistancesList.Add(int.Parse(totalWay));
            stationDistancesList.Insert(0, 0);
            var result = CountStopsNumber(int.Parse(maxDistanceOnFullTank), stationDistancesList, 0);
            
            Console.WriteLine($"{result}");
        }
        static int CountStopsNumber(int maxDistance, List<int> stations, int currentPoint)
        {
            var stops = 0;
            for(var i = currentPoint; i < stations.Count(); i++)
            {
                if (i != stations.Count() - 1)
                {
                    var distance = stations[i+1] - stations[currentPoint];
                    if(distance > maxDistance)
                    {
                        if(i != currentPoint)
                        {
                            stops++;
                            var otherStops = CountStopsNumber(maxDistance, stations, i);
                            if (otherStops == -1)
                            {
                                return -1;
                            }
                            stops += otherStops;
                            break;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }                
            }
            return stops;
        }
    }
}