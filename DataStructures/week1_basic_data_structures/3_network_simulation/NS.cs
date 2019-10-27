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
                var finishTimes = new List<Packet>(bufferSize);
                for (var i = 0; i < packetQuantity; i++)
                {
                    packets.Enqueue(new Packet(Console.ReadLine()));
                }

                PrintStartTimes(bufferSize, finishTimes, packets);
                runAgain = Console.ReadLine();
            }
            
        }

        private static void PrintStartTimes(int bufferSize, List<Packet> finishTimes, Queue<Packet> packets)
        {
            while (packets.Any())
            {
                var currentPacket = packets.Dequeue();
                //todo while-loop
                    for(var i = 0; i < finishTimes.Count; i++)
                    {
                        if (finishTimes[i].ProcessingTime <= currentPacket.ArrivalTime)
                        {
                            finishTimes.Remove(finishTimes[i]);
                        }
                    }
                if (!finishTimes.Any())
                {
                    finishTimes.Add(currentPacket);
                    Console.WriteLine(currentPacket.ArrivalTime);
                }
                else
                {
                    if (finishTimes.Count < bufferSize)
                    {
                        currentPacket.ArrivalTime = finishTimes.Last().ProcessingTime;
                        currentPacket.ProcessingTime = currentPacket.ArrivalTime + currentPacket.ProcessingTime;
                        finishTimes.Add(currentPacket);
                        Console.WriteLine(currentPacket.ArrivalTime);
                    }
                    else
                    {
                        Console.WriteLine(-1);
                    }
                }
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