using System;
using System.Collections.Generic;
using System.Linq;

public class Member
{
    public string Name { get; set; }
    public int ID { get; set; }
    private List<Book> BorrowedBooks { get; set; }

    public Member(string name, int id)
    {
        Name = name;
        ID = id;
        BorrowedBooks = new List<Book>();
    }

    public void BorrowBook(Library library, string isbn)
    {
        Book book = library.GetBook(isbn);
        if (book != null)
        {
            BorrowedBooks.Add(book);
            library.RemoveBook(isbn);
            Console.WriteLine($"{Name} borrowed: {book}");
        }
        else
        {
            Console.WriteLine("Book not available.");
        }
    }

    public void ReturnBook(Library library, string isbn)
    {
        Book book = BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);
        if (book != null)
        {
            BorrowedBooks.Remove(book);
            library.AddBook(book);
            Console.WriteLine($"{Name} returned: {book}");
        }
        else
        {
            Console.WriteLine("Book not found in borrowed list.");
        }
    }

    public void DisplayBorrowedBooks()
    {
        Console.WriteLine($"{Name}'s Borrowed Books:");
        foreach (var book in BorrowedBooks)
        {
            Console.WriteLine(book);
        }
    }
}