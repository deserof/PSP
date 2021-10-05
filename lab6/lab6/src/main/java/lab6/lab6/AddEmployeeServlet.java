package lab6.lab6;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet(name = "add", value = "/add")
public class AddEmployeeServlet extends HttpServlet {
    private EmployeeService employeeService = new EmployeeService();

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html");

        getServletContext().getRequestDispatcher("/AddEmployee.jsp").forward(request, response);
    }

    public void destroy() {
    }
}
