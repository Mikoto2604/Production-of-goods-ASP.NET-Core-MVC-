using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Enterprises_manufacturing_goods
{
    public partial class Saleofproducts
    {
        public short Id { get; set; }
        public short? Product { get; set; }
        public float? CountSaleofpr { get; set; }
        public decimal? Sum { get; set; }
        public DateTime? Date { get; set; }
        public int? Employee { get; set; }

        public virtual Employees EmployeeNavigation { get; set; }
        public virtual Finproducts ProductNavigation { get; set; }
    }
}
