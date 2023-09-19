using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryProject.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			MainContent.NavigationService.Navigate(new LogInPage());
		}
		//private void LoginControl_OnLoginSuccess(object sender, User user)
		//{
		//	Hide the LoginControl and show the LibraryPage
		//	CollapseLogIn();
		//	ShowLibraryPage();
		//	LibraryPage.OnLoginSuccess += (s, u) => LibraryPage_OnLoginSuccess(u);


		//}
		//private void LibraryPage_OnLoginSuccess(User user)
		//{
		//	Handle the user object in the main window if needed
		//	 For example, you can display a welcome message.
		//	string loggedInUsername = user.Name;
		//	WelcomeLabel.Content = $"Welcome, {loggedInUsername}!";
		//	WelcomeLabel.Visibility = Visibility.Visible;

		//}
		//private void LoginControl_onRegister(object sender, EventArgs e)
		//{
		//	Hide the LoginControl and show the Register control
		//	CollapseLogIn();
		//	RegisterControl.Visibility = Visibility.Visible;

		//}
		//private void RegisterControl_OnRegister(object sender, EventArgs e)
		//{
		//	Hide the RegisterControl and show the LibraryPage
		//	RegisterControl.Visibility = Visibility.Collapsed;
		//	ShowLibraryPage();
		//}


		//private void ShowLibraryPage()
		//{
		//	LibraryPage.Visibility = Visibility.Visible;
		//}
		//private void CollapseLogIn()
		//{
		//	LoginControl.Visibility = Visibility.Collapsed;

		//}

		//Hide the library page when a user logs out
		//private void HideLibraryPage()
		//{
		//	LibraryPage.Visibility = Visibility.Collapsed;
		//}
	}
}
