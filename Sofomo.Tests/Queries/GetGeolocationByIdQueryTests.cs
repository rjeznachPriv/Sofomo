using Shouldly;
using Sofomo.Domain.Exceptions;
using Sofomo.Logic.DTOs;
using Sofomo.Logic.Queries;

namespace Sofomo.Tests.Queries
{
    public class GetGeolocationByIdQueryTests : TestsBase
    {
        [Test]
        public void GetGeolocationByIdQueryReturnsEntityTest()
        {
            // Arrange
            var query = new GetGeolocationBiIdQuery(_dbContextMock, exampleLocation1.Id, _mapper);
            
            // Act
            var result = query.Execute();

            // Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBe(1);
            result.First().ShouldBeOfType<LocationDTO>();
            result.First(r => r.Id == exampleLocation1.Id).ShouldBeEquivalentTo(exampleLocationDTO1);
        }

        [Test]
        public void GetGeolocationByIdQueryThrowsTest()
        {
            // Arrange
            var query = new GetGeolocationBiIdQuery(_dbContextMock, Guid.Parse("12345678-1234-1234-1234-123456789012"), _mapper);

            // Act & Assert
            Should.Throw<NotFoundException>(() =>
            {
                query.Execute();
            });
        }
    }
}