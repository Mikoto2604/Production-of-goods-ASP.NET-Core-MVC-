using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Enterprises_manufacturing_goods
{
    public partial class Ingredients
    {
        public short Id { get; set; }
        public short? Product { get; set; }
        public short? RawMaterials { get; set; }
        public float Countingred { get; set; }

        public virtual Finproducts ProductNavigation { get; set; }
        public virtual Rawmaterials RawMaterialsNavigation { get; set; }
        
    }
}
