using Shouldly;
using Sofomo.Logic.Queries.Factories;

namespace Sofomo.Tests.Factories
{
    public class CommandFactoryTests : TestsBase
    {

        [Test]
        public void CreateGeolocationCommandCreatesProperCommandTest()
        {
            // Arrange
            var factory = new CommandFactory(_dbContextMock, _mapper);

            // Act
            var result = factory.CreateGeolocationCommand(exampleLocationDTO1);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Logic.Commands.CreateGeolocationCommand>();
        }

        [Test]
        public void DeleteGeolocationCommandCreatesProperCommandTest()
        {
            // Arrange
            var factory = new CommandFactory(_dbContextMock, _mapper);

            // Act
            var result = factory.DeleteGeolocationCommand(Guid.NewGuid());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Logic.Commands.DeleteGeolocationCommand>();
        }

        [Test]
        public void UpdateGeolocationCommandCreatesProperCommandTest()
        {
            // Arrange
            var factory = new CommandFactory(_dbContextMock, _mapper);

            // Act
            var result = factory.UpdateGeolocationCommand(exampleLocationDTO2);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Logic.Commands.UpdateGeolocationCommand>();
        }
    }
}