using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Course
/// </summary>
public class Course
{
    private string courseNumber;
    private string courseName;
    private List<Student> studentList;

    public string CourseNumber { get; set; }
    public string CourseName { get; set; }
    public List<Student> StudentList { get; set; }

    public Course(string courseNumber, string courseName)
    {
        this.courseNumber = courseNumber;
        this.courseName = courseName;
        this.studentList = new List<Student> ();
    }

    public void AddStudent (Student student)
    {
        studentList.Add(student);
    }

    public List<Student> GetStudents()
    {
        return studentList;
    }

    public override string ToString()
    {
        return courseNumber + " " + courseName;
    }
}