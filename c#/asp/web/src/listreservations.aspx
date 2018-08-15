<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listreservations.aspx.cs" Inherits="smallasg5.listreservations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>List Customer Reservations</h3>
            <asp:Label ID="Label1" runat="server" Text="Customer ID:"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="300px" Width="500px"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Main" formaction="Index.aspx" OnClick="Button2_Click"/>
            <br />
            <br />
        </div>     
    </form>
</body>
</html>
