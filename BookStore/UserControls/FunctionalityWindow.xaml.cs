using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookStore.UserControls
{
    /// <summary>
    /// Interaction logic for FunctionalityWindow.xaml
    /// </summary>
    public partial class FunctionalityWindow : Window
    {
        // list of books
        private static List<Book> Books = new List<Book>()
        {
            new Book("The Book of Five Rings","Sports",5056,24.2),
            new Book("The Inner Game of Tennis","Sports",8503,13.52),
            new Book("The Silent Patient","Fiction",1634,17.35),
            new Book("Anxious People","Fiction",2053,13.87),
            new Book("Treasure Island","Sci-Fi",4764,14.5),
            new Book("The Power of Your Subconscious Mind","Sci-Fi",5666,12.80),
        };

        //Initialization of functionality window
        public FunctionalityWindow()
        {
            InitializeComponent();
            booksRecord.ItemsSource = Books;
        }

        // function to navigate to the landing page
        private void go_back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Visibility = Visibility.Hidden;
            mainWindow.Show();

        }

        // function to close the application
        private void quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // function to update the data in the datagrid in show book tab
        public void refresh_book_data()
        {
            List<object> BookList = new List<object>();
            foreach (Book book in Books)
            {
                BookList.Add(new { Title = book.Title, Genre = book.Genre, ISBN = book.ISBN, Price = book.Price });
            }
            booksRecord.ItemsSource = BookList;
        }

        // function to add new book record to the existing record
        private void insert_data(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(title.Text))
            {
                MessageBox.Show("Please enter the title of the book !", "Warning", MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(genre.Text))
            {
                MessageBox.Show("Please select the genre of the book !", "Warning", MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            int bookISBN = Convert.ToInt32(isbn.Text);
            foreach (Book i in Books)
            {
                if (i.ISBN == bookISBN)
                {
                    MessageBox.Show("ISBN number must be unique !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            double bookPrice = Convert.ToDouble(price.Text);
            Books.Add(new Book(title.Text, genre.Text, bookISBN, bookPrice));
            MessageBox.Show("Book added to record successfully !", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            title.Text = "";
            genre.Text = "";
            isbn.Text = "";
            price.Text = "";
            refresh_book_data();
        }

        // function to search the book using book genre
        private void search_books(object sender, RoutedEventArgs e)
        {
            searchResult.Items.Clear();
            foreach (Book book in Books)
            {
                if (searchGenre.Text == book.Genre)
                {
                    searchResult.Items.Add(book.Title);
                }
            }
        }

        // function to update book price using book ISBN
        private void update_price(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(editISBN.Text))
            {
                MessageBox.Show("Please enter ISBN to update book price!", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool isISBN = false;
            foreach (Book book in Books)
            {
                if (Convert.ToInt32(editISBN.Text) == book.ISBN)
                {
                    book.Price = Convert.ToDouble(newPrice.Text);
                    MessageBox.Show("Book updated!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    isISBN = true;
                    break;
                }
            }
            if (isISBN == false)
            {
                MessageBox.Show("Book not found", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            editISBN.Text = "";
            newPrice.Text = "";
            refresh_book_data();
        }

    }
}
