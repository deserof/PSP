package lab6.lab6;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.sql.*;
import java.util.ArrayList;

public class EmployeeRepository {
    private String url = "jdbc:sqlserver://localhost:1433;"
            + "database=lab6;"
            + "user=artsiom;"
            + "password=1234qwerQ!!;"
            + "encrypt=true;"
            + "trustServerCertificate=true;"
            + "loginTimeout=30;";
    private String driver = "com.microsoft.sqlserver.jdbc.SQLServerDriver";

    public void Create(Employee employee) {
        try {
            Class.forName(driver).getDeclaredConstructor().newInstance();

            try (Connection conn = DriverManager.getConnection(url)) {
                String sql = "INSERT Employee(FirstName, LastName, PhoneNumber) VALUES(?, ?, ?)";

                try (PreparedStatement preparedStatement = conn.prepareStatement(sql)) {
                    preparedStatement.setString(1, employee.getFirstName());
                    preparedStatement.setString(2, employee.getLastName());
                    preparedStatement.setString(3, employee.getPhoneNumber());
                    ResultSet resultSet = preparedStatement.executeQuery();
                }
            }
        } catch (Exception ex) {
            System.out.println(ex);
        }
    }

    public Employee GetById(int id) {
        Employee employee = new Employee();

        try {
            Class.forName(driver).getDeclaredConstructor().newInstance();

            try (Connection conn = DriverManager.getConnection(url)) {
                String sql = "SELECT * FROM Employee WHERE id=?";

                try (PreparedStatement preparedStatement = conn.prepareStatement(sql)) {
                    preparedStatement.setInt(1, id);
                    ResultSet resultSet = preparedStatement.executeQuery();

                    if (resultSet.next()) {
                        employee.setId(resultSet.getInt(1));
                        employee.setFirstName(resultSet.getString(2));
                        employee.setLastName(resultSet.getString(3));
                        employee.setPhoneNumber(resultSet.getString(4));
                    }
                }
            }
        } catch (Exception ex) {
            System.out.println(ex);
        }

        return employee;
    }

    public ArrayList<Employee> GetAll() {
        ArrayList<Employee> employees = new ArrayList<Employee>();

        try {
            Class.forName(driver).getDeclaredConstructor().newInstance();

            try (Connection conn = DriverManager.getConnection(url)) {
                Statement statement = conn.createStatement();
                ResultSet resultSet = statement.executeQuery("SELECT * FROM Employee");
                while (resultSet.next()) {
                    Employee employee = new Employee();
                    employee.setId(resultSet.getInt(1));
                    employee.setFirstName(resultSet.getString(2));
                    employee.setLastName(resultSet.getString(3));
                    employee.setPhoneNumber(resultSet.getString(4));
                    employees.add(employee);
                }
            }
        } catch (Exception ex) {
            System.out.println(ex);
        }

        return employees;
    }

    public void Update(int id, Employee employee) {
        try {
            Class.forName(driver).getDeclaredConstructor().newInstance();

            try (Connection conn = DriverManager.getConnection(url)) {
                String sql = "UPDATE Employee SET Employee.FirstName=?, Employee.LastName=?, Employee.PhoneNumber=? WHERE id=?";

                try (PreparedStatement preparedStatement = conn.prepareStatement(sql)) {
                    preparedStatement.setString(1, employee.getFirstName());
                    preparedStatement.setString(2, employee.getLastName());
                    preparedStatement.setString(3, employee.getPhoneNumber());
                    preparedStatement.setInt(4, id);
                    ResultSet resultSet = preparedStatement.executeQuery();
                }
            }
        } catch (Exception ex) {
            System.out.println(ex);
        }
    }

    public void Delete(int id) {
        try {
            Class.forName(driver).getDeclaredConstructor().newInstance();

            try (Connection conn = DriverManager.getConnection(url)) {
                String sql = "DELETE Employee WHERE id=?";

                try (PreparedStatement preparedStatement = conn.prepareStatement(sql)) {
                    preparedStatement.setInt(1, id);
                    ResultSet resultSet = preparedStatement.executeQuery();
                }
            }
        } catch (Exception ex) {
            System.out.println(ex);
        }
    }
}
