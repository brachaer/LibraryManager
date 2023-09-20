using LibraryProject.Data;
using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Services
{
	public class UserService
	{
		readonly UsersRepository data = UsersRepository.Init;
		public IEnumerable<User> GetUsers() => data.Users;
		public static UserService Init { get; } = new UserService();
		public UserService() { }
		public void AddUser(User user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user), "User cannot be null");
			if (user.Name == null)
				throw new ArgumentNullException(nameof(user.Name), "User Name can not be null");
			if (user.Email == null)
				throw new ArgumentNullException(nameof(user.Email), "User Email cannot be null");
			if (user.Password == null)
				throw new ArgumentNullException(nameof(user.Password), "Password cannot be null");
			data.AddUser(user);
		}
		private User GetUser(int id)
		{
			var user = data.GetUser(id);
			if (user == null)
				return null;
			return user;
		}
		public void RemoveUser(int id)
		{
			var user = GetUser(id);
			if (user == null)
				throw new ArgumentNullException(nameof(user), "User cannot be null");
			data.DeleteUser(id);
		}
		public void Update(User user)
		{
			if(user == null)
				throw new ArgumentNullException(nameof(user), "User cannot be null");	
			data.UpdateUser(user);
		}
		public User LogIn(string name, string password)
		{
			var users = GetUsers().ToList<User>();
			users.FindAll(u => u.Name == name);
			if (users == null)
				throw new ArgumentNullException("Please sign up to the library before you can Log In");
			var user = users.Find(u => u.Password == password);
			if (user == null)
				return null;
			return user;
		}
	}
}
