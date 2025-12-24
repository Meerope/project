using System;

namespace project
{
    class Program
    {
        static void Main()
        {
            // 1. Два Team с совпадающими данными
            Team t1 = new Team("Org", 123);
            Team t2 = new Team("Org", 123);
            Console.WriteLine($"Ссылки равны: {ReferenceEquals(t1, t2)}");
            Console.WriteLine($"Объекты равны (Equals): {t1.Equals(t2)}");
            Console.WriteLine($"==: {t1 == t2}, !=: {t1 != t2}");
            Console.WriteLine($"Hash1: {t1.GetHashCode()}, Hash2: {t2.GetHashCode()}");
            Console.WriteLine();

            // 19. Исключение при некорректном рег. номере
            try
            {
                t1.RegNumber = 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
            Console.WriteLine();

            // 20. Создать ResearchTeam, добавить участников и публикации
            var rt = new ResearchTeam("BioCenter", "Генетика", 202, TimeFrame.TwoYears);
            var p1 = new Person("Иван", "Иванов", new DateTime(1985, 5, 12));
            var p2 = new Person("Анна", "Сидорова", new DateTime(2000, 3, 15));
            var p3 = new Person("Мария", "Кузнецова", new DateTime(1990, 10, 10));

            rt.AddMembers(p1, p2, p3);
            rt.AddPapers(
                new Paper("Марс", p1, new DateTime(2020, 1, 1)),
                new Paper("Луна", p1, new DateTime(2021, 6, 1)),
                new Paper("Гены", p2, new DateTime(2024, 2, 10)),
                new Paper("Эпигенетика", p2, new DateTime(2023, 7, 9)),
                new Paper("С++", p3, new DateTime(2018, 11, 14))
            );
            Console.WriteLine(rt.ToString());
            Console.WriteLine();

            // 21. Вывести значение свойства Team
            Console.WriteLine();

            // 22. DeepCopy() -> изменить исходный, проверить независимость
            var rtCopy = (ResearchTeam)rt.DeepCopy();
            rt.Organization = "NewOrg";
            rt.Topic = "Нейросети";
            ((Person)rt.Members[0]).FirstName = "Переименован";
            ((Paper)rt.Papers[0]).Title = "Изменённая публикация";

            Console.WriteLine("Исходный изменённый объект:");
            Console.WriteLine(rt.ToString());
            Console.WriteLine("\nКопия должна остаться без изменений:");
            Console.WriteLine(rtCopy.ToString());
            Console.WriteLine();

            // 23. foreach: участники без публикаций
            Console.WriteLine("Участники без публикаций:");
            foreach (var person in rt.MembersWithoutPapers())
                Console.WriteLine(person.ToShortString());
            Console.WriteLine();

            // 24. foreach: публикации за последние два года
            Console.WriteLine("Публикации за последние 2 года:");
            foreach (var paper in rt.PapersLastNYears(2))
                Console.WriteLine(paper.ToString());
            Console.WriteLine();

            // 25. IEnumerable: участники с публикациями
            Console.WriteLine("Участники с публикациями (IEnumerable):");
            foreach (Person person in rt)
                Console.WriteLine(person.ToShortString());
            Console.WriteLine();

            // 26. Итератор: участники с более чем одной публикацией
            Console.WriteLine("Участники с более чем одной публикацией:");
            foreach (var person in rt.MembersWithMoreThanOnePublication())
                Console.WriteLine(person.ToShortString());
            Console.WriteLine();

            // 27. Итератор: публикации за последний год
            Console.WriteLine("Публикации за последний год:");
            foreach (var paper in rt.PapersLastYear())
                Console.WriteLine(paper.ToString());
        }
    }
}
