namespace Sofomo.Domain.Entities
{
    public class Location : IEntity
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
