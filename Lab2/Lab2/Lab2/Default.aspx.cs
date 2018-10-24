using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Page.IsPostBack) && (Session["course"] != null))
        {
            Response.Redirect("StudentRecords.aspx");
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        Course course = null;
        if (Session["course"] == null)
        {
            course = new Course(txtCourseNum.Text, txtCourseName.Text);
            Session["course"] = course;
        }
        Response.Redirect("StudentRecords.aspx");
    }
}