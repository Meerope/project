using System;

namespace project
{
    public class Team : INameAndCopy
    {
        protected string organization;
        protected int regNumber;

        public Team(string org, int reg)
        {
            Organization = org; RegNumber = reg;
        }
        public Team() : this("Орг по умолчанию", 1) { }

        public string Organization
        {
            get => organization;
            set => organization = value;
        }
        public int RegNumber
        {
            get => regNumber;
            set
            {
                if (value <= 0) throw new ArgumentException("Регистрационный номер должен быть > 0");
                regNumber = value;
            }
        }

        public string Name { get => Organization; set => Organization = value; }
        public virtual object DeepCopy() => new Team(organization, regNumber);

        public override string ToString() => $"Орг: {organization}, Рег.№: {regNumber}";

        public override bool Equals(object obj) =>
            obj is Team t && organization == t.organization && regNumber == t.regNumber;

        public override int GetHashCode() => HashCode.Combine(organization, regNumber);

        public static bool operator ==(Team a, Team b) => Equals(a, b);
        public static bool operator !=(Team a, Team b) => !Equals(a, b);
    }
}