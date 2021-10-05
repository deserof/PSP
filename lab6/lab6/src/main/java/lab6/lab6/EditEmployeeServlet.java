package lab6.lab6;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.ArrayList;

@WebServlet(name = "edit", value = "/edit")
public class EditEmployeeServlet extends HttpServlet {
    private EmployeeService employeeService = new EmployeeService();
    private int id;

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html");
        id = Integer.parseInt(request.getParameter("id"));
        Employee employee = employeeService.GetById(id);

        request.setAttribute("employee", employee);
        getServletContext().getRequestDispatcher("/EditEmployee.jsp").forward(request, response);
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        response.setContentType("text/html");
        Employee employee = new Employee();
        employee.setFirstName(request.getParameter("firstName"));
        employee.setLastName(request.getParameter("lastName"));
        employee.setPhoneNumber(request.getParameter("phoneNumber"));
        employeeService.Update(id, employee);

        response.sendRedirect("employee");
    }

    public void destroy() {
    }
}
