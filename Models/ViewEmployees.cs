using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Enterprises_manufacturing_goods
{
    public partial class ViewEmployees
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public decimal? Salary { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
