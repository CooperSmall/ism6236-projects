/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package small1_beychok2asg3;

import smalldblib.Reservation;
import java.util.*;
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Josh
 */
@WebServlet(name = "bookServlet", urlPatterns = {"/book"})
public class bookServlet extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        Reservation mdb = new Reservation();
        String dateIn = request.getParameter("dateIn");
        String dateOut = request.getParameter("dateOut");
        String cid = request.getParameter("cid");
        int cidb = Integer.parseInt(cid);
        String roomList = request.getParameter("roomlist");
        String roomNo = roomList.split(",")[0];
        int roomNob = Integer.parseInt(roomNo);
        double price = mdb.book(cidb, roomNob, dateIn, dateOut);
        
        
        try (PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Booked Reservation</title>");            
            out.println("</head>");
            out.println("<body>");
    
        
        String form = String.format("<html>\n" +
"    <head>\n" +
"        <title>Book a Room</title>\n" +
"        <meta charset=\"UTF-8\">\n" +
"        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n" +
"        \n" +
"    </head>\n" +
"    <body>\n" +
        "<h1>Reservation</h1>" +
"        <form ACTION =\"index.jsp\" METHOD =\"Post\">\n" +
"            <table>\n" +
"                <tr>\n" +
"                    <td> Date In:  </td>\n" +
"                    <td> <INPUT readonly type=\"text\" size =\"20\" name=\"dateIn\" value=\"%s\"> </td>\n" +
"                </tr>\n" +
"		<tr>\n" +
"                    <td> Date Out:  </td>\n" +
"                    <td> <INPUT readonly type=\"text\" size =\"20\" name=\"dateOut\" value=\"%s\"> </td>\n" +
"                </tr>\n" +
               " <tr>\n" +
"                    <td> Customer Id:  </td>\n" +
"                    <td> <INPUT readonly type=\"text\" size =\"20\" name=\"cid\" value=\"%s\"> </td>\n" +
"                </tr>\n" +      
"                <tr>\n" +
"                     <td> Room Number:   </td>\n" +
"                     <td> <INPUT readonly type=\"text\" size =\"20\" name=\"roomNo\" value=\"%s\"> </td>\n" +
"                 </tr>\n" +
"                     <td> Price:   </td>\n" +
"                     <td> <INPUT readonly type=\"text\" size =\"20\" name=\"roomNo\" value=\"%s\"> </td>\n"
                    ,dateIn, dateOut, cid, roomNo,price);  
        out.println(form);
        
        form = String.format(                              
"                <tr>\n" +
"                    <td>   </td>\n" +
"                    <td> <INPUT type=\"submit\" value=\"Main Menu\"> </td>\n" +
"                </tr>\n" +
"            </table>\n" +
"            \n" +
"        </form>");
        out.println(form);
        
       
            /* TODO output your page here. You may use following sample code. */
         
            out.println("</body>");
            out.println("</html>");
        
    }
}
   

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
     @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
