using Shouldly;
using Sofomo.Logic.Commands;

namespace Sofomo.Tests.Commands
{
    public class DeleteGeolocationCommandTests : TestsBase
    {
        [Test]
        public void DeleteGeolocationDoesNotThrowTest()
        {
            // Arrange
            var command1 = new DeleteGeolocationCommand(_dbContextMock, exampleLocationDTO1.Id, _mapper);
            var command2 = new DeleteGeolocationCommand(_dbContextMock, exampleLocationDTO2.Id, _mapper);
            var command3 = new DeleteGeolocationCommand(_dbContextMock, exampleLocationDTO1.Id, _mapper);
            var command4 = new DeleteGeolocationCommand(_dbContextMock, exampleLocationDTO3.Id, _mapper);
            var command5 = new DeleteGeolocationCommand(_dbContextMock, exampleLocationDTO1.Id, _mapper);

            // Act
            command1.Execute();
            command2.Execute();
            command3.Execute();
            command4.Execute();
            command5.Execute();
        }
    }
}