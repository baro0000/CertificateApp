using MotoApp.Entities;
using MotoApp.Repositories;

var employeeRepository = new GenericRepository<Employee>();
employeeRepository.Add(new Employee { FirstName = "Adam" });
employeeRepository.Add(new Employee { FirstName = "Jakub" });
employeeRepository.Add(new Employee { FirstName = "Marek" });

employeeRepository.Save();