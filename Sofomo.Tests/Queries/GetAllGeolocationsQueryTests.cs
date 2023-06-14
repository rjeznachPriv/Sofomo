using Moq;
using Shouldly;
using Sofomo.Data;
using Sofomo.Domain.Entities;
using Sofomo.Logic.DTOs;
using Sofomo.Logic.Queries;

namespace Sofomo.Tests.Queries
{
    public class GetAllGeolocationsQueryTests : TestsBase
    {

        [Test]
        public void GetAllGeolocationsQueryReturnsDataTest()
        {
            // Arrange
            var query = new GetAllGeolocationsQuery(_dbContextMock, _mapper);
            
            // Act
            var result = query.Execute();

            // Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBe(2);
            result.First().ShouldBeOfType<LocationDTO>();
            result.First(r => r.Id == exampleLocation1.Id).ShouldBeEquivalentTo(exampleLocationDTO1);
            result.First(r => r.Id == exampleLocation2.Id).ShouldBeEquivalentTo(exampleLocationDTO2);
        }

        [Test]
        public void GetAllGeolocationsQueryReturnsEmptyCollectionTest()
        {
            // Arrange
            var dbMock = new Mock<AppDbContext>();
            dbMock.Setup(m => m.Set<Location>()).Returns(GetQueryableMockDbSet(new List<Location> {}));
            var dbContextMock = dbMock.Object;

            var query = new GetAllGeolocationsQuery(dbContextMock, _mapper);

            // Act
            var result = query.Execute();

            // Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBe(0);
        }
    }
}