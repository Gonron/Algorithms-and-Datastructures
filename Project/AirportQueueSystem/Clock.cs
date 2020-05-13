using System;
using System.Threading;

namespace AirportQueueSystem {
    public class Clock {
        private const long SleepingTime = 10;
        private bool _running = true;
        private PassengerProducer _producer;
        private PassengerConsumer _consumer;
        private long _millis;

        public Time Time {
            get { return new Time(_millis); }
        }

        public Clock(PassengerProducer producer, PassengerConsumer consumer, Time startTime) {
            _producer = producer;
            _consumer = consumer;
            _millis = startTime.Millis;
        }

        public void Stop() {
            _running = false;
        }

        public void Run() {
            try {
                while (_running) {
                    Thread.Sleep((int) SleepingTime);
                    _producer.Tick(this);
                    _consumer.Tick(this);
                    _millis += 1000;
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}