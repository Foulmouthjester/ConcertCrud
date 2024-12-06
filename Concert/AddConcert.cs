using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace ConcertApp
{
  class AddConcert
  {
    public static void Handle()
    {
      Console.Write("Enter concert name: ");
      string name = Console.ReadLine();

      Console.Write("Enter concert date (yyyy-MM-dd or yyyyMMdd): ");
      DateTime date;
      while (true)
      {
        string dateInput = Console.ReadLine();
        if (DateTime.TryParseExact(dateInput, new[] { "yyyy-MM-dd", "yyyyMMdd" },
                                   null, System.Globalization.DateTimeStyles.None, out date))
        {
          break;
        }
        Console.WriteLine("Invalid date format. Please try again.");
      }

      Console.Write("Enter concert venue: ");
      string venue = Console.ReadLine();

      Console.Write("Enter ticket price: ");
      int ticketPrice;
      while (true)
      {
        if (int.TryParse(Console.ReadLine(), out ticketPrice))
        {
          break;
        }
        Console.WriteLine("Invalid ticket price. Please enter a valid whole number.");
      }

      // Add the concert to the repository
      ConcertRepository.AddConcert(name, date, venue, ticketPrice);
      Console.WriteLine("Concert added successfully!");
    }
  }
}


