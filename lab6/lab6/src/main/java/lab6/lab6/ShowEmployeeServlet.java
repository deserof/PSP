package lab6.lab6;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

@WebServlet(name = "employee", value = "/employee")
public class ShowEmployeeServlet extends HttpServlet {
    private EmployeeService employeeService = new EmployeeService();

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html");

        ArrayList<Employee> employees = employeeService.GetAll();
        request.setAttribute("employees", employees);

        getServletContext().getRequestDispatcher("/ShowEmployee.jsp").forward(request, response);
    }

    public void destroy() {
    }
}
