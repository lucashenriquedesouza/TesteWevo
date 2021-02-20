using AutoMapper;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Threading.Tasks;
using TesteWevo.Application.Application.Services;
using TesteWevo.Application.Domain.Mappers;
using TesteWevo.Service.Mock.DTOs;
using TesteWevo.Service.Mock.Repositories;

namespace TesteWevo.Service.Application.Services
{

    public class PersonServiceTest
    {

        private PersonService _personService;

        [SetUp]
        public void Setup()
        {
            _personService = new PersonService(A.Fake<ILogger<PersonService>>(),
                                               new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new PersonMapper()))),
                                               new PersonRepositoryMock());

        }

        [Test]
        public async Task Select_OK()
        {

            //Arrange

            //Act
            var result = await _personService.Select(1);

            //Assert
            Assert.IsNotNull(result);

        }

        [Test]
        public async Task SelectAll_OK()
        {

            //Arrange

            //Act
            var result = await _personService.SelectAll();

            //Assert
            Assert.IsNotNull(result);

        }

        [Test]
        public async Task Insert_OK()
        {

            //Arrange

            //Act
            var result = await _personService.Insert(PersonSaveRequestMock.GetOk);

            //Assert
            Assert.IsNotNull(result);

        }

        [Test]
        public async Task Update_OK()
        {

            //Arrange

            //Act
            var result = await _personService.Update(PersonSaveRequestMock.GetOk);

            //Assert
            Assert.IsNotNull(result);

        }

        [Test]
        public async Task Delete_OK()
        {

            //Arrange

            //Act
            await _personService.Delete(1);

            //Assert
            Assert.Pass();

        }

    }

}
