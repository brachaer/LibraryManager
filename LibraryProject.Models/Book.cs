using System;

namespace LibraryProject.Models
{
    public class Book : Item
    {
        public string ISBN { get; set; } = Guid.NewGuid().ToString();
    }
}
