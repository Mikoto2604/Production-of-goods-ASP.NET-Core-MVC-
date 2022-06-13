using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprises_manufacturing_goods.Models
{
    public partial class Months
    {
        public Months() {
            SalaryEmp = new HashSet<SalaryEmp>();
        }
        public byte Id { get; set; }
        public string MonthName { get; set; }
        public virtual ICollection<SalaryEmp> SalaryEmp { get; set; }
    }
}
