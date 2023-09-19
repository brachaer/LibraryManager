using System.Collections.Generic;

namespace LibraryProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLibrarian { get; set; } = false;
        public List<Item> BorrowedItems { get; set; } = new List<Item>();
    }
}
