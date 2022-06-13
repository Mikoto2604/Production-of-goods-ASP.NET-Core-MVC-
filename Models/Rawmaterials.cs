using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Enterprises_manufacturing_goods
{
    public partial class Rawmaterials
    {
        public Rawmaterials()
        {
            Ingredients = new HashSet<Ingredients>();
            PurchaseOfrawmaterials = new HashSet<PurchaseOfrawmaterials>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public short? Unit { get; set; }
        public decimal? Sum { get; set; }
        public float? CountRawm { get; set; }

        public virtual Units UnitNavigation { get; set; }
        public virtual ICollection<Ingredients> Ingredients { get; set; }
        public virtual ICollection<PurchaseOfrawmaterials> PurchaseOfrawmaterials { get; set; }
        
        
    }
}
