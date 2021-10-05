package lab6.lab6;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet(name = "delete", value = "/delete")
public class DeleteEmployeeServlet extends HttpServlet {
    private EmployeeService employeeService = new EmployeeService();

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html");

        employeeService.Delete(Integer.parseInt(request.getParameter("id")));

        response.sendRedirect("employee");
    }

    public void destroy() {
    }
}
