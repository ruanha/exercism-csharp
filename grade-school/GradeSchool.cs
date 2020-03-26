using System;
using System.Linq;
using System.Collections.Generic;

public class GradeSchool
{
    private List<Student> RosterList = new List<Student>();

    private class Student{
        public readonly string Name;
        public readonly int Grade;
        public Student(string name, int grade) {
            Name = name;
            Grade = grade;
        }
    }

    public void Add(string student, int grade)
    {
        RosterList.Add(new Student(student, grade));
        RosterList = RosterList
            .OrderBy (s => s.Grade)
            .ThenBy  (s => s.Name)
            .ToList  ();
    }

    public IEnumerable<string> Roster() =>
        RosterList.Select(s => s.Name).ToArray();

    public IEnumerable<string> Grade(int grade) =>
        RosterList
            .Where   (s => s.Grade == grade)
            .Select  (s => s.Name)
            .ToArray ();
}