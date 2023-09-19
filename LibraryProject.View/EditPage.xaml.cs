using LibraryProject.Models;
using LibraryProject.Models.Enums;
using LibraryProject.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LibraryProject.View
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public ItemService ItemService = ItemService.Init;
        public ValidationService ValidationService = ValidationService.Init;
        public User User { get; set; }
        public Item Item { get; set; }
        public EditPage(User user, Item item)
        {
            InitializeComponent();
            User = user;
            Item = item;
            SetItemToEdit(item);
            UpdateCategories();
        }
        private void UpdateCategories()
        {
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                CategoryComboBox.Items.Add(category.ToString());
            }
        }
        private void SetItemToEdit(Item item)
        {
            ItemNameTextBox.Text = item.ItemName;
            PrintDatePicker.Text = item.PrintDate.ToString();
            BookPublishingTextBox.Text = item.BookPublishing.ToString();
            PriceTextBox.Text = item.Price.ToString();
            CategoryComboBox.SelectedItem = item.Category;
            AuthorTextBox.Text = item.Author.ToString();
            Journal journal = item as Journal;
            if (journal != null)
            {
                IssueTextBox.Text = journal.IssueNumber.ToString();
                JournalRadioButton.IsChecked = true;
                BookRadioButton.IsChecked = false;
            }
            else
            {
                BookRadioButton.IsChecked = true;
                JournalRadioButton.IsChecked = false;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidationService.ValidateString(ItemNameTextBox.Text);
                ValidationService.ValidateString(AuthorTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (BookRadioButton.IsChecked == true)
            {
                var book = ItemService.GetById(Item.Id) as Book;
                book.ItemName = ItemNameTextBox.Text;
                book.BookPublishing= BookPublishingTextBox.Text;
                book.PrintDate = PrintDatePicker.SelectedDate;
                book.Price = int.Parse(PriceTextBox.Text);
                book.Category = (Category)CategoryComboBox.SelectedIndex;
                book.Author = AuthorTextBox.Text;
                ItemService.EditItem(book);
                NavigationService.Navigate(new ItemPage(User, book));
            }
            else
            {
                var journal = ItemService.GetById(Item.Id) as Journal;
                journal.ItemName = ItemNameTextBox.Text;
                journal.PrintDate = PrintDatePicker.SelectedDate;
                journal.BookPublishing=BookPublishingTextBox.Text;
                journal.Price = int.Parse(PriceTextBox.Text);
                journal.Category = (Category)CategoryComboBox.SelectedIndex;
                journal.Author = AuthorTextBox.Text;
                journal.IssueNumber = int.Parse(IssueTextBox.Text);
                ItemService.EditItem(journal);
                NavigationService.Navigate(new LibraryPage(User));
            }
        }

        private void BookType_Checked(object sender, RoutedEventArgs e)
        {
            IssueTextBox.Visibility= Visibility.Collapsed;
            IssueTB.Visibility= Visibility.Collapsed;
        }
        private void JournalType_Checked(object sender, RoutedEventArgs e)
        {
            IssueTextBox.Visibility = Visibility.Visible;
            IssueTB.Visibility = Visibility.Visible;
        }
    }
}
