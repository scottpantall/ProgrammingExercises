using System;

namespace ScottPantall
{
    public class Movie
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public Movie(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
