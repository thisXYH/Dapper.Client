using System;

namespace Dapper.Client.Test
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime? Birthday { get; set; }

        public float? Height { get; set; }

        public float? Weight { get; set; }

        public DateTime InsertTime { get; set; }
    }
}
