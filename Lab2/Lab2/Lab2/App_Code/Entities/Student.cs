using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student
{
    public string Id { get; set; }    
    public string Name { get; set; }    
    public int Grade { get; set; }

    public Student(string id, string name, int grade)
    {
        Id = id;
        Name = name;
        Grade = grade;
    }

    public int convertIdToInt (string Id)
    {
        return int.Parse(Id);
    }


}