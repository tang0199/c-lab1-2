<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SimpleCounter.aspx.cs" Inherits="SimpleCounter" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="cmdIncrement" runat="server" OnClick="cmdIncrement_Click" Text="Click" /><br />
        <br />
        <asp:Label ID="lblClickCount" runat="server"></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
