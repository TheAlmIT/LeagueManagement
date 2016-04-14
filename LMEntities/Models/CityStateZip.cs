using System;
using System.Collections.Generic;

namespace LMEntities.Models
{
    public partial class CityStateZip
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
    }
}
