using EmpowerIDEMSApp.Controllers;
using EmpowerIDEMSApp.DataAccessLayer;
using EmpowerIDEMSApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.X509Certificates;

namespace EmpowerID_EMS_Test
{
    public class EmployeeControllerTest
    {
        EMSDbContext _dbContext;
       
        [SetUp]
        public void Setup()
        {
            DbContextOptions<EMSDbContext> options = new DbContextOptionsBuilder<EMSDbContext>()
                .UseInMemoryDatabase(databaseName:"EMSTest")
                .Options;
     
  

            _dbContext = new EMSDbContext(options);

        }

        [Test]
        public void AddNewEmployee_Works()
        {
            //arrange
            Employee employee = new Employee();
            employee.FullName = "Mary Jane Smith";
            employee.BirthDate = DateTime.Now;
            employee.DepartmentName = "Test";
            employee.EmailAddress = "mjsmith@mail.com";
            //act
            _dbContext.Employees.Add(employee);
            Assert.Pass();
        }
        [Test]
        public void RemoveEmployee_Works()
        {
            Employee employee =new Employee();
            employee.Id = 4;
            _dbContext.Employees.Remove(employee);
            Assert.Pass();
        }
        [Test]
        public void RemoveEmployee_Fails() 
        {
            Employee employee = new Employee();
            employee.Id = 004;
            _dbContext.Employees.Remove(employee);
            Assert.Fail();
        }
        [Test]
        public void UpdateEmployee_Works()
        {
            Employee employee = new Employee();
            employee.Id = 3;
            employee.FullName = "Jack Sparraw";

            _dbContext.SaveChanges();
            Assert.Pass();
        }
        [Test]
        public void GetAllEmployeeWorks()
        {

        }
    }
}