/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servletlistreservation;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import smalldblib.Reservation;
import java.util.List;

/**
 *
 * @author owner
 */
@WebServlet(name = "listreservationServlet", urlPatterns = {"/listreservation"})
public class listreservationServlet extends HttpServlet {

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
        
        Reservation r = new Reservation();
        String parse = request.getParameter("cid");
        int id = Integer.parseInt(parse);
        List<String> reservations = r.listReservations(id);
        String list = "";
        for (int i=0;i<reservations.size();i++)
            list = list + "<option>" + reservations.get(i) + "</options>\n";
        
        String form1 = "<form action=\"listreservation\" method=GET id=\"cid\" name=\"cid>\"\n" +
"            <strong>Customer No:</strong>\n" +
"            <select Name = \"cid\">\n" +
"                <option> 1\n" +
"                <option> 2\n" +
"                <option> 3\n" +
"                <option> 4\n" +
"                <option> 5\n" +
"            </select>\n" +
"            <input type=\"submit\" value=\"Submit\" name=\"button\" />\n" +
"        </form>";
             
        String form2 = String.format("<form action=\"listreservation\" method=\"GET\">\n" +
"            <select id=\"reservation\" name=\"list\" size=\"10\">\n" +
                 "%s" +
"            </select>\n" +
"            </form>\n" +
"            <br>\n", list);
        
        String back = "<form action=\"listreservation.html\">\n" +
"        <input type=\"submit\" value=\"Back\" name=\"button1\" />\n" +
"        </form>";
        
        String main = "<form action=\"index.jsp\">\n" +
"        <input type=\"submit\" value=\"Main Menu\" name=\"button2\" />\n" +
"        </form>";
        
        try (PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>List Reservations</title>");            
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>List Reservations</h1>");
            out.println("<h3>Select a Customer and Click Submit</h3>");
            out.println("<br>");
            out.println(form1);
            out.println("<br>");
            out.println(form2);
            out.println(back);
            out.println(main);
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
