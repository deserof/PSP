package lab6.lab6;

import java.util.ArrayList;

public class EmployeeService {
    private EmployeeRepository employeeRepository = new EmployeeRepository();

    public Employee GetById(int id) {
        return employeeRepository.GetById(id);
    }

    public ArrayList<Employee> GetAll() {
        return employeeRepository.GetAll();
    }

    public void Update(int id, Employee employee) {
        employeeRepository.Update(id, employee);
    }

    public void Delete(int id) {
        employeeRepository.Delete(id);
    }

    public void Create(Employee employee) {
        employeeRepository.Create(employee);
    }
}
