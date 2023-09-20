using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Data
{
    public class ItemsRepository
    {

#if DEBUG
		readonly LibraryDbContextMock data = new LibraryDbContextMock();
#else
        readonly LibraryDbContext data = new LibraryDbContext();
#endif
        public static ItemsRepository Init { get; } = new ItemsRepository();
        private ItemsRepository() { }

        public IEnumerable<Item> Items => data.Items;
        public void AddBook(Book book) { data.Items.Add(book); data.SaveChanges(); }
        public void AddJournal(Journal journal) { data.Items.Add(journal); data.SaveChanges(); }
        public Item GetItem(int id) { return data.Items.FirstOrDefault(i => i.Id == id); }
        public void EditItem(Item item)=>  data.SaveChanges();
        public void DeleteItem(int id) { data.Items.Remove(GetItem(id)); data.SaveChanges(); }

    }
}
