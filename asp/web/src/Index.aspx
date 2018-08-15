<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="smallasg5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3>Welcome To Our ASP.NET Project</h3>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="ListBox1" runat="server" Height="300px" Width="500px"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="List Reservations"/>
        </div>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Book Reservation"/>
    </form>
</body>
</html>
