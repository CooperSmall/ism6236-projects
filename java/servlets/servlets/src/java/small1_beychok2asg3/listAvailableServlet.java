/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package small1_beychok2asg3;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import smalldblib.Reservation;
import java.util.*;
/**
 *
 * @author Josh
 */
@WebServlet(name = "listAvailableServlet", urlPatterns = {"/listAvailable"})
public class listAvailableServlet extends HttpServlet {

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
        Reservation mdb = new Reservation();
        response.setContentType("text/html;charset=UTF-8");
         try (PrintWriter out = response.getWriter()) {
        String dateIn = request.getParameter("dateIn");
        String[] format = dateIn.split("/");
        int m = Integer.parseInt(format[0]);
        int d = Integer.parseInt(format[1]);
        int y = Integer.parseInt(format[2]);
        y += 2000;
        dateIn = (y + "-" + m + "-" + d);
        String dateOut = request.getParameter("dateOut");
        String[] format1 = dateOut.split("/");
        int m1 = Integer.parseInt(format1[0]);
        int d1 = Integer.parseInt(format1[1]);
        int y1 = Integer.parseInt(format1[2]);
        y1 += 2000;
        dateOut = (y1 + "-" + m1 + "-" + d1);
        
            out.println("<!DOCTYPE html>");
            out.println("<html>");
    
        
        String form = String.format("<html>\n" +
"    <head>\n" +
"        <title>Available Rooms</title>\n" +
"        <meta charset=\"UTF-8\">\n" +
"        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n" +
"        \n" +
"    </head>\n" +
"    <body>\n" +
        "<h1>Available Dates</h1>" +
        "<h3>Select an Available Room and Customer ID</h3>" +
"        <form ACTION =\"book\" METHOD =\"Post\">\n" +
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
"                    <td> <INPUT type=\"text\" size =\"20\" name=\"cid\" > </td>\n" +
"                </tr>\n" +
                  "<select id=\"customer\" name=\"roomlist\" size=\"10\">",dateIn, dateOut);
           out.println(form);
               
           List<String> av = mdb.listAvailable(dateIn, dateOut);
                for (int i=0;i<av.size();i++){
                    String print = av.get(i);
                String line = String.format("<option> %s </option>",print);
                out.println(line);}
              
          form = String.format(" </select> "+
"                <tr>\n" +
"                    <td>   </td>\n" +
"                    <td> <INPUT type=\"submit\" value=\"Book\"> </td>\n" +
"                </tr>\n" +
"            </table>\n" +
"            \n" +
"        </form>\n" +
"              \n" +
"        \n" +
"    </body>\n" +
"</html>");
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
