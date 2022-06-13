using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Enterprises_manufacturing_goods
{
    public partial class Positions
    {
        public Positions()
        {
            Employees = new HashSet<Employees>();
        }

        public short Id { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }

       
    }
}
