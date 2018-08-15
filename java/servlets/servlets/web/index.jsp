<%-- 
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="smalldblib.Reservation, java.util.*"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Welcome To Our ISM6236 Project!</title>
    </head>
    <body>
        <%Reservation r = new Reservation();
        List<String> cust = r.listCustomers();%>
        <h1>Welcome To Our ISM6236 Project</h1>
        <h3>By Cooper Small and Josh Beychok</h3>
        <br>
        <form action="Customer" method="GET">
            <select id="customer" name="custlist" size="10">
                <%
                    for (int i=0;i<cust.size();i++){
                        String print = cust.get(i);
                    String line = String.format("<option> %s </option>",print);
                    out.println(line);}
                %>
            </select>
            <br>
            <br>
        </form>
            <form action="listreservation.html">
            <Input type="submit" value="List Reservations">
            </form>
            <form action="listAvailable.html">
            <Input type="submit" value="Book Reservation">
            </form>
            
    </body>
</html>
