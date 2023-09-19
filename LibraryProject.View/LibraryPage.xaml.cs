using LibraryProject.Models;
using LibraryProject.Models.Enums;
using LibraryProject.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LibraryProject.View
{
    /// <summary>
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {

        public ItemService ItemService = ItemService.Init;
        public List<Item> ItemList = new List<Item>();
        public User User { get; set; }
        public LibraryPage(User user)
        {
            User = user;
            InitializeComponent();
            ShowList();
            SetUserType();
        }

        private void ShowList()
        {
            libraryListView.Items.Clear();
            ItemList = ItemService.GetItems().OrderBy(i => i.ItemName).OrderBy(i => i.Type).ToList<Item>();

            if (ItemList != null)
                ItemList.ForEach(i => libraryListView.Items.Add(i));
            libraryListView.UnselectAll();

        }
        private void SetUserType()
        {
            if (User != null)
            {

                if (User.IsLibrarian)
                    userName.Content = $"Welcome Librarian: {User.Name} !";
                else
                {
                    userName.Content = $"Welcome {User.Name} !";
                    btnAdd.Visibility = Visibility.Collapsed;
                }
            }
            else
                MessageBox.Show("user is null");
        }

        private void AddItemClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddItemPage(User));
        }

        private void SelectItem(object sender, RoutedEventArgs e)
        {
            Item selectedItem = libraryListView.SelectedItem as Item;
            NavigationService.Navigate(new ItemPage(User, selectedItem));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            libraryListView.Items.Clear();
            var searchParam = SearchParams.Other;
            var search = "";
            if (!string.IsNullOrEmpty(NameTextBox.Text))
            {
                searchParam = SearchParams.ItemName;
                search = NameTextBox.Text;
                NameTextBox.Clear();
            }
            if (!string.IsNullOrEmpty(AuthorTextBox.Text))
            {
                searchParam = SearchParams.Author;
                search = AuthorTextBox.Text;
                AuthorTextBox.Clear();
            }
            if (!string.IsNullOrEmpty(TypeTextBox.Text))
            {
                searchParam = SearchParams.Type;
                search = TypeTextBox.Text;
                TypeTextBox.Clear();
            }
            var items = ItemService.SearchItems(searchParam, search);
            if (items != null && searchParam != SearchParams.Other)
                items.ForEach(i => libraryListView.Items.Add(i));
            MessageBox.Show("search");
        }

        //private void BorrowList_Click(object sender, RoutedEventArgs e)
        //{
        //    if (User.BorrowedItems.Count > 0)
        //    {
        //        StringBuilder sb = new StringBuilder($"{User.Name} Borrowed Items: \n");
        //        User.BorrowedItems.ForEach(i => sb.Append($"{i.ItemName} \n"));
        //        MessageBox.Show(sb.ToString());
        //    }
        //    else
        //        MessageBox.Show("No Borrowed Items");
        //}

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            User = null;
            NavigationService.Navigate(new LogInPage());
        }
    }
}

