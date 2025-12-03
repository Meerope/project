namespace project;

public class Paper
{
    public string Title { get; set; }
    public Person Author { get; set; }
    public DateTime Date { get; set; }

    public Paper(string title, Person author, DateTime date)
    {
        Title = title;
        Author = author;
        Date = date;
    }

    public Paper() : this("Без названия", new Person(), DateTime.MinValue) { }

    public override string ToString()
    {
        return $"Публикация: {Title}, Автор: {Author}, Дата: {Date.ToShortDateString()}";
    }
}