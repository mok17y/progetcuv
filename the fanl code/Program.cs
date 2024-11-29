using System;
using System.Linq;

class Program
{
    static void Main()
    {
        const int maxBooks = 10;
        Book[] books = new Book[maxBooks];
        int bookCount = 0;

        while (true)
        {
            Console.WriteLine("\n1. Add Book");
            Console.WriteLine("2. Search by Title");
            Console.WriteLine("3. Search by Author");
            Console.WriteLine("4. Check Availability");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (bookCount >= maxBooks)
                {
                    Console.WriteLine("Library is full.");
                    continue;
                }

                Console.Write("Enter title: ");
                string title = Console.ReadLine();
                Console.Write("Enter author: ");
                string author = Console.ReadLine();

                books[bookCount++] = new Book(title, author);
                Console.WriteLine("Book added.");
            }
            else if (choice == "2")
            {
                Console.Write("Enter title to search: ");
                string title = Console.ReadLine();
                SearchBooks(books, bookCount, title, searchByAuthor: false);
            }
            else if (choice == "3")
            {
                Console.Write("Enter author to search: ");
                string author = Console.ReadLine();
                SearchBooks(books, bookCount, author, searchByAuthor: true);
            }
            else if (choice == "4")
            {
                Console.Write("Enter title to check availability: ");
                string title = Console.ReadLine();
                bool available = IsBookAvailable(books, bookCount, title);
                Console.WriteLine(available ? "Available" : "Not available");
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }

    static void SearchBooks(Book[] books, int count, string query, bool searchByAuthor)
    {
        bool found = false;

        for (int i = 0; i < count; i++)
        {
            if (searchByAuthor)
            {
                if (StringEquals(books[i].Author, query))
                {
                    Console.WriteLine($"{books[i].Title} by {books[i].Author}");
                    found = true;
                }
            }
            else
            {
                if (StringEquals(books[i].Title, query))
                {
                    Console.WriteLine($"{books[i].Title} by {books[i].Author}");
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("No books found.");
        }
    }

    static bool IsBookAvailable(Book[] books, int count, string title)
    {
        for (int i = 0; i < count; i++)
        {
            if (StringEquals(books[i].Title, title))
            {
                return true;
            }
        }
        return false;
    }

    static bool StringEquals(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        for (int i = 0; i < s1.Length; i++)
        {
            if (char.ToLower(s1[i]) != char.ToLower(s2[i])) 
                return false;
        }

        return true;
    }
}

class Book
{
    public string Title { get; }
    public string Author { get; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}



