using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace ConcertApp
{
  static class ConcertRepository
  {
    private static List<Concert> concerts = new List<Concert>();
    private static int currentId = 1;
    private const string filePath = "concerts.txt";

    public static void Initialize()
    {
      LoadConcertsFromFile();
    }

    public static List<Concert> GetAll()
    {
      return concerts;
    }

    public static Concert GetById(int id)
    {
      return concerts.Find(c => c.Id == id);
    }

    public static void AddConcert(string name, DateTime date, string venue, int ticketPrice)
    {
      var newConcert = new Concert
      {
        Id = currentId++,
        Name = name,
        Date = date,
        Venue = venue,
        TicketPrice = ticketPrice
      };
      concerts.Add(newConcert);
      AppendConcertToFile(newConcert);
    }

    public static bool UpdateConcert(int id, string name, DateTime? date, string venue, int? ticketPrice)
    {
      var concert = GetById(id);
      if (concert == null)
      {
        return false;
      }

      if (!string.IsNullOrEmpty(name)) concert.Name = name;
      if (date.HasValue) concert.Date = date.Value;
      if (!string.IsNullOrEmpty(venue)) concert.Venue = venue;
      if (ticketPrice.HasValue) concert.TicketPrice = ticketPrice.Value;

      SaveAllConcertsToFile();
      return true;
    }


    public static bool DeleteConcert(int id)
    {
      var concert = GetById(id);
      if (concert == null)
      {
        return false;
      }

      concerts.Remove(concert);
      SaveAllConcertsToFile();
      return true;
    }

    private static void LoadConcertsFromFile()
    {
      if (!File.Exists(filePath))
      {
        return;
      }

      try
      {
        using (StreamReader reader = new StreamReader(filePath))
        {
          string line;
          while ((line = reader.ReadLine()) != null)
          {
            var data = line.Split(',');
            if (data.Length == 4 &&
                DateTime.TryParse(data[1], out var date) &&
                int.TryParse(data[3], out var price))
            {
              concerts.Add(new Concert
              {
                Id = currentId++,
                Name = data[0],
                Date = date,
                Venue = data[2],
                TicketPrice = price
              });
            }
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error loading concerts from file: {ex.Message}");
      }
    }

    private static void AppendConcertToFile(Concert concert)
    {
      using (StreamWriter writer = new StreamWriter(filePath, append: true))
      {
        writer.WriteLine($"{concert.Name},{concert.Date:yyyy-MM-dd},{concert.Venue},{concert.TicketPrice}");
      }
    }


    private static void SaveAllConcertsToFile()
    {
      using (StreamWriter writer = new StreamWriter(filePath, append: false))
      {
        foreach (var concert in concerts)
        {
          writer.WriteLine($"{concert.Name},{concert.Date:yyyy-MM-dd},{concert.Venue},{concert.TicketPrice}");
        }
      }
    }
  }
}


