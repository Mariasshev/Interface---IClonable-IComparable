using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Book : ICloneable, IComparable, IComparer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }

        public Book() { }

        public Book(int id, string title, string author, string description, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
            Year = year;
        }

        public void Show()
        {
            Console.WriteLine($"{Id} - {Title} {Author}   Description: {Description}, {Year}");
        }

        public object Clone()
        {
            return new Book
            {
                Id = this.Id,
                Title = this.Title,
                Author = this.Author,
                Description = this.Description,
                Year = this.Year
            };
        }

        // IComparer
        public int Compare(object x, object y)
        {
            if (x is Book book1 && y is Book book2)
            {
                return book1.Title.CompareTo(book2.Title);
            }
            throw new ArgumentException("Objects are not of type Book");
        }

        // IComparable
        public int CompareTo(object obj)
        {
            if (obj is Book otherBook)
            {
                return this.Year.CompareTo(otherBook.Year);
            }
            throw new ArgumentException("Object is not a Book");
        }
    }


    class Library : Book
    {
        public int Length { get; set; }
        private Book[] books;
        public Library() { }

        public Library(int len)
        {
            Length = len;
            books = new Book[Length];
        }

        public void AddBooks()
        {
            books[0] = new Book(1, "To Kill a Mockingbird", "Harper Lee", "A novel about racial injustice in the Deep South.", 1960);
            books[1] = new Book(2, "1984", "George Orwell", "A dystopian novel about totalitarianism and surveillance.", 1949);
            books[2] = new Book(3, "Pride and Prejudice", "Jane Austen", "A romantic novel that critiques societal expectations.", 1813);
            books[3] = new Book(4, "The Great Gatsby", "F. Scott Fitzgerald", "A story of love, wealth, and the American Dream.", 1925);
            books[4] = new Book(5, "Moby-Dick", "Herman Melville", "A tale of obsession and revenge against the white whale.", 1851);
        }


        public void ShowBooks()
        {
            foreach (var book in books)
            {
                book.Show();
            }
        }

        public Book[] GetBooks()
        {
            return books; 
        }


    }
}
