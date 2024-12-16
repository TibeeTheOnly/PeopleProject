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

        internal int getAverageAge()
        {
            if (people.Count == 0)
            {
                throw new ArgumentException("Nincs egyetlen személy sem!");
            }
            else
            {
                int sum = 0;
                foreach (var person in people)
                {
                    sum += person.GetAge();
                }
                return sum / people.Count;
            }
        }

        internal int getNumberOfStudents()
        {
            if(people.Count == 0)
            {
                throw new ArgumentException("Nincs egyetlen személy sem!");
            }
            else
            {
                foreach (var person in people)
                {
                    if (person.GetIsStudent())
                    {
                        return people.Count(x => x.GetIsStudent());
                    }
                }
                return 0; ;
            }
        }

        internal Person getPersonWithHighestScore()
        {
            if (people.Count == 0)
            {
                throw new ArgumentException("Nincs egyetlen személy sem!");
            }
            else
            {
                var person = people.Find(x => x.GetScore() == people.Max(x => x.GetScore()));
                return person;
            }
        }

        internal double getAvarageScoreOfStudents()
        {
            if(people.Count == 0)
            {
                throw new ArgumentException("Nincs egyetlen személy sem!");
            }
            else
            {
                int sum = 0;
                int count = 0;
                foreach (var person in people)
                {
                    if (person.GetIsStudent())
                    {
                        sum += person.GetScore();
                        count++;
                    }
                }
                return sum / count;
            }
        }

        internal Person getOldestStudent()
        {
            if (people.Count == 0)
            {
                throw new ArgumentException("Nincs egyetlen személy sem!");
            }
            else
            {
                var oldestStudent = people
                    .Where(x => x.GetIsStudent())
                    .OrderByDescending(x => x.GetAge())
                    .FirstOrDefault();
                return oldestStudent;
            }
        }

        internal bool isAnyoneFailing()
        {
            if(people.Count == 0)
            {
                throw new ArgumentException("Nincs egyetlen személy sem!");
            }
            else
            {
                return people.Any(x => x.GetScore() < 40);
            }
        }
    }
}
