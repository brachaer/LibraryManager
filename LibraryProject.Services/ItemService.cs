using LibraryProject.Data;
using LibraryProject.Models;
using LibraryProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Services
{
    public class ItemService
    {
        readonly ItemsRepository data = ItemsRepository.Init;
        public IEnumerable<Item> GetItems() => data.Items;
        readonly UsersRepository usersData = UsersRepository.Init;
        public IEnumerable<User> GetUsers() => usersData.Users;
        public static ItemService Init { get; } = new ItemService();
        public ItemService() { }
        public void AddItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }
            Book book = item as Book;
            if (book != null)
                data.AddBook(book);
            else
            {
                Journal journal = item as Journal;
                if (journal != null)
                    data.AddJournal(journal);
            }
        }
        public void EditItem(Item item)
        {
            data.EditItem(item);    
        }
        public Item GetById(int id)
        {
            var item = data.GetItem(id);
            if (item == null)
                return null;
            return item;
        }
        public void RemoveItem(int id)
        {
            var item = GetById(id);
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }
            else
                data.DeleteItem(item.Id);
            
        }

        public void BorrowItem(Item item, User user)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            if (item.IsBorrowed)
                throw new Exception($"Item {item.ItemName} is allready borrowed");
            else
            {
                item.IsBorrowed = true;
                item.BorrowDate = DateTime.Now;
                item.UserId = user.Id;
                EditItem(item);
            }
        }

        public void ReturnItem(Item  item, User user)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            if (item.UserId!=user.Id || !item.IsBorrowed)
                throw new ArgumentNullException(nameof(item), "Item to return does not match selected user");
            else
            {
                item.IsBorrowed = false;
                item.BorrowDate = null;
                item.ReturnDate = DateTime.Now;
                item.UserId = null;
                EditItem(item);
            }
        }

        public List<Item> SearchItems(SearchParams param, string search)
        {
            var items = GetItems().ToList<Item>();
            if (param == SearchParams.ItemName)
                items = items.FindAll(i => i.ItemName.Contains(search));
            if (param == SearchParams.Author)
                items = items.FindAll(i => i.Author.Contains(search));
            if (param == SearchParams.Borrow)
            {
                if (search == "true")
                    items = items.FindAll(i => i.IsBorrowed == true);
                else
                    items = items.FindAll(i => i.IsBorrowed = false);
            }
            if (param == SearchParams.Type)
                items = items.FindAll(i => i.Type == search);
            return items;
        }
    }
}
