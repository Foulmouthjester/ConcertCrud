using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ConcertApp
{
  class ViewConcertById
  {
    public static void Handle()
    {
      Console.Write("Enter the ID of the concert to view: ");
      if (int.TryParse(Console.ReadLine(), out int id))
      {
        var concert = ConcertRepository.GetById(id);
        if (concert != null)
        {
          Console.WriteLine("\n--- Concert Details ---");
          Console.WriteLine(concert);
        }
        else
        {
          Console.WriteLine($"No concert found with ID {id}.");
        }
      }
      else
      {
        Console.WriteLine("Invalid ID. Please enter a valid number.");
      }
    }
  }
}


