namespace Sofomo.Domain.Entities
{
    public class Location : EntityBase
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
