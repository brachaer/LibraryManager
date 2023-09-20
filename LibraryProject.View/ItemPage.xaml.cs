using LibraryProject.Models;
using LibraryProject.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LibraryProject.View
{
    /// <summary>
    /// Interaction logic for ItemPage.xaml
    /// </summary>
    public partial class ItemPage : Page
    {
        public ItemService ItemService = ItemService.Init;
        public Item Item { get; set; }
        public User User { get; set; }
        public ItemPage(User user, Item item)
        {
            InitializeComponent();
            Item = item;
            User = user;
            SetItemPage();
        }
        private void SetItemPage()
        {
            ItemNameTextBlock.Text = Item.ItemName;
            PrintDateTextBlock.Text = Item.PrintDate.ToString();
            BookPublishingTextBlock.Text = Item.BookPublishing;
            PriceTextBlock.Text = Item.Price.ToString();
            CategoryTextBlock.Text = Item.Category.ToString();
            AuthorTextBlock.Text = Item.Author;
            Book book = Item as Book;
            if (book != null)
               ISBNIssueTextBlock.Text = book.ISBN.ToString();
            Journal journal = Item as Journal;
            if (journal != null)
                ISBNIssueTextBlock.Text= journal.IssueNumber.ToString();
            if (!User.IsLibrarian)
            {
                btnEdit.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }
        }
        private void BacktoLibrary_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LibraryPage(User));
        }
        private void Edit_BtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditPage(User,Item));   
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Item == null)
                MessageBox.Show("can't delete null item");
            else
            {
                try
                {
                    ItemService.RemoveItem(Item.Id);
                    MessageBox.Show($"{Item.Type}: {Item.ItemName} DELETED from Library");
                    NavigationService.Navigate(new LibraryPage(User));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }   
            }
        }
        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            if (Item == null)
                MessageBox.Show("can't borrow null item");
            else
            {
                try
                {
                    ItemService.BorrowItem(Item, User);
                    MessageBox.Show($"{User.Name} Borrowing: \n{Item.Type}: {Item.ItemName} \n Borrow Date: {Item.BorrowDate}");
                    NavigationService.Navigate(new LibraryPage(User));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemService.ReturnItem(Item, User);
                MessageBox.Show($"{User.Name} Returned: \n{Item.Type}: {Item.ItemName} \n Return Date: {Item.ReturnDate}");
                NavigationService.Navigate(new LibraryPage(User));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }

        }
    }
}
