using System;

namespace AirportQueueSystem {
    public class Passenger : IComparable<Passenger> {
        public int ID { get; private set; }
        public Time ArrivalTime { get; private set; }
        public Plane Plane { get; private set; }
        public Category Category { get; private set; }
        public Status Status = Status.Waiting;

        public Passenger(int id, Time arrivalTime, Category category, Plane plane) {
            this.ID = id;
            ArrivalTime = arrivalTime;
            this.Plane = plane;
            Category = category;
        }

        public override string ToString() {
            return $"{ID}) arrived {ArrivalTime} as {Category} and is {Status}";
        }

        public int CompareTo(Passenger other) {
            if (Category.CompareTo(other.Category) != 0)
                return Category.CompareTo(other.Category);
            return ArrivalTime.CompareTo(other.ArrivalTime);
        }
    }
}