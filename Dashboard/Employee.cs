using System;

namespace Dashboard
{
    internal class Employee
    {
        internal int id;

        public int ID { get; internal set; }
        public int Count { get; internal set; }
        public string Name { get; internal set; }
        public string Email { get; internal set; }
        public DateTime Dob { get; internal set; }
        public string Address { get; internal set; }
        public string Password { get; internal set; }
    }
}