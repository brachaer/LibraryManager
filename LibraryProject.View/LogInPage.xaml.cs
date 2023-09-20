using LibraryProject.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LibraryProject.View
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        UserService userService = UserService.Init;
        public LogInPage()
        {
            InitializeComponent();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            string userName = UsernameTextBox.Text;
            if (userName == null)
                MessageBox.Show("Please enter username to continue");
            if (PasswordBox.TabIndex == 0)
                MessageBox.Show("Please enter password to continue");
            var user = userService.LogIn(userName, PasswordBox.Password);
            if (user == null)
                MessageBox.Show("User Name and Password don't match, Please Register.");
            else
            {
                UsernameTextBox.Clear();
                PasswordBox.Clear();
                NavigationService.Navigate(new LibraryPage(user));
            }
        }
        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}
