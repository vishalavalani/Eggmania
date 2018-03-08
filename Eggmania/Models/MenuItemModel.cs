using System;
using System.Collections.Generic;

namespace Eggmania.Models
{
    public class MenuItemModel
    {
        public String Name { get; set; }
        public Double Price { get; set; }
        public Boolean IsSpicy { get; set; }
        public Boolean IsVeg { get; set; }
        public Boolean IsMostPopular { get; set; }
        public List<AddOn> AddOnItems { get; set; } = new List<AddOn>();
    }
}