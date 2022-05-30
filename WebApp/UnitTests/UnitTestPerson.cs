using Moq;
using System.Collections.Generic;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Validation;
using Xunit;

namespace UnitTests
{
    public class UnitTestPerson
    {
        private readonly IPersonValidator _personValidator;
        private readonly IPersDelValidator _deleteValidator;

        [Fact]
        public  void Get_All_Test_Return_NotNull()
        {
            var person = new Mock<IPersonRepository>();
            person.Setup(rp => rp.Get()).Returns(GetTestPerson);
            var controller = new PersonController(person.Object, _personValidator, _deleteValidator);
            Assert.NotNull(controller);
        }
        private List<PersonModel> GetTestPerson()
        {
            var person = new List<PersonModel>
            {
                new PersonModel{Id = 1,FirstName ="test",LastName="test",Email = "test",Age = 9,Company = "test",IsDeleted = false}
            };
            return person;
        }
    }
}

