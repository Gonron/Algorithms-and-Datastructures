using System.Collections.Generic;

namespace AirportQueueSystem {
    public class Plane {
        public Time DepartureTime { get; }
        public int SeatCount { get; } = 200;
        public List<Passenger> Passengers { get; } = new List<Passenger>();

        public override string ToString() {
            return $"Plane that leaves at {DepartureTime}";
        }

        public Plane(Time departureTime) {
            DepartureTime = departureTime;
        }
    }
}