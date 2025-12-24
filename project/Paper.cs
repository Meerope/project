using System;

namespace project
{
    public class Paper : INameAndCopy
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime Date { get; set; }

        public Paper(string title, Person author, DateTime date)
        {
            Title = title; Author = author; Date = date;
        }
        public Paper() : this("Без названия", new Person(), DateTime.MinValue) { }

        public string Name { get => Title; set => Title = value; }
        public virtual object DeepCopy() => new Paper(Title, (Person)Author.DeepCopy(), new DateTime(Date.Ticks));

        public override string ToString() => $"{Title}, {Author.ToShortString()}, {Date:dd.MM.yyyy}";
    }
}