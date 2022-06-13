using Enterprises_manufacturing_goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enterprises_manufacturing_goods.Models
{
    public class IngredientsView
    {
        public IEnumerable<Ingredients> Ingredients { get; set; }
    }
}