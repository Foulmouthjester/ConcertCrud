using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace ConcertApp
{
  class ViewAllConcerts
  {
    private const string filePath = "concerts.txt";

    public static void Handle()
    {
      if (!File.Exists(filePath))
      {
        Console.WriteLine("No concerts available.");
        return;
      }

      Console.WriteLine("\n--- All Concerts ---");
      try
      {
        using (StreamReader reader = new StreamReader(filePath))
        {
          string line;
          while ((line = reader.ReadLine()) != null)
          {
            var data = line.Split(',');
            if (data.Length == 4)
            {
              Console.WriteLine($"Name: {data[0]}, Date: {data[1]}, Venue: {data[2]}, Ticket Price: {data[3]}");
            }
            else
            {
              Console.WriteLine("Invalid data in file.");
            }
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error reading concerts: {ex.Message}");
      }
    }
  }
}

