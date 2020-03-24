using System;
using System.Linq;
using System.Collections.Generic;

public class GradeSchool
{
    private List<Student> _roster = new List<Student>();

    public class Student{
        public readonly string Name;
        public readonly int Grade;
        public Student(string name, int grade) {
            Name = name;
            Grade = grade;
        }
    }

    public void Add(string student, int grade)
    {
        _roster.Add(new Student(student, grade));
        _roster = _roster
            .OrderBy (s => s.Grade)
            .ThenBy  (s => s.Name)
            .ToList  ();
    }

    public IEnumerable<string> Roster() =>
        _roster.Select(s => s.Name).ToArray();

    public IEnumerable<string> Grade(int grade) =>
        _roster
            .Where   (s => s.Grade == grade)
            .Select  (s => s.Name)
            .ToArray ();
}