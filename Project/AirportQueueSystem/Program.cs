using System;
using System.Collections.Generic;
using System.Threading;
using AirportQueueSystem.Queue;

namespace AirportQueueSystem {
    class Program {
        private static readonly List<Plane> Planes = new List<Plane>();
        private static PassengerProducer _producer;
        private static PassengerConsumer _consumer;
        private static IPriorityQueue<Passenger> _queue;
        private static Clock _clock;

        private static void Setup() {
            for (var hour = 7; hour <= 22; hour++) {
                Planes.Add(new Plane(new Time(hour, 00, 00)));
            }

            _queue = new PriorityQueue<Passenger>(10_000);
            _producer = new PassengerProducer(Planes, _queue);
            _consumer = new PassengerConsumer(Planes, _queue);
            _clock = new Clock(_producer, _consumer, new Time(05, 00, 00));
        }

        public static void Main(string[] args) {
            Setup();
            Console.WriteLine("Hello Airport");
            var newThread = new Thread(new ThreadStart(_clock.Run));
            newThread.Start();
        }
    }
}