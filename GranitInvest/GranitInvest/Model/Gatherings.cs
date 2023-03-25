using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranitInvest.Model
{
    public class Gatherings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Link { get; set; }

        public Gatherings(string name, string description, string date, string link)
        {
            Name = name;
            Description = description;
            Date = date;
            Link = link;
        }
        public Gatherings(int id, string name, string description, string date, string link)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            Link = link;
        }
    }
}
