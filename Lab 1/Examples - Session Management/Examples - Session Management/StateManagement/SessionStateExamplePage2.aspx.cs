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

public partial class SessionStateExamplePage2 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["furnitures"] == null || Session["selectedFurnitureIndex"] == null)
		{
            Response.Redirect("SessionStateExamplePage1.aspx");
		}
        Furniture[] furnitures = (Furniture[])Session["furnitures"];

        int selectedIndex = (int)Session["selectedFurnitureIndex"];

        // Retrieve the Furniture object from session state.
        Furniture piece = furnitures[selectedIndex];

        // Display the information for this object.
        lblRecord.Text = "Name: " + piece.Name;
        lblRecord.Text += "<br />Manufacturer: ";
        lblRecord.Text += piece.Description;
        lblRecord.Text += "<br />Cost: " + piece.Cost.ToString("c");

    }
}

