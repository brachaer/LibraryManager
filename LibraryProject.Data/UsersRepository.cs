using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Data
{
	public class UsersRepository
	{
#if DEBUG
		readonly LibraryDbContextMock data = new LibraryDbContextMock();
#else
        readonly LibraryDbContext data = new LibraryDbContext();
#endif
		public static UsersRepository Init { get; } = new UsersRepository();
		private UsersRepository() { }

		public IEnumerable<User> Users => data.Users;
		public void AddUser(User user) { data.Users.Add(user); data.SaveChanges(); }
		public User GetUser(int id) { return data.Users.FirstOrDefault(u=>u.Id==id); }
		public void UpdateUser(User user) { var userToUpdate = GetUser(user.Id); userToUpdate = user; data.SaveChanges(); }
		public void DeleteUser(int id) { data.Users.Remove(GetUser(id)); data.SaveChanges(); }
	}
}
