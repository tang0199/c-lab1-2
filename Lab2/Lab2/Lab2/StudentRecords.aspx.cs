using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentRecords : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["course"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Course course = (Course)Session["course"];
            Page.Header.Title = course.ToString();
        }
    }

    protected void addCourse_Click(object sender, EventArgs e)
    {
        int grade = int.Parse(txtGrade.Text);
        Student student = new Student(txtStudentId.Text, txtStudentName.Text, grade);
        Course course = (Course)Session["course"];

        course.AddStudent(student);

        List<Student> studentList = course.GetStudents();
        Session["studentList"] = studentList;

        foreach (Student stu in studentList)
        {
            TableRow row = new TableRow();

            TableCell cell = new TableCell();
            cell.Text = stu.Id;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = stu.Name;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = stu.Grade.ToString();
            row.Cells.Add(cell);

            tblCourseRecord.Rows.Add(row);
        }
    }

    protected void rblOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Student> studentList = (List<Student>)Session["studentList"];

        if (rblOrder.SelectedItem.Text == "ID")
        {
            studentList.Sort((a, b) => a.convertIdToInt(a.Id).CompareTo(b.convertIdToInt(b.Id)));
        }

        if (rblOrder.SelectedItem.Text == "Name")
        {
            studentList = sortByName(studentList);
        }

        if (rblOrder.SelectedItem.Text == "Grade")
        {
            studentList = sortByGrade(studentList);
        }

        foreach (Student stu in studentList)
        {
            TableRow row = new TableRow();

            TableCell cell = new TableCell();
            cell.Text = stu.Id;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = stu.Name;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = stu.Grade.ToString();
            row.Cells.Add(cell);

            tblCourseRecord.Rows.Add(row);
        }
    }

    public List<Student> sortByName(List<Student> list)
    {
        Student student = null;
        string[] Name1, Name2;

        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i; j < list.Count; j++)
            {
                Name1 = list[i].Name.Split(' ');
                Name2 = list[j].Name.Split(' ');
                if (String.Compare(Name1[1], Name2[1]) > 0)
                {
                    student = list[j];
                    list[j] = list[i];
                    list[i] = student;
                }
                else if (String.Compare(Name1[1], Name2[1]) == 0)
                {
                    if (String.Compare(Name1[0], Name2[0]) > 0)
                    {
                        student = list[j];
                        list[j] = list[i];
                        list[i] = student;
                    }
                    else if (String.Compare(Name1[0], Name2[0]) == 0)
                    {
                        if (list[i].convertIdToInt(list[i].Id) > list[j].convertIdToInt(list[j].Id))
                        {
                            student = list[j];
                            list[j] = list[i];
                            list[i] = student;
                        }
                    }
                }
            }
        }

        return list;
    }

    public List<Student> sortByGrade(List<Student> list)
    {
        Student student = null;
        string[] Name1, Name2;

        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i; j < list.Count; j++)
            {
                if (list[i].Grade > list[j].Grade)
                {
                    student = list[j];
                    list[j] = list[i];
                    list[i] = student;
                }
                else if (list[i].Grade == list[j].Grade)
                {
                    Name1 = list[i].Name.Split(' ');
                    Name2 = list[j].Name.Split(' ');
                    if (String.Compare(Name1[1], Name2[1]) > 0)
                    {
                        student = list[j];
                        list[j] = list[i];
                        list[i] = student;
                    }
                    else if (String.Compare(Name1[1], Name2[1]) == 0)
                    {
                        if (String.Compare(Name1[0], Name2[0]) > 0)
                        {
                            student = list[j];
                            list[j] = list[i];
                            list[i] = student;
                        }
                        else if (String.Compare(Name1[0], Name2[0]) == 0)
                        {
                            if (list[i].convertIdToInt(list[i].Id) > list[j].convertIdToInt(list[j].Id))
                            {
                                student = list[j];
                                list[j] = list[i];
                                list[i] = student;
                            }
                        }
                    }
                }
            }
        }

        return list;
    }
}
