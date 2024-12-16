using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject.Test
{
    [TestFixture]
    internal class PersonStatisticsTest
    {
        PersonStatistics p;

        [SetUp]
        public void Setup()
        {
            p = new PersonStatistics();
            p.addPerson(1, "John", 25, false, 80);
        }
        
        [Test]
        public void TestCorrectInput()
        {
            Assert.That(p.people.Count, Is.EqualTo(1));
            Assert.That(p.idKereso(1), Is.Not.Null);

            var vizsgaltSzemely = p.idKereso(1);
            Assert.That(vizsgaltSzemely.GetId(), Is.EqualTo(1));
            Assert.That(vizsgaltSzemely.GetName(), Is.EqualTo("John"));
            Assert.That(vizsgaltSzemely.GetAge(), Is.EqualTo(25));
            Assert.That(vizsgaltSzemely.GetIsStudent(), Is.False);
            Assert.That(vizsgaltSzemely.GetScore(), Is.EqualTo(80));
        }

        [Test]
        public void TestIdKereso()
        {
            var hiba = Assert.Throws<ArgumentException>(() => p.idKereso(2));
            Assert.That(hiba.Message, Is.EqualTo("Nincs ilyen id!"));
        }
        
        [Test]
        public void TestInvalidId()
        {
            var hiba = Assert.Throws<ArgumentException>(() => p.addPerson(1, "John", 25, false, 80));
            Assert.That(hiba.Message, Is.EqualTo("Már létező id!"));
        }
       
        [Test]
        public void TestEmptyName()
        {
            var hiba = Assert.Throws<ArgumentException>(() => p.addPerson(2, "", 25, false, 80));
            var hiba2 = Assert.Throws<ArgumentException>(() => p.addPerson(2, null, 25, false, 80));
            Assert.That(hiba.Message, Is.EqualTo("A név nem lehet üres!"));
            Assert.That(hiba2.Message, Is.EqualTo("A név nem lehet üres!"));
        }
        
        [Test]
        public void TestInvalidAge()
        {
            var hiba = Assert.Throws<ArgumentException>(() => p.addPerson(2, "John", -1, false, 80));
            Assert.That(hiba.Message, Is.EqualTo("Az életkor nem lehet negatív!"));
        }

        [Test]
        public void TestInvalidScore()
        {
            var hiba = Assert.Throws<ArgumentException>(() => p.addPerson(2, "John", 25, false, -1));
            Assert.That(hiba.Message, Is.EqualTo("A pontszám nem lehet negatív!"));
        }
        
        [Test]
        public void TestAverageAge()
        {
            p.addPerson(2, "Jane", 27, false, 90);
            Assert.That(p.getAverageAge(), Is.EqualTo(26));
        }

        [Test]
        public void TestAverageAgeNoPeople()
        {
            p.people.Clear();
            var hiba = Assert.Throws<ArgumentException>(() => p.getAverageAge());
            Assert.That(hiba.Message, Is.EqualTo("Nincs egyetlen személy sem!"));
        }

        [Test]
        public void TestNumberOfStudentsNoStudents()
        {
            p.people.Clear();
            var hiba = Assert.Throws<ArgumentException>(() => p.getNumberOfStudents());
            Assert.That(hiba.Message, Is.EqualTo("Nincs egyetlen személy sem!"));
        }
        
        [Test]
        public void TestNumberOfStudents()
        {
            p.addPerson(2, "Jane", 27, false, 90);
            p.addPerson(3, "Jack", 22, true, 85);
            Assert.That(p.getNumberOfStudents(), Is.EqualTo(1));
        }

        [Test]
        public void TestNumberOfStudents2()
        {
            Assert.That(p.getNumberOfStudents(), Is.EqualTo(0));
        }

        [Test]
        public void TestNumberOfStudents3()
        {
            p.addPerson(2, "Jane", 27, false, 90);
            p.addPerson(3, "Jack", 22, true, 85);
            p.addPerson(4, "Jill", 19, true, 95);
            Assert.That(p.getNumberOfStudents(), Is.EqualTo(2));
        }

        [Test]
        public void TestPersonWithHighestScoreNoPeople()
        {
            p.people.Clear();
            var hiba = Assert.Throws<ArgumentException>(() => p.getPersonWithHighestScore());
            Assert.That(hiba.Message, Is.EqualTo("Nincs egyetlen személy sem!"));
        }

        [Test]
        public void TestPersonWithHighestScore()
        {
            p.addPerson(2, "Jane", 27, false, 75);
            Assert.That(p.getPersonWithHighestScore(), Is.EqualTo(p.idKereso(1)));
        }

        [Test]
        public void TestAvarageScoreOfStudentsNoStudents()
        {
            p.people.Clear();
            var hiba = Assert.Throws<ArgumentException>(() => p.getAvarageScoreOfStudents());
            Assert.That(hiba.Message, Is.EqualTo("Nincs egyetlen személy sem!"));
        }

        [Test]
        public void TestAvarageScoreOfStudents()
        {
            p.addPerson(3, "Alice", 20, true, 88);
            p.addPerson(4, "Bob", 21, true, 92);
            Assert.That(p.getAvarageScoreOfStudents(), Is.EqualTo(90));
        }

        [Test]
        public void TestGetOldestStudentNoStudents()
        {
            p.people.Clear();
            var hiba = Assert.Throws<ArgumentException>(() => p.getOldestStudent());
        }

        [Test]
        public void TestGetOldestStudent()
        {
            p.addPerson(2, "Jane", 24, true, 75);
            Assert.That(p.getOldestStudent(), Is.EqualTo(p.idKereso(2)));
        }

        [Test]
        public void TestGetOldestStudent2()
        {
            p.addPerson(2, "Jane", 28, false, 75);
            p.addPerson(3, "Alice", 27, true, 88);
            p.addPerson(4, "Bob", 21, true, 92);
            Assert.That(p.getOldestStudent(), Is.EqualTo(p.idKereso(3)));
        }

        [Test]
        public void TestIsAnyoneFailingNoPeople()
        {
            p.people.Clear();
            var hiba = Assert.Throws<ArgumentException>(() => p.isAnyoneFailing());
            Assert.That(hiba.Message, Is.EqualTo("Nincs egyetlen személy sem!"));
        }

        [Test]
        public void TestIsAnyoneFailing()
        {
            Assert.That(p.isAnyoneFailing(), Is.False);
        }

        [Test]
        public void TestIsAnyoneFailing2()
        {
            p.addPerson(2, "Jane", 28, false, 75);
            p.addPerson(3, "Alice", 27, true, 39);
            p.addPerson(4, "Bob", 21, true, 92);
            Assert.That(p.isAnyoneFailing(), Is.True);
        }
    }
}
