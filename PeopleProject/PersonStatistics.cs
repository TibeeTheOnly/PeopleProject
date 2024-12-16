namespace PeopleProject
{
    public class PersonStatistics
    {
        internal List<Person> people = new List<Person>();
        internal void addPerson(int id, string name, int age, bool isStudent, int score)
        {
            bool isIdNew = people.Find(x => x.GetId() == id) == null;;
            if (name != null && name != "" && age > 0 && score >= 0 && isIdNew)
            {
                people.Add(new Person(id, name, age, isStudent, score));
            }
            else if (!isIdNew)
            {
                throw new ArgumentException("Már létező id!");
            }
            else if (name == null || name == "")
            {
                throw new ArgumentException("A név nem lehet üres!");
            }
            else if (age < 0)
            {
                throw new ArgumentException("Az életkor nem lehet negatív!");
            }
            else if (score < 0)
            {
                throw new ArgumentException("A pontszám nem lehet negatív!");
            }
        }
        
        internal Person idKereso(int id)
        {
            var person = people.Find(x => x.GetId() == id);
            if(person == null)
            {
                throw new ArgumentException("Nincs ilyen id!");
            }
            else
            {
                return person;
            }
        }

    }
}
