using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprises_manufacturing_goods.Models
{
    public partial class Years
    {
        public Years()
        {
            SalaryEmp = new HashSet<SalaryEmp>();
        }
        [Key]
        public int YearName { get; set; }
        public virtual ICollection<SalaryEmp> SalaryEmp { get; set; }
    }
}
