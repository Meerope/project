namespace project;
class Program
{
    static void Main()
    {
        var team = new ResearchTeam("Машинное обучение", "ИТИ БГУ", 1001, TimeFrame.Year);
        Console.WriteLine("ToShortString():");
        Console.WriteLine(team.ToShortString());
        Console.WriteLine();

        Console.WriteLine("Индексаторы по TimeFrame:");
        Console.WriteLine($"Year: {team[TimeFrame.Year]}");
        Console.WriteLine($"TwoYears: {team[TimeFrame.TwoYears]}");
        Console.WriteLine($"Long: {team[TimeFrame.Long]}");
        Console.WriteLine();

        team.Topic = "Нейронные сети для анализа текстов";
        team.Organization = "Лаборатория ИИ";
        team.RegNumber = 20251203;
        team.Duration = TimeFrame.TwoYears;
        team.Papers = Array.Empty<Paper>();
        Console.WriteLine("ToString() после присвоения свойств:");
        Console.WriteLine(team.ToString());
        Console.WriteLine();

        var author1 = new Person("Тимур", "Сергеев", new DateTime(1995, 4, 12));
        var author2 = new Person("Анна", "Ковалёва", new DateTime(1994, 11, 3));

        var paper1 = new Paper("Контекстные эмбеддинги в русскоязычных корпусах", author1, new DateTime(2023, 10, 1));
        var paper2 = new Paper("Оптимизация токенизации для морфологически богатых языков", author2, new DateTime(2024, 5, 20));
        var paper3 = new Paper("Мультимодальные модели для извлечения знаний", author1, new DateTime(2025, 2, 14));

        team.AddPapers(paper1, paper2, paper3);
        Console.WriteLine("ToString() после AddPapers:");
        Console.WriteLine(team.ToString());
        Console.WriteLine();

        Console.WriteLine("Самая поздняя публикация:");
        Console.WriteLine(team.LatestPaper?.ToString() ?? "Нет публикаций");
        Console.WriteLine();

        Console.WriteLine("Введите nrow и ncolumn в одной строке. Допустимые разделители: пробел, запятая, точка с запятой, табуляция");
        Console.Write("Например: 500, 20 или 500;20 или 500 20: ");
        var input = Console.ReadLine();
        var parts = input.Split(new[] { ' ', ',', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int nrow = int.Parse(parts[0]);
        int ncolumn = int.Parse(parts[1]);
        int total = nrow * ncolumn;

        var oneD = new Paper[total];
        for (int i = 0; i < total; i++)
            oneD[i] = new Paper();

        var rect = new Paper[nrow, ncolumn];
        for (int i = 0; i < nrow; i++)
            for (int j = 0; j < ncolumn; j++)
                rect[i, j] = new Paper();

        var jag = new Paper[nrow][];
        for (int i = 0; i < nrow; i++)
        {
            jag[i] = new Paper[ncolumn];
            for (int j = 0; j < ncolumn; j++)
                jag[i][j] = new Paper();
        }

        var newTitle = "Обновлённый заголовок";

        int t1Start = Environment.TickCount;
        for (int i = 0; i < total; i++)
            oneD[i].Title = newTitle;
        int t1End = Environment.TickCount;
        int t1 = t1End - t1Start;

        int t2Start = Environment.TickCount;
        for (int i = 0; i < nrow; i++)
            for (int j = 0; j < ncolumn; j++)
                rect[i, j].Title = newTitle;
        int t2End = Environment.TickCount;
        int t2 = t2End - t2Start;

        int t3Start = Environment.TickCount;
        for (int i = 0; i < nrow; i++)
            for (int j = 0; j < ncolumn; j++)
                jag[i][j].Title = newTitle;
        int t3End = Environment.TickCount;
        int t3 = t3End - t3Start;

        Console.WriteLine("Сравнение времени операций присваивания свойства Title:");
        Console.WriteLine($"nrow: {nrow}, ncolumn: {ncolumn}, total: {total}");
        Console.WriteLine($"Одномерный массив (Paper[]): {t1} мс");
        Console.WriteLine($"Двумерный прямоугольный (Paper[,]): {t2} мс");
        Console.WriteLine($"Двумерный ступенчатый (Paper[][]): {t3} мс");
    }
}
