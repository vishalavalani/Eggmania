using System;
namespace Eggmania.Models
{
    public class MainMenuModel
    {
        public string DisplayName
        {
            get;
            set;
        }

        public string ImageName
        {
            get;
            set;
        }

        public int Order { get; set; }

        public string Key { get; set; }
    }
}
