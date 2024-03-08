using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        // Attributes of book
        private string title;
        private string genre;
        private int isbn;
        private double price;

        // Method to get and set the value of book title
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        // Method to get and set the value of book genre
        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
            }
        }

        // Method to get and set the value of book isbn
        public int ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
            }
        }

        // Method to get and set the value of book price
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        // Default Constructor
        public Book()
        {

        }

        // Parameterized Constructor to initialize the properties of book
        public Book(string title, string genre, int isbn, double price)
        {
            Title = title;
            Genre = genre;
            ISBN = isbn;
            Price = price;
        }
    }
}
