<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRecords.aspx.cs" Inherits="StudentRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>abc</title>
    <link href="App_Themes/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <h1>Course Information</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblStudentId" runat="server" Text="Student ID:" Height="30px" Width="150px"></asp:Label>
            <asp:TextBox ID="txtStudentId" runat="server" Height="25px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorStudentId" runat="server" ControlToValidate="txtStudentId" ErrorMessage="Student ID cannot be empty" CssClass="error" Display="Dynamic" Height="30px"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblStudentName" runat="server" Text="Student Name:" Width="150px" Height="30px"></asp:Label>
            <asp:TextBox ID="txtStudentName" runat="server" Height="25px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorStudentName" runat="server" ErrorMessage="Student Name cannot be empty" ControlToValidate="txtStudentName" CssClass="error" Display="Dynamic" Height="30px"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regularExpValidatorStudentName" ValidationExpression="[a-zA-Z]+\s+[a-zA-Z]+" ControlToValidate="txtStudentName" CssClass="error" Display="Dynamic" ErrorMessage="Must be in first_name last_name!" runat="server" Height="30px"/>
            <br />
            <asp:Label ID="lblGrade" runat="server" Text="Grade(0-100):" Width="150px" Height="30px"></asp:Label>
            <asp:TextBox ID="txtGrade" runat="server" Height="25px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredValidatorGrade" runat="server" ErrorMessage="Grade cannot be empty" ControlToValidate="txtGrade" CssClass="error" Display="Dynamic" Height="30px"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rangeValidatorGrade" runat="server" ErrorMessage="Grade must be an integer from 0 to 100 inclusive" ControlToValidate="txtGrade" CssClass="error" Height="30px" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
            <br />
            <asp:Button ID="addCourse" runat="server" Text="Add to Course Record" OnClick="addCourse_Click" />
        </div>

        <div>
            <p>Foolowing student records have been added:</p>
            <p>Order By</p>
            <asp:RadioButtonList ID="rblOrder" runat="server" RepeatDirection="Horizontal" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="rblOrder_SelectedIndexChanged">
                <asp:ListItem Text="ID">ID</asp:ListItem>
                <asp:ListItem Text="Name">Name</asp:ListItem>
                <asp:ListItem Text="Grade">Grade</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Table runat="server" ID="tblCourseRecord" CssClass="table">
                <asp:TableRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>    
                    <asp:TableHeaderCell>Grade</asp:TableHeaderCell> 
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
