using Shouldly;
using Sofomo.Logic.Commands;

namespace Sofomo.Tests.Commands
{
    public class UpdateGeolocationCommandTests : TestsBase
    {
        [Test]
        public void UpdateGeolocationCommandThrowsWhenNotExistingEntityProvidedTest()
        {
            // Arrange
            var command = new UpdateGeolocationCommand(_dbContextMock, exampleLocationDTO3, _mapper);

            // Act & Assert
            Should.Throw<ArgumentException>(command.Execute);
        }
    }
}