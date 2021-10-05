package lab6.lab6;


import java.sql.*;
import java.util.ArrayList;

public class EmployeeRepository {
    private String dbName = "lab6";
    private String serverip="10.5.18.47";
    private String serverport="1433";
    private String url = "jdbc:sqlserver://localhost:1433;encrypt=false;databaseName=lab6;";
    private String driver = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
    private String databaseUserName = "user1";
    private String databasePassword = ")pWHupp9t#";

    public void Create(Employee employee) {
        try {
            Class.forName(driver).getDeclaredConstructor().newInstance();

            try (Connection conn = DriverManager.getConnection(url)) {
                String sql = "INSERT Employee(FirstName, LastName, PhoneNumber) VALUES(?, ?, ?)";

                try (PreparedStatement preparedStatement = conn.prepareStatement(sql)) {
                    preparedStatement.setString(1, employee.firstName);
                    preparedStatement.setString(2, employee.lastName);
                    preparedStatement.setString(3, employee.phoneNumber);
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

            try (Connection conn = DriverManager.getConnection(url, databaseUserName, databasePassword)) {
                String sql = "SELECT * FROM Employee WHERE id=?";

                try (PreparedStatement preparedStatement = conn.prepareStatement(sql)) {
                    preparedStatement.setInt(1, id);
                    ResultSet resultSet = preparedStatement.executeQuery();

                    if (resultSet.next()) {
                        employee.id = resultSet.getInt(1);
                        employee.firstName = resultSet.getString(2);
                        employee.lastName = resultSet.getString(3);
                        employee.phoneNumber = resultSet.getString(4);
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
                    employee.id = resultSet.getInt(1);
                    employee.firstName = resultSet.getString(2);
                    employee.lastName = resultSet.getString(3);
                    employee.phoneNumber = resultSet.getString(4);
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
                    preparedStatement.setString(1, employee.firstName);
                    preparedStatement.setString(2, employee.lastName);
                    preparedStatement.setString(3, employee.phoneNumber);
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
