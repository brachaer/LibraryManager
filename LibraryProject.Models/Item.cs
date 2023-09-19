using LibraryProject.Models.Enums;
using System;

namespace LibraryProject.Models
{
    public abstract class Item : ICloneable
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = "Unknown";
        public DateTime? PrintDate { get; set; }
        public string BookPublishing { get; set; } = "Unknown";
        public int Price { get; set; } = 10;
        public Category Category { get; set; } = Category.Other;
        public string Author { get; set; } = "unknown";
        public bool IsBorrowed { get; set; } = false;
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? UserId { get; set; }
        public string Type => GetType().Name;
        public object Clone() => MemberwiseClone();
    }
}
