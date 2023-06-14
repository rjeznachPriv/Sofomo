using AutoMapper;
//using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using Sofomo.Data;
using Sofomo.Domain.Entities;
using Sofomo.Logic.Automapper;
using Sofomo.Logic.DTOs;
using System.Data.Entity;

namespace Sofomo.Tests
{
    public class TestsBase
    {
        protected LocationDTO exampleLocationDTO1 = new LocationDTO
        {
            City = "Wroclaw",
            Country = "Poland",
            IPorURL = "localhost",
            Latitude = 1,
            Longitude = 1,
            Id = Guid.Parse("ab54b65d-b408-4e20-8070-7e669253dbb0")
        };

        protected LocationDTO exampleLocationDTO2 = new LocationDTO
        {
            City = "Opole",
            Country = "Poland",
            IPorURL = "localhost",
            Latitude = 2,
            Longitude = 2,
            Id = Guid.Parse("45b690e8-2711-4fc3-aec5-c6caf10b4848")
        };


        protected LocationDTO exampleLocationDTO3 = new LocationDTO
        {
            City = "Katowice",
            Country = "Poland",
            IPorURL = "localhost",
            Latitude = 3,
            Longitude = 3,
            Id = Guid.Parse("42b690e8-2711-4fc3-aec5-c6caf10b4848")
        };

        protected Location exampleLocation1 = new Location
        {
            City = "Wroclaw",
            Country = "Poland",
            IPorURL = "localhost",
            Latitude = 1,
            Longitude = 1,
            Id = Guid.Parse("ab54b65d-b408-4e20-8070-7e669253dbb0")
};

        protected Location exampleLocation2 = new Location
        {
            City = "Opole",
            Country = "Poland",
            IPorURL = "localhost",
            Latitude = 2,
            Longitude = 2,
            Id = Guid.Parse("45b690e8-2711-4fc3-aec5-c6caf10b4848")
        };

        protected AutoMocker _autoMocker;
        protected AppDbContext _dbContextMock;
        protected IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _autoMocker = new AutoMocker();

            //var dbMock = new Mock<AppDbContext>();
            //dbMock.Setup(m => m.Locations).Returns(GetQueryableMockDbSet(new List<Location> {exampleLocation1, exampleLocation2 }));
            //_dbContextMock = new Mock<AppDbContext>().Object;

            var dbMock = new Mock<AppDbContext>();
            dbMock.Setup(m => m.Set<Location>()).Returns(GetQueryableMockDbSet(new List<Location> { exampleLocation1, exampleLocation2 }));
            _dbContextMock = dbMock.Object;

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()).CreateMapper();
        }

        protected DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return dbSet.Object;
        }
    }
}