using System.Collections.Generic;

namespace example0
{
    public class Airplane
    {
        private static int _lastId = 0;

        public int Id { get; }
        public string Model { get; set; }
        public int FuelKg { get; }
        public List<Passenger> Passengers { get; set; }

        public Airplane(string model, int fuelKg)
        {
            Id = ++_lastId;
            Model = model;
            FuelKg = fuelKg;
        }
    }
}