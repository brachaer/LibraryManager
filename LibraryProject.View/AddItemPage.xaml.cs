using LibraryProject.Models;
using LibraryProject.Models.Enums;
using LibraryProject.Services;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LibraryProject.View
{
    /// <summary>
    /// Interaction logic for AddItemPage.xaml
    /// </summary>
    public partial class AddItemPage : Page
    {
        public ItemService ItemService = ItemService.Init;
        public ValidationService ValidationService = ValidationService.Init;
        public User User { get; set; }
        public AddItemPage(User user)
        {
            InitializeComponent();
            User = user;
            UpdateCategories();
        }
        private void UpdateCategories()
        {
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                CategoryComboBox.Items.Add(category.ToString());
            }
        }
        
        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            // Collect data from UI elements
            string itemName = ItemNameTextBox.Text.Trim();
            DateTime? printDate = PrintDatePicker.SelectedDate;
            string bookPublishing = BookPublishingTextBox.Text.Trim();
            int price;

            if (!ValidateInput(itemName, bookPublishing) || !TryParsePrice(PriceTextBox.Text, out price))
                return;

            Item item;

            if (BookRadioButton.IsChecked == true)
            {
                item = CreateBook(itemName, printDate, bookPublishing, price);
            }
            else
            {
                int issueNumber;
                if (!TryParseIssueNumber(IssueTextBox.Text, out issueNumber))
                    return;

                item = CreateJournal(itemName, printDate, bookPublishing, price, issueNumber);
            }

            ItemService.AddItem(item);
            NavigationService.Navigate(new LibraryPage(User));
        }

        private bool ValidateInput(string itemName, string bookPublishing)
        {
            if (string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(bookPublishing))
            {
                MessageBox.Show("Item name and book publishing cannot be empty.");
                return false;
            }

            return true;
        }
        private bool TryParsePrice(string priceText, out int price)
        {
            if (!int.TryParse(priceText, out price))
            {
                MessageBox.Show("Invalid price entered.");
                return false;
            }

            return true;
        }
        private bool TryParseIssueNumber(string issueNumberText, out int issueNumber)
        {
            if (!int.TryParse(issueNumberText, out issueNumber))
            {
                MessageBox.Show("Invalid issue number entered.");
                return false;
            }

            return true;
        }
            private Book CreateBook(string itemName, DateTime? printDate, string bookPublishing, int price)
            {
                Book book = new Book
                {
                    ItemName = itemName,
                    PrintDate = printDate,
                    BookPublishing = bookPublishing,
                    Price = price,
                    Category = (Category)CategoryComboBox.SelectedIndex,
                    Author = AuthorTextBox.Text.Trim(),
                };
                return book;
            }
        private Journal CreateJournal(string itemName, DateTime? printDate, string bookPublishing, int price, int issueNumber)
        {
            return new Journal
            {
                ItemName = itemName,
                PrintDate = printDate,
                BookPublishing = bookPublishing,
                Price = price,
                Category = (Category)CategoryComboBox.SelectedIndex,
                Author = AuthorTextBox.Text.Trim(),
                IssueNumber = issueNumber,
            };
        }
        private void BookType_Checked(object sender, RoutedEventArgs e)
        {
            IssueTextBox.Visibility = Visibility.Collapsed;
            IssueTB.Visibility = Visibility.Collapsed;
        }
        private void JournalType_Checked(object sender, RoutedEventArgs e)
        {
            IssueTB.Visibility = Visibility.Visible;
            IssueTextBox.Visibility = Visibility.Visible;
        }
    }
}