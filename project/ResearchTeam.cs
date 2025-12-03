namespace project;

using System;
using System.Linq;

public class ResearchTeam
{
    private string topic;
    private string organization;
    private int regNumber;
    private TimeFrame duration;
    private Paper[] papers;

    public ResearchTeam(string topic, string organization, int regNumber, TimeFrame duration)
    {
        this.topic = topic;
        this.organization = organization;
        this.regNumber = regNumber;
        this.duration = duration;
        this.papers = new Paper[0];
    }

    public ResearchTeam() : this("Тема по умолчанию", "Организация по умолчанию", 0, TimeFrame.Year) { }

    public string Topic
    {
        get => topic;
        set => topic = value;
    }

    public string Organization
    {
        get => organization;
        set => organization = value;
    }

    public int RegNumber
    {
        get => regNumber;
        set => regNumber = value;
    }

    public TimeFrame Duration
    {
        get => duration;
        set => duration = value;
    }

    public Paper[] Papers
    {
        get => papers;
        set => papers = value;
    }

    public Paper LatestPaper
    {
        get
        {
            if (papers == null || papers.Length == 0)
                return null;
            return papers.OrderByDescending(p => p.Date).FirstOrDefault();
        }
    }

    public bool this[TimeFrame tf]
    {
        get => duration == tf;
    }

    public void AddPapers(params Paper[] newPapers)
    {
        if (newPapers == null || newPapers.Length == 0) return;
        papers = papers.Concat(newPapers).ToArray();
    }
    public void showDate(DateTime date)
    {
        bool found = false;
        foreach (var p in papers)
        {
            if (p.Date == date.Date)
            {
                Console.WriteLine(p);
                found = true;
            }

        }
        if (!found)
        {
            Console.WriteLine("На эту дату нет публицаций");
        }
    }

    public override string ToString()
    {
        string papersInfo = papers.Length == 0 ? "Нет публикаций" :
            string.Join("\n", papers.Select(p => p.ToString()));
        return $"Тема: {topic}, Организация: {organization}, Рег. номер: {regNumber}, " +
               $"Продолжительность: {duration}\nПубликации:\n{papersInfo}";
    }

    public virtual string ToShortString()
    {
        return $"Тема: {topic}, Организация: {organization}, Рег. номер: {regNumber}, Продолжительность: {duration}";
    }
}
