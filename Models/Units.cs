using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Enterprises_manufacturing_goods
{
    public partial class Units
    {
        public Units()
        {
            Finproducts = new HashSet<Finproducts>();
            Rawmaterials = new HashSet<Rawmaterials>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Finproducts> Finproducts { get; set; }
        public virtual ICollection<Rawmaterials> Rawmaterials { get; set; }
    }
}
