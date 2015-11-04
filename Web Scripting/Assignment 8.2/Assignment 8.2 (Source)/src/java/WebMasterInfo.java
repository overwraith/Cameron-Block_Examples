/*
 Author: Cameron Block 
     Class: CIS 337 Web Scripting
     File: WebMasterInfo.html
     Purpose: To create a servlet that returns web master info. 
*/
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author cameron
 */
@WebServlet(urlPatterns = {"/WebMasterInfo"})
public class WebMasterInfo extends HttpServlet {
    
    //In a real world situation would want to retrieve these from
    //a personal web server/database or something. 
    private String name = "Cameron Block";
    private String email = "cnblock@cox.net";
    private String  mailAddress = "2824 Emiline St. Bellevue, NE 68147";
    private String  description = 
            "My name is Cameron Block, I am 23 years old, and am pursuing "
            + "the programming degree here at Bellevue University. I am "
            + "very driven to achieve, and maintain a relatively high GPA, "
            + "currently of 3.8. I have taken multiple classes on "
            + "programming languages including; Java, Visual Basic.NET, "
            + "ASP.NET, C++, C, C#, and ASP.NET. I have also taken classes "
            + "such as Calculus 1 and 2 and gotten A's in both of them. In"
            + " my freetime I play with toys such as the WIFI-Pineapple, "
            + "and other Info-Sec related things. I believe that learning "
            + "about vulnerabilities can make programmers better prepared to"
            + " screen thier code for bugs, and better eliminate them. "
            + "Currently I am in the Web Scripting class, hence the web "
            + "pages. This web class has taught us about XML, XML DTD's, "
            + "PHP, servlets, Ajax, XML, etc.  Some books I am reading in "
            + "my freetime have to do with Sockets, distributed computing, "
            + "parallelization, LINQ, WCF, etc. C# and Java are so far my "
            + "favorite languages.  I would also like to pursue voice "
            + "recognition and facial recognition/video tracking algorithims,"
            + " and assembly, but the books are a little pricy. There are "
            + "not that many semesters left before I graduate. See you all "
            + "on the other side. ";

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, 
            HttpServletResponse response) 
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet WebMasterInfo</title>");            
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet WebMasterInfo at " + request.getContextPath() + "</h1>");
            //display webmaster info
            out.println("<p>\n");
            out.println("<b>Name: </b>" + this.name + "\n<br />\n");
            out.println("<b>E-mail: </b>" + this.email + "\n<br />\n");
            out.println("<b>Mail Address: </b>" + this.mailAddress + "\n<br />\n");
            out.println("<b>Description: </b>" + this.description + "\n<br />\n");
            out.println("</p>");
            
            out.println("</body>");
            out.println("</html>");
        }
    }//end method

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
    }//end method

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
    }//end method

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}//end class
