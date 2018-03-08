using System;
using System.Collections.Generic;

namespace Eggmania.Models
{
    public class AddOn
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AddOnItem> AddOnItems { get; set; } = new List<AddOnItem>();
        public Boolean IsMandatory { get; set; }
        public int SelectedOption { get; set; }
    }
}
