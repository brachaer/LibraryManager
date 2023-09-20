using LibraryProject.Models;
using LibraryProject.Models.Enums;
using System;
using System.Collections.Generic;

namespace LibraryProject.Data
{
	public class LibraryDbContextMock
	{
		public List<User> Users { get; set; }
		public List<Item> Items { get; set; }
		public LibraryDbContextMock()
		{
			Users = new List<User>()
			{
			 new User() { Name = "aa", Email = "aa.aa", IsLibrarian = true, Password = "1" },
			 new User() { Name = "bb", Email = "bb.bb", IsLibrarian = false, Password = "2" },
			 new User() { Name = "cc", Email = "cc.cc", IsLibrarian = false, Password = "3" }
			};

			Items = new List<Item>()
			{
				new Book() {ItemName="aaa book", Author="one", BookPublishing="AAA", Category=Category.Biography,  Price=20, PrintDate= DateTime.Now.AddYears(2) },
				new Book() { ItemName = "bbb book", Author = "one", BookPublishing = "AAA", Category = Category.Science, Price = 30, PrintDate = DateTime.Now.AddYears(2) },
				new Book() { ItemName = "ccc book", Author = "one", BookPublishing = "AAA", Category = Category.History, Price = 76, PrintDate = DateTime.Now.AddYears(2) },
				new Journal(){ ItemName="aa Journal", Author = "two", BookPublishing="JJJ", Category = Category.Fiction, IssueNumber=2, Price=10},
				new Journal(){ ItemName="bb Journal", Author = "two", BookPublishing="JJJ", Category = Category.Fiction, IssueNumber=5, Price=25}
			};
		}
		public void SaveChanges() { }

	}
}
