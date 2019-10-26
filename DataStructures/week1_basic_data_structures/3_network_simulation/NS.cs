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
            var finishTmes = new List<int>(bufferSize);
            for (var i = 0; i < packetQuantity; i++)
            {
                packets.Enqueue(new Packet(Console.ReadLine()));
            }

            PrintStartTimes(bufferSize, finishTmes, packets);
        }

        private static void PrintStartTimes(int bufferSize, List<int> finishTmes, Queue<Packet> packets)
        {
            var startTime = 0;
            while (packets.Any())
            {
                var currentPacket = packets.Dequeue();
                if (!finishTmes.Any())
                {
                    Console.WriteLine(currentPacket.ArrivalTime);
                }
                else
                {
                    for(var i = 0; i < finishTmes.Count; i++)
                    {
                        if (finishTmes[i] < currentPacket.ArrivalTime)
                        {
                            Console.WriteLine(finishTmes[i]);
                            finishTmes.Remove(finishTmes[i]);
                        }
                    }
                    if (finishTmes.Count < bufferSize)
                    {
                        finishTmes.Add(finishTmes.Last() + currentPacket.ProcessingTime);
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