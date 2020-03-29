using System;
using System.Collections.Generic;
using CW3.Models;

namespace CW3.DAL
{
    public class MockDBService : IDbService
    {
        private static IEnumerable<Student> _students;
        public MockDBService()
        {
            _students = new List<Student>
            {
                new Student{IdStudent=1, FirstName="Adam", LastName="Mikolaj" },
                new Student{IdStudent=2, FirstName="Bartek", LastName="Wartek" },
                new Student{IdStudent=3, FirstName="Włodek", LastName="Dym" }
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
