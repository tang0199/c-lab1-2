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

public partial class SessionStateExamplePage1 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
        Furniture[] furnitures;

        if (Session["furnitures"] == null)
        {
            // Create and populate a furniture array.
            furnitures = new Furniture[3];
            furnitures[0] = new Furniture("Econo Sofa", "Acme Inc.", 74.99M);
            furnitures[1] = new Furniture("Pioneer Table", "Heritage Unit", 866.75M);
            furnitures[2] = new Furniture("Retro Cabinet", "Sixties Ltd.", 300.11M);

            // Add the furniture object to session state.
            Session["furnitures"] = furnitures;
        }
        else
        {
            furnitures = (Furniture[])Session["furnitures"];
        }

        if (!IsPostBack)
        {
            // Add rows to list control.			
            lstItems.Items.Add(furnitures[0].Name);
            lstItems.Items.Add(furnitures[1].Name);
            lstItems.Items.Add(furnitures[2].Name);
        }
	}
	protected void cmdMoreInfo_Click(object sender, EventArgs e)
	{
		if (lstItems.SelectedIndex != -1)
		{
            Session["selectedFurnitureIndex"] = lstItems.SelectedIndex;

            Response.Redirect("SessionStateExamplePage2.aspx");
		}
	}

}

