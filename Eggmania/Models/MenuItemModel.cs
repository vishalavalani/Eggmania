using System;
using System.Collections.Generic;

namespace Eggmania.Models
{
    public class MenuItemModel
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public Double Price { get; set; }
        public Boolean IsSpicy { get; set; }
        public Boolean IsVeg { get; set; }
        public Boolean IsMostPopular { get; set; }
        public List<AddOn> AddOnItemList { get; set; } = new List<AddOn>();
        public List<string> AddOnItems { get; set; } = new List<string>();
        public string CategoryID { get; set; }
        public string Key { get; set; }
    }
}