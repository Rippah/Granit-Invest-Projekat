namespace GranitInvest.Model
{
    public class Gatherings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Profile { get; set; }
        public string Link { get; set; }

        public Gatherings(string name, string description, string date, string location, string profile, string link)
        {
            Name = name;
            Description = description;
            Date = date;
            Location = location;
            Profile = profile;
            Link = link;
        }
        public Gatherings(int id, string name, string description, string date, string location, string profile, string link)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            Location = location;
            Profile = profile;
            Link = link;
        }
    }
}
