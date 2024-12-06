using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ConcertApp
{
  class DeleteConcert
  {
    public static void Handle()
    {
      Console.Write("Enter the ID of the concert to delete: ");
      if (int.TryParse(Console.ReadLine(), out int id))
      {
        bool success = ConcertRepository.DeleteConcert(id);
        if (success)
        {
          Console.WriteLine($"Concert with ID {id} deleted successfully.");
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


