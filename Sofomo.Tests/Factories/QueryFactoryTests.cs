using Shouldly;
using Sofomo.Logic.Queries.Factories;

namespace Sofomo.Tests.Factories
{
    public class QueryFactoryTests : TestsBase
    {

        [Test]
        public void GetAllGeolocationsQueryCreatesProperQueryTest()
        {
            // Arrange
            var factory = new QueryFactory(_dbContextMock, _mapper);

            // Act
            var result = factory.GetAllGeolocationsQuery();

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Logic.Queries.GetAllGeolocationsQuery>();
        }

        [Test]
        public void GetGeolocationBiIdQueryCreatesProperQueryTest()
        {
            // Arrange
            var factory = new QueryFactory(_dbContextMock, _mapper);

            // Act
            var result = factory.GetGeolocationByIdQuery(Guid.NewGuid());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Logic.Queries.GetGeolocationBiIdQuery>();
        }
    }
}