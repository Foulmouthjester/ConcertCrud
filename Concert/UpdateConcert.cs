using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp
{
  class UpdateConcert
  {
    public static void Handle()
    {
      Console.Write("Enter the ID of the concert to update: ");
      if (int.TryParse(Console.ReadLine(), out int id))
      {
        var concert = ConcertRepository.GetById(id);
        if (concert == null)
        {
          Console.WriteLine($"No concert found with ID {id}.");
          return;
        }

        Console.WriteLine("Press Enter to keep the current value.");
        Console.WriteLine($"Current Name: {concert.Name}");
        Console.Write("Enter new name: ");
        string newName = Console.ReadLine();

        Console.WriteLine($"Current Date: {concert.Date:yyyy-MM-dd}");
        Console.Write("Enter new date (yyyy-MM-dd or yyyyMMdd): ");
        string dateInput = Console.ReadLine();
        DateTime? newDate = null;
        if (!string.IsNullOrEmpty(dateInput))
        {
          if (DateTime.TryParseExact(dateInput, new[] { "yyyy-MM-dd", "yyyyMMdd" },
              null, System.Globalization.DateTimeStyles.None, out var parsedDate))
          {
            newDate = parsedDate;
          }
          else
          {
            Console.WriteLine("Invalid date format. Skipping date update.");
          }
        }

        Console.WriteLine($"Current Venue: {concert.Venue}");
        Console.Write("Enter new venue: ");
        string newVenue = Console.ReadLine();

        Console.WriteLine($"Current Ticket Price: {concert.TicketPrice}");
        Console.Write("Enter new ticket price (integer): ");
        string priceInput = Console.ReadLine();
        int? newPrice = null;
        if (!string.IsNullOrEmpty(priceInput))
        {
          if (int.TryParse(priceInput, out var parsedPrice))
          {
            newPrice = parsedPrice;
          }
          else
          {
            Console.WriteLine("Invalid price format. Skipping price update.");
          }
        }

        bool success = ConcertRepository.UpdateConcert(id, string.IsNullOrWhiteSpace(newName) ? null : newName, newDate,
                                                       string.IsNullOrWhiteSpace(newVenue) ? null : newVenue, newPrice);
        if (success)
        {
          Console.WriteLine("Concert updated successfully.");
        }
        else
        {
          Console.WriteLine("Failed to update concert.");
        }
      }
      else
      {
        Console.WriteLine("Invalid ID. Please enter a valid number.");
      }
    }
  }
}


