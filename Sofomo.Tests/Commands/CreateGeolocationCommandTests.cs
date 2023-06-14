using Moq;
using Shouldly;
using Sofomo.Data;
using Sofomo.Domain.Entities;
using Sofomo.Domain.Exceptions;
using Sofomo.Logic.Commands;
using Sofomo.Logic.DTOs;
using Sofomo.Logic.Queries;

namespace Sofomo.Tests.Commands
{
    public class CreateGeolocationCommandTests : TestsBase
    {

        [Test]
        public void CreateGeolocationCommandDoesNotThrowWhenNewEntityProvidedTest()
        {
            // Arrange
            var command = new CreateGeolocationCommand(_dbContextMock, exampleLocationDTO3, _mapper);

            // Act
            command.Execute();
        }

        [Test]
        public void CreateGeolocationCommandThrowsWhenExistingEntityProvidedTest()
        {
            // Arrange
            var command = new CreateGeolocationCommand(_dbContextMock, exampleLocationDTO2, _mapper);

            // Act & Assert
            Should.Throw<ArgumentException>(() =>
            {
                command.Execute();
            });
        }
    }
}