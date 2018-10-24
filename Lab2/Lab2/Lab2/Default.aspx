<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Information</title>
    <link href="App_Themes/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <h1>Course Information</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCourseNum" runat="server" Text="Course Number:" Height="30px" Width="150px"></asp:Label>
            <asp:TextBox ID="txtCourseNum" runat="server" Height="25px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valCourseNum" runat="server" ControlToValidate="txtCourseNum" ErrorMessage="Course Number cannot be empty" CssClass="error" Display="Dynamic" Height="30px"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblCourseName" runat="server" Text="Course Name:" Width="150px" Height="30px"></asp:Label>
            <asp:TextBox ID="txtCourseName" runat="server" Height="25px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valCourseName" runat="server" ErrorMessage="Course Name cannot be empty" ControlToValidate="txtCourseName" CssClass="error" Display="Dynamic" Height="30px"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="submit" runat="server" Text="Submit Course Information" OnClick="submit_Click" />
        </div>
    </form>
</body>
</html>
