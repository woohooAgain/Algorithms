using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetworkSimulation
{
    public static class Program
    {        
        public static void Main()
        {
            var runAgain = "y";
            while (runAgain != "n")
            {
                var commonInput = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                var bufferSize = commonInput.ElementAt(0);
                var packetQuantity = commonInput.ElementAt(1);
                if (packetQuantity <= 0)
                {
                    return;
                }
                var packets = new Queue<Packet>(packetQuantity);
                var finishTimes = new List<int>(bufferSize + 1);
                for (var i = 0; i < packetQuantity; i++)
                {
                    packets.Enqueue(new Packet(Console.ReadLine()));
                }

                PrintStartTimes(bufferSize, finishTimes, packets);
                runAgain = Console.ReadLine();
            }
            
        }

        private static void PrintStartTimes(int bufferSize, List<int> finishTimes, Queue<Packet> packets)
        {
            while (packets.Any())
            {
                var currentPacket = packets.Dequeue();
                if (!finishTimes.Any())
                {
                    finishTimes.Add(currentPacket.ArrivalTime);
                    finishTimes.Add(currentPacket.ProcessingTime);
                }
                else
                {
                    //todo while-loop
                    for(var i = 1; i < finishTimes.Count; i++)
                    {
                        if (finishTimes[i] <= currentPacket.ArrivalTime)
                        {
                            Console.WriteLine(finishTimes[i-1]);
                            finishTimes[i - 1] = finishTimes[i]; 
                            finishTimes.Remove(finishTimes[i]);
                        }
                    }
                    if (finishTimes.Count <= bufferSize)
                    {
                        finishTimes.Add(finishTimes.Last() + currentPacket.ProcessingTime);
                    }
                    else
                    {
                        Console.WriteLine(-1);
                    }
                }
            }
            for(var i = 1; i < finishTimes.Count; i++)
            {
                Console.WriteLine(finishTimes[i]);
            }
        }

        private class Packet
        {
            public int ArrivalTime { get; set; }
            public int ProcessingTime { get; set; }
            
            public Packet(string input)
            {
                var numbers = input.Split(' ').Select(int.Parse).ToList();
                ArrivalTime = numbers[0];
                ProcessingTime = numbers[1];
            }
        }
    }
}