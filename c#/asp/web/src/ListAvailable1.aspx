<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListAvailable1.aspx.cs" Inherits="smallasg5.ListAvailable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <h3>Book a Reservation</h3>
                <h5>Enter a Date Arriving and Date Departing, then Select a Room and a Customer</h5>
              <asp:Label ID="Label1" runat="server" Text="Date Arriving :"></asp:Label>
              &nbsp;&nbsp;
              <asp:TextBox ID="tbxDateIn" runat="server"></asp:TextBox>
            </p> 
            <p>
              <asp:Label ID="Label2" runat="server" Text="Date Departing:"></asp:Label>&nbsp;&nbsp; 
              <asp:TextBox ID="tbxDateOut" runat="server"></asp:TextBox>
            </p>
            <p>
              <asp:Label ID="Label3" runat="server" Text="Available Rooms"></asp:Label><br/>
              <asp:ListBox ID="lstAvailable" runat="server" Height="302px" Width="506px"></asp:ListBox>
            </p>
            <p>
              <asp:Label ID="Label4" runat="server" Text="Customer ID :"></asp:Label>
              &nbsp;&nbsp;
              <asp:TextBox ID="tbxCId" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnList" runat="server" Text="List Rooms" OnClick="btnList_Click" />&nbsp;<asp:Button ID="btnBook" runat="server" Text="Book" OnClick="btnBook_Click" />
            &nbsp;<asp:Button ID="btnMain" runat="server" Text="Main Page" OnClick="btnMain_Click" />
            </p>

        </div>
    </form>
</body>
</html>
