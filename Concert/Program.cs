// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace ConcertApp
{
  class Program
  {
    static void Main(string[] args)
    {
      // Load in Previous entries
      ConcertRepository.Initialize();

      while (true)
      {
        Console.WriteLine("\n--- Concert Management System ---");
        Console.WriteLine("1. Add Concert");
        Console.WriteLine("2. View All Concerts");
        Console.WriteLine("3. View Concert by ID");
        Console.WriteLine("4. Update Concert");
        Console.WriteLine("5. Delete Concert");
        Console.WriteLine("6. Exit");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
          case "1":
            AddConcert.Handle();
            break;
          case "2":
            ViewAllConcerts.Handle();
            break;
          case "3":
            ViewConcertById.Handle();
            break;
          case "4":
            UpdateConcert.Handle();
            break;
          case "5":
            DeleteConcert.Handle();
            break;
          case "6":
            Console.WriteLine("Exiting the application. Goodbye!");
            return;
          default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
        }
      }
    }
  }
}

