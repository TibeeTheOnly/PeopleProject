using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject
{
    internal class Person
    {
        private int Id { get; set; }
        public int GetId() => Id;
        private string Name { get; set; }
        public string GetName() => Name;
        private int Age { get; set; }
        public int GetAge() => Age;
        private bool IsStudent { get; set; }
        public bool GetIsStudent() => IsStudent;
        private int Score { get; set; }
        public int GetScore() => Score;

        public Person(int id, string name, int age, bool isStudent, int score)
        {
            Id = id;
            Name = name;
            Age = age;
            IsStudent = isStudent;
            Score = score;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, IsStudent: {IsStudent}, Score: {Score}";
        }
    }
}
