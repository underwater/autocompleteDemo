using System;

namespace backend.Models
{
    public class City
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsFavorite { get; set; }
    }
}