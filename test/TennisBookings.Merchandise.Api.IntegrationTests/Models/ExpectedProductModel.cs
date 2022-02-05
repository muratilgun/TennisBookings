using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TennisBookings.Merchandise.Api.IntegrationTests.Models
{
    [DebuggerDisplay("Name = {Name} Price = {Price}")]
    public class ExpectedProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Remaining { get; set; }
        public IReadOnlyCollection<int> Ratings { get; set; }
    }
}
