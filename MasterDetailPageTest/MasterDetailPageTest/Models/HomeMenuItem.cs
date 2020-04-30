using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetailPageTest.Models
{
    public enum MenuItemType
    {
        Browse,
        User,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
