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
            var commonInput = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var bufferSize = commonInput.ElementAt(0);
            var packetQuantity = commonInput.ElementAt(1);
            if (packetQuantity <= 0)
            {
                return;
            }

            var packets = new Queue<Packet>(packetQuantity);
            var finishTimes = new List<int>(bufferSize);
            for (var i = 0; i < packetQuantity; i++)
            {
                packets.Enqueue(new Packet(Console.ReadLine()));
            }

            PrintStartTimes(bufferSize, finishTimes, packets);
        }

        private static void PrintStartTimes(int bufferSize, List<int> finishTimes, Queue<Packet> packets)
        {
            while (packets.Any())
            {
                var currentPacket = packets.Dequeue();
                for (var i = 0; i < finishTimes.Count; i++)
                {
                    if (finishTimes[i] <= currentPacket.ArrivalTime)
                    {
                        finishTimes.Remove(finishTimes[i]);
                    }
                    else
                    {
                        break;
                    }
                }
                if (!finishTimes.Any())
                {
                    finishTimes.Add(currentPacket.ArrivalTime + currentPacket.ProcessingTime);
                    Console.WriteLine(currentPacket.ArrivalTime);
                }
                else
                {
                    if (finishTimes.Count < bufferSize)
                    {
                        Console.WriteLine(finishTimes.Last());
                        finishTimes.Add(finishTimes.Last() + currentPacket.ProcessingTime);
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