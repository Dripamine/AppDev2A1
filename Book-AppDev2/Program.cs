﻿using System;
using System.Collections.Generic;
using System.IO;
using log4net;
using log4net.Config;

namespace Book_AppDev2
{
    internal class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            XmlConfigurator.Configure(); // Initialize log4net
            log.Info("Application starting...");
            List<Book> books = new List<Book>();
            while (true)
            {
                Console.Write("Name: ");
                string title = Console.ReadLine();
                if (string.IsNullOrEmpty(title))
                {
                    break;
                }

                Console.Write("Pages: ");
                int pages = int.Parse(Console.ReadLine());

                Console.Write("Publication year: ");
                int year = int.Parse(Console.ReadLine());

                books.Add(new Book(title, pages, year));
            }

            
            // Get the base directory of the application
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Combine the base directory with the filename
            string filePath = Path.Combine(baseDirectory, "books.csv");
            SaveBooksToCsv(books, filePath);


            // Read books from CSV file
            List<Book> booksFromFile = ReadBooksFromCsv(filePath);

            Console.Write("What information will be printed? ");
            string command = Console.ReadLine();
            if (command == "everything")
            {
                foreach (Book book in booksFromFile)
                {
                    Console.WriteLine(book);
                }
            }
            else if (command == "title")
            {
                foreach (Book book in booksFromFile)
                {
                    Console.WriteLine(book.Title);
                }
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            log.Info("Application ended.");
        }

        static void SaveBooksToCsv(List<Book> books, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var book in books)
                {
                    writer.WriteLine($"{book.Title},{book.Pages},{book.PublicationYear}");
                }
            }
        }

        static List<Book> ReadBooksFromCsv(string filePath)
        {
            var books = new List<Book>();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        books.Add(new Book(parts[0], int.Parse(parts[1]), int.Parse(parts[2])));
                    }
                }
            }
            return books;
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public int PublicationYear { get; set; }

        public Book(string title, int pages, int publicationYear)
        {
            Title = title;
            Pages = pages;
            PublicationYear = publicationYear;
        }

        public override string ToString()
        {
            return $"{Title}, {Pages} pages, {PublicationYear}";
        }
    }
}
