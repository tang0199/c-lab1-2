using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SimpleCounter : System.Web.UI.Page
{
    static int clickCounter = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    //this will not work. Can you explain why? Will it work if clickCounter is static? What will happen? why?
    protected void cmdIncrement_Click(object sender, EventArgs e)
    {
        clickCounter++;
        lblClickCount.Text = "Click Counts: " + clickCounter.ToString();
    }

 //   protected void cmdIncrement_Click(object sender, EventArgs e)
 //    {
 //       int counter;
 //       if (Session["Counter"] == null)
 //       {
 //           counter = 1;
 //       }
 //       else
 //       {
 //           counter = (int)Session["Counter"] + 1;
 //       }

    //       Session["Counter"] = counter;
    //       lblClickCount.Text = "Click Counts: " + counter.ToString();
    //}
}
