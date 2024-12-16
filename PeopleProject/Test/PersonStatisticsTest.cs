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

    }
}
