using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp;
using WebApp.Controllers;
using WebApp.Repositories;
using WebApp.Validation;
using Xunit;

namespace UnitTests
{
    public class UnitTestEmployee
    {
        private readonly IEmployeerValidator _personValidator;
        private readonly IEmpDelValidator _deleteValidator;

        [Fact]
        public void Get_All_Test_Return_NotNull()
        {
            var employee = new Mock<IEmployeerRepository>();
            employee.Setup(rp => rp.Get()).Returns(GetTestPerson);
            var controller = new EmployeesController(employee.Object, _personValidator, _deleteValidator);
            Assert.NotNull(controller);
        }
        private List<EmployeerModel> GetTestPerson()
        {
            var employee = new List<EmployeerModel>
            {
                new EmployeerModel{Id = 1,FirstName ="test",LastName="test",Email = "test",Age = 9,Company = "test",IsDeleted = false}
            };
            return employee;
        }
    }
}
