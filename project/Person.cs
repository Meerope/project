using System;

namespace project
{
    public class Person : INameAndCopy
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string n, string s, DateTime d)
        {
            FirstName = n; LastName = s; BirthDate = d;
        }
        public Person() : this("Иван", "Иванов", new DateTime(2000, 1, 1)) { }

        public string Name
        {
            get => $"{FirstName} {LastName}";
            set
            {
                var parts = value.Split(' ');
                FirstName = parts[0];
                LastName = parts.Length > 1 ? parts[1] : "";
            }
        }

        public virtual object DeepCopy() => new Person(FirstName, LastName, new DateTime(BirthDate.Ticks));

        public override string ToString() => $"{FirstName} {LastName}, {BirthDate:dd.MM.yyyy}";
        public virtual string ToShortString() => $"{FirstName} {LastName}";

        public override bool Equals(object obj) =>
            obj is Person p && FirstName == p.FirstName && LastName == p.LastName && BirthDate == p.BirthDate;

        public override int GetHashCode() => HashCode.Combine(FirstName, LastName, BirthDate);

        public static bool operator ==(Person a, Person b) => Equals(a, b);
        public static bool operator !=(Person a, Person b) => !Equals(a, b);
    }
}