using LibraryProject.Models;
using LibraryProject.Services;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LibraryProject.View
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        UserService userService = UserService.Init;
        ValidationService validationService = ValidationService.Init;
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox == null || UsernameTextBox.Text.Length == 0)
            {
                MessageBox.Show("User Name is required");
                return;
            }
            if (EmailTextBox == null || EmailTextBox.Text.Length == 0)
            {
                MessageBox.Show("Email is required");
                return;
            }
            if (PasswordBox == null || PasswordBox.Password.Length == 0)
            {
                MessageBox.Show("Password is required");
                return;
            }
            if (ValidateUser())
            {
                var user = new User() { Name = UsernameTextBox.Text, Email = EmailTextBox.Text, Password = PasswordBox.Password, IsLibrarian = (bool)IsLibrarianCB.IsChecked };
                userService.AddUser(user);
                MessageBox.Show("You have successfully registered");
                userService.LogIn(user.Name, user.Password);
                NavigationService.Navigate(new LibraryPage(user));
            }
            else
                MessageBox.Show("Did not pass validation. Try Again.");
        }
        private bool ValidateUser()
        {
            try
            {
                validationService.ValidateString(UsernameTextBox.Text);
                validationService.ValidateEmail(EmailTextBox.Text);
                return true;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
