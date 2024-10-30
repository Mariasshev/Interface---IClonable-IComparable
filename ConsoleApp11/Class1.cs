using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library(5);
            library.AddBooks();

            Console.WriteLine("List of books in library:");
            library.ShowBooks();

            // клонирование
            Book originalBook = library.GetBooks()[1]; 
            Book clonedBook = (Book)originalBook.Clone();
            Console.WriteLine("\nOriginal book:");
            originalBook.Show();
            Console.WriteLine("Clone book:");
            clonedBook.Show();

            // сравнение
            int comparisonResult = originalBook.CompareTo(clonedBook);
            if (comparisonResult < 0)
                Console.WriteLine($"\"{originalBook.Title}\" older than \"{clonedBook.Title}\".");
            else if (comparisonResult > 0)
                Console.WriteLine($"\"{originalBook.Title}\" bore new than \"{clonedBook.Title}\".");
            else
                Console.WriteLine($"\"{originalBook.Title}\" and \"{clonedBook.Title}\" are the same age.");

            // сортировка
            Array.Sort(library.GetBooks(), new Book());
            Console.WriteLine("\nSort by title:");
            library.ShowBooks();
        }
    }
}
