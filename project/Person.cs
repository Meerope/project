namespace project;

public class Person
{
    private string n;       
    private string s;       
    private DateTime d;     

    public Person(string n, string s, DateTime d)
    {
        this.n = n;
        this.s = s;
        this.d = d;
    }

    public Person()
    {
        this.n = "Иван";
        this.s = "Иванов";
        this.d = new DateTime(2000, 1, 1);
    }

    public string N
    {
        get { return n; }
        set { n = value; }
    }

    public string S
    {
        get { return s; }
        set { s = value; }
    }

    public DateTime D
    {
        get { return d; }
        set { d = value; }
    }

    public int Y
    {
        get { return d.Year; }
        set { d = new DateTime(value, d.Month, d.Day); }
    }

    public override string ToString()
    {
        return $"Имя: {n}, Фамилия: {s}, Дата рождения: {d.ToShortDateString()}";
    }

    public virtual string ToShortString()
    {
        return $"{n} {s}";
    }
}