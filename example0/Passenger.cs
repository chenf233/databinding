namespace example0
{
    public class Passenger
    {
        public int Id { get; }
        public string Name { get; set; }

        private static int _lastId = 0;

        public Passenger(string name)
        {
            Id = ++_lastId;
            Name = name;
        }
    }
}