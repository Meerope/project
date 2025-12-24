using System;
using System.Collections;
using System.Linq;

namespace project
{
    public class ResearchTeam : Team, IEnumerable
    {
        private string topic;
        private TimeFrame duration;
        private ArrayList members = new ArrayList();
        private ArrayList papers = new ArrayList();

        public ResearchTeam(string org, string topic, int reg, TimeFrame dur) : base(org, reg)
        {
            this.topic = topic; duration = dur;
        }
        public ResearchTeam() : this("Орг по умолчанию", "Тема по умолчанию", 1, TimeFrame.Year) { }

        public string Topic { get => topic; set => topic = value; }
        public TimeFrame Duration { get => duration; set => duration = value; }
        public ArrayList Members => members;
        public ArrayList Papers => papers;

        public Paper LatestPaper => papers.Count == 0 ? null :
            papers.Cast<Paper>().OrderByDescending(p => p.Date).FirstOrDefault();

        public bool this[TimeFrame tf] => duration == tf;

        public void AddMembers(params Person[] persons) { foreach (var p in persons) members.Add(p); }
        public void AddPapers(params Paper[] ps) { foreach (var p in ps) papers.Add(p); }

        public override string ToString()
        {
            string mems = members.Count == 0 ? "Нет участников" : string.Join("; ", members.Cast<Person>());
            string pubs = papers.Count == 0 ? "Нет публикаций" : string.Join("; ", papers.Cast<Paper>());
            return $"{base.ToString()}, Тема: {topic}, Длительность: {duration}\nУчастники: {mems}\nПубликации: {pubs}";
        }
        public string ToShortString() => $"{base.ToString()}, Тема: {topic}, Длительность: {duration}";

        public override object DeepCopy()
        {
            var copy = new ResearchTeam(organization, topic, regNumber, duration);
            foreach (Person m in members) copy.members.Add(m.DeepCopy());
            foreach (Paper p in papers) copy.papers.Add(p.DeepCopy());
            return copy;
        }

        // Итераторы
        public IEnumerable<Person> MembersWithoutPapers()
        {
            foreach (Person m in members)
                if (!papers.Cast<Paper>().Any(p => p.Author == m))
                    yield return m;
        }
        public IEnumerable<Paper> PapersLastNYears(int n)
        {
            DateTime cutoff = DateTime.Now.AddYears(-n);
            foreach (Paper p in papers)
                if (p.Date > cutoff) yield return p;
        }
        public IEnumerable<Person> MembersWithMoreThanOnePublication()
        {
            foreach (Person m in members)
                if (papers.Cast<Paper>().Count(p => p.Author == m) > 1)
                    yield return m;
        }
        public IEnumerable<Paper> PapersLastYear()
        {
            DateTime cutoff = DateTime.Now.AddYears(-1);
            foreach (Paper p in papers)
                if (p.Date > cutoff) yield return p;
        }

        // IEnumerable: участники с публикациями
        public IEnumerator GetEnumerator()
        {
            return members.Cast<Person>().Where(m => papers.Cast<Paper>().Any(p => p.Author == m)).GetEnumerator();
        }
    }
}
