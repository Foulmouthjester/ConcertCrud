using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConcertApp
{
  class Concert
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Venue { get; set; }
    public int TicketPrice { get; set; }

    public override string ToString()
    {
      return $"ID: {Id}, Name: {Name}, Date: {Date.ToShortDateString()}, Venue: {Venue}, Ticket Price: {TicketPrice}";
    }
  }
}

