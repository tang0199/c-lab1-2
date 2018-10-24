using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
public partial class BookStore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //get all books in the catalog.
            List<Book> books = BookCatalogDataAccess.GetAllBooks();
            foreach (Book book in books)
            {
                //todo: Populate dropdown list selections
                drpBookSelection.Items.Add(book.Title);
            }
        }
        ShoppingCart shoppingcart = null;
        if (Session["shoppingcart"] == null)
        {
            shoppingcart = new ShoppingCart();
            //todo: add cart to the session
            Session["shoppingcart"] = shoppingcart;
        }
        else
        {
            //todo: retrieve cart from the session
            shoppingcart = (ShoppingCart)Session["shoppingcart"];

            foreach (BookOrder order in shoppingcart.BookOrders)
            {
                //todo: Remove the book in the order from the dropdown list
                drpBookSelection.Items.Remove(order.Book.Title);
            }
        }

        if (shoppingcart.NumOfItems == 0)
            lblNumItems.Text = "empty";
        else if (shoppingcart.NumOfItems == 1)
            lblNumItems.Text = "1 item";
        else
            lblNumItems.Text = shoppingcart.NumOfItems.ToString() + " items";
        
    }
    protected void drpBookSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpBookSelection.SelectedValue != "-1")
        {
            string bookTitle = drpBookSelection.SelectedItem.Value;
            Book selectedBook = BookCatalogDataAccess.GetBookByTitle(bookTitle);

            //todo: Add selected book to the session
            Session["selectedBook"] = selectedBook;
            //todo: Display the selected book's description and price 
            lblDescription.Text = selectedBook.Description;
            lblPrice.Text = selectedBook.Price.ToString();
        }
        else
        {
            //todo: Set description and price to blank
            lblDescription.Text = "";
            lblPrice.Text = "";
        }
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (drpBookSelection.SelectedValue != "-1" && Session["shoppingcart"] != null)
        {
            //todo: Retrieve selected book from the session
            Book selectedBook = (Book)Session["selectedBook"];
            //todo: get user entered quantity
            int quantity = int.Parse(txtQuantity.Text);
            //todo: Create a book order with selected book and quantity
            BookOrder order = new BookOrder(selectedBook, quantity);
            //todo: Retrieve to cart from the session
            ShoppingCart shoppingcart = (ShoppingCart)Session["shoppingcart"];
            //todo: Add book order to the shopping cart
            shoppingcart.AddBookOrder(order);
            //todo: Remove the selected item from the dropdown list
            drpBookSelection.Items.Remove(selectedBook.Title);
            //todo: Set the dropdown list's selected value as "-1"
            drpBookSelection.SelectedValue = "-1";
            //todo: Set the description to show title and quantity of the book user added to the shopping cart
            if (quantity == 1)
            {
                lblDescription.Text = quantity + " of " + selectedBook.Title + " is added to the shopping cart";
            }
            else
            {
                lblDescription.Text = quantity + " of " + selectedBook.Title + " are added to the shopping cart";
            }
            //todo: Update the number of items in shopping cart displayed next to the link to ShoppingCartView.aspx
            if (Session["numOfItems"] == null)
            {
                Session["numOfItems"] = 1;
                lblNumItems.Text = Session["numOfItems"] + " item";
            }
            else
            {
                Session["numOfItems"] = (int)Session["numOfItems"] + 1;
                lblNumItems.Text = Session["numOfItems"] + " items";
            }
        }
    }
}
