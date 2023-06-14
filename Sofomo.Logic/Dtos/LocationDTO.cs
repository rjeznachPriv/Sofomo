﻿namespace Sofomo.Logic.DTOs
{
    public class LocationDTO : IDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? IPorURL { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}