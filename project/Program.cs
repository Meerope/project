namespace project;
class Program
{
    static void Main()
    {
        // Задание 1
        Person p1 = new Person();
        Person p2 = new Person("Иван", "Иванов", new DateTime(1985, 5, 12));
        Console.WriteLine(p1.ToShortString());
        Console.WriteLine(p1.ToString());
        Console.WriteLine(p2.ToShortString());
        Console.WriteLine(p2.ToString());

        // Задание 2
        Person anna = new Person("Анна", "Сидоровна", new DateTime(2000, 3, 15));
        anna.Y = 1999;

        // Задание 3
        TimeFrame year = TimeFrame.Year;
        TimeFrame twoYears = TimeFrame.TwoYears;
        TimeFrame longTime = TimeFrame.Long;

        Console.WriteLine(year);
        Console.WriteLine(twoYears);
        Console.WriteLine(longTime);

        // Задание 4
        Person petr =  new Person("Пётр", "Петров", new DateTime(1970, 1, 1));
        Paper paper = new Paper("Современные технологии", petr, new DateTime(2020, 1, 20));
        Console.WriteLine(paper.ToString());

        // Задание 5
        Person maria = new Person("Мария", "Кузнецова", new DateTime(1980, 10, 10));
        Paper paper3 = new Paper("Наука и жизнь", maria,  new DateTime(2019, 5, 15));
        paper3.Title = "Научные открытия";
        paper3.Date = new DateTime(2021, 6, 1);

        // Задание 6
        ResearchTeam ai = new ResearchTeam("Искуственный Интеллект", "TechLab", 101, TimeFrame.Year);
        Console.WriteLine(ai.ToShortString());

        // Задание 7
        ResearchTeam genetika = new ResearchTeam("Генетика", "BioCenter", 202, TimeFrame.TwoYears);
        Console.WriteLine(genetika[TimeFrame.Year]);
        Console.WriteLine(genetika[TimeFrame.TwoYears]);
        Console.WriteLine(genetika[TimeFrame.Long]);

        // Задание 8
        ResearchTeam defaultTeam = new ResearchTeam();
        defaultTeam.Topic = "Космос";
        defaultTeam.Organization = "SpaceCorp";
        defaultTeam.RegNumber = 303;
        defaultTeam.Duration = TimeFrame.Long;

        Person author1 = new Person("Иван", "Иванов",  new DateTime(1985, 5, 12));
        Person author2 = new Person("Анна", "Сидорова",  new DateTime(2000, 3, 15));

        Paper paper1 = new Paper("Марс", author1, new DateTime(2020, 1, 1));
        Paper paper2 = new Paper("Луна", author1, new DateTime(2021, 6, 1));

        defaultTeam.Papers = new[] {paper1, paper2};

        Console.WriteLine(defaultTeam.ToString());
                

    }
}